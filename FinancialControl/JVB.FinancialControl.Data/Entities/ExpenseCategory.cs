using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;

namespace JVB.FinancialControl.Data.Entities
{
    public class ExpenseCategory
    {
        public ExpenseCategory(int id, string name)
        {
            Id = id;
            Name = name;

        }

        protected ExpenseCategory()
        { }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }

    }
}