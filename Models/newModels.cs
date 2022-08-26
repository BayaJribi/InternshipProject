using System.ComponentModel.DataAnnotations;

namespace Dashboard_DW_V2.Models
{
    public class EmailDataChartBar
    {
        public int CountSent { get; set; }
        public int CountSentSuccesful { get; set; }
        public int CountEmailsOpened { get; set; }
        [Key]
        public int Month { get; set; }
        public int Year { get; set; }

    }

    public class PreferencesDataToPieChart
    {
        [Key]
        public int Count { get; set; }
        public int CountEmailOptin { get; set; }
        public int CountMailOptin { get; set; }
        public int  CountPhoneOptin { get; set; }
        public int CountSmsOptin { get; set; }
        public int CountNoOptin { get; set; }
        public int CountMoreThanOneOptin { get; set; }

    }

    public class VisitChart
    {
        [Key]
        public string MonthYear { get; set; }
        public int Visitors { get; set; }
        public float DirectSpent { get; set; }
        public float IndirectSpent { get; set; }
    }
}
