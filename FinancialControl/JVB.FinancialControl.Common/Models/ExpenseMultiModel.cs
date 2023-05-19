namespace JVB.FinancialControl.Common.Models
{
    public class ExpenseMultiModel
    {
        public string CategoryName { get; set; }
        public string CategoryId { get; set; }
        public decimal? January { get; set; }
        public decimal? February { get; set; }
        public decimal? March { get; set; }
        public decimal? April { get; set; }
        public decimal? May { get; set; }
        public decimal? June { get; set; }
        public decimal? July { get; set; }
        public decimal? August { get; set; }
        public decimal? September { get; set; }
        public decimal? October { get; set; }
        public decimal? November { get; set; }
        public decimal? December { get; set; }

        public string? JanuaryRowId { get; set; }
        public string? FebruaryRowId { get; set; }
        public string? MarchRowId { get; set; }
        public string? AprilRowId { get; set; }
        public string? MayRowId { get; set; }
        public string? JuneRowId { get; set; }
        public string? JulyRowId { get; set; }
        public string? AugustRowId { get; set; }
        public string? SeptemberRowId { get; set; }
        public string? OctoberRowId { get; set; }
        public string? NovemberRowId { get; set; }
        public string? DecemberRowId { get; set; }
    }
}