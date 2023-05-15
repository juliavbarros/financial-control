namespace JVB.FinancialControl.Data.Entities
{
    public class UserType
    {
        public UserType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        protected UserType()
        { }

        public int Id { get; private set; }
        public string Name { get; private set; }

        public virtual ICollection<User> Users { get; set; }
    }
}