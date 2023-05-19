namespace JVB.FinancialControl.Data.Entities
{
    public class GoalCategory
    {
        public GoalCategory(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        protected GoalCategory()
        { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }
    }
}