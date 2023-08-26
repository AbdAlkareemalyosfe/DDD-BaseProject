namespace SharedKernal.Operation
{
    public class OperartionResult<T>
    {

        public string Message { get; set; }

        public OperationResultTypes OperationResultType { get; set; }

        public Exception Exception { get; set; }

        public int? StatusCode { get; set; }

        public T Result { get; set; }
        public IEnumerable<T> RangeResult { get; set; }

        public bool IsSuccess => OperationResultType == OperationResultTypes.Success;

        public bool HasException => this.OperationResultType == OperationResultTypes.Exception;


        public bool HasCustomeStatusCode => StatusCode > 0;


        public OperartionResult<T> SetSuccess(T result)
        {
            Result = result;
            OperationResultType = OperationResultTypes.Success;
            return this;
        }


        /// <summary>
        /// <para>Effect in <code>base.OperationResultType</code> to <seealso cref="OperationResultTypes.Success"/></para>
        /// <para>Effect in <code>base.Message</code> .</para>
        /// </summary>
        /// <param name="message"></param>
        /// <returns> <see cref="OperationResult{T}"/> </returns>
        public OperartionResult<T> SetSuccess(string message)
        {
            Message = message;
            OperationResultType = OperationResultTypes.Success;
            return this;
        }

        /// <summary>
        /// Helper to pass success result 
        /// <para>Effect in <code>base.OperationResultType</code> to <seealso cref="OperationResultTypes.Success"/></para>
        /// <para>Effect in <code>base.Message</code> .</para>
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns> <see cref="OperationResult{T}"/> </returns>
        public OperartionResult<T> SetSuccess(T result, string message)
        {
            Message = message;
            Result = result;
            OperationResultType = OperationResultTypes.Success;
            return this;
        }


        /// <summary>
        /// Helper  
        /// <para>Effect in <code>base.OperationResultType</code> to <seealso cref="OperationResultTypes.Failed"/></para>
        /// <para>Effect in <code>base.Message</code> .</para>
        /// <para>Effect in <code>base.OperationResultType</code> default value <see cref=" OperationResultTypes.Failed"/> , <see cref="OperationResultTypes.Forbidden"/> and <see cref="OperationResultTypes.Unauthorized"/> </para>
        /// <para>Exception :  <see langword="throw"/> <see cref="ArgumentException"/> if type not kind of Failed .</para>
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <returns> <see cref="OperationResult{T}"/> </returns>
        public OperartionResult<T> SetFailed(string message, OperationResultTypes type = OperationResultTypes.Failed)
        {
            if (type != OperationResultTypes.Failed && type != OperationResultTypes.Forbidden && type != OperationResultTypes.Unauthorized)
                throw new ArgumentException($"{nameof(SetFailed)} in {nameof(OperartionResult<T>)} take {type} should use with {OperationResultTypes.Failed}, {OperationResultTypes.Forbidden} or {OperationResultTypes.Unauthorized} .");

            Message = message;
            OperationResultType = type;
            return this;
        }


        /// <summary>
        /// Helper to pass exception result 
        /// <para>Effect in <code>base.OperationResultType</code> to <seealso cref="OperationResultTypes.Exception"/> .</para>
        /// </summary>
        /// <param name="exception"></param>
        /// <returns> <see cref="OperationResult{T}"/> </returns>
        public OperartionResult<T> SetException(Exception exception)
        {
            Exception = exception;
            OperationResultType = OperationResultTypes.Exception;
            return this;
        }

    }
}
