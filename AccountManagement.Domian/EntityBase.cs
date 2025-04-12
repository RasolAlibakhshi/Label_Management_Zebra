namespace AccountManagement.Domian
{
    public class EntityBase
    {
        public long ID { set; get; }
        public bool IsDeleted { set; get; }
        public DateTime CreaationDateTime { set; get; }
    }
}
