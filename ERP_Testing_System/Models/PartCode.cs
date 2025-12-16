namespace ERP_Testing_System.Models
{
    public class PartCode : BaseEntity
    {
        public string PartCodeValue { get; set; } = "";
        public string ItemDescription { get; set; } = "";
        public string Ratio { get; set; } = "";
        public string Class { get; set; } = "";
        public string VA { get; set; } = "";
        public string LabelType { get; set; } = "";
    }
}
