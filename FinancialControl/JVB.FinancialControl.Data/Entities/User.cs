namespace JVB.FinancialControl.Data.Entities
{
    public class User
    {
        public User(int id, string username, string password, string email, string firstName, string lastName, DateTime birthDate, decimal grossSalary, decimal netSalary, int userTypeId)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            GrossSalary = grossSalary;
            NetSalary = netSalary;
            UserTypeId = userTypeId;
        }

        protected User()
        { }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal NetSalary { get; set; }
        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }
        public virtual ICollection<Quotation> Quotations { get; set; }
    }
}