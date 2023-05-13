namespace JVB.FinancialControl.Data.Entities
{
    public class Customer
    {
        public Customer(int id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        protected Customer()
        { }

        public int Id { get; private set; }
        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}