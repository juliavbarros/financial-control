using Microsoft.AspNetCore.Identity;

namespace JVB.FinancialControl.Data.Entities
{
    public class Tax
    {
        public Tax(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        protected Tax()
        { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Simulation> Simulations { get; set; }


    }
}