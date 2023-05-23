namespace JVB.FinancialControl.Data.Entities
{
    public class UserType
    {
        public UserType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public UserType()
        { }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}