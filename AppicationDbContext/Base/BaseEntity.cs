namespace Modeles.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DatCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateDeleted { get; set; }
    }
}
