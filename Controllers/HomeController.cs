using Dashboard_DW_V2.Models;
using DWHouse_Dashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dashboard_DW_V2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _context;

        public HomeController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Emails()
        {
            return View();
        }

        public IActionResult Preferences()
        {
            return View();
        }

        public IActionResult VisitData()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public List<object> GetEmailsData()
        {

            List<object> data = new List<object>();
            List<int> labels = _context.EmailChartBar.Select(p => p.Month).ToList();
            data.Add(labels);
            List<int> Sent = _context.EmailChartBar.Select(p => p.CountSent).ToList();
            data.Add(Sent);
            List<int> recieved = _context.EmailChartBar.Select(p => p.CountSentSuccesful).ToList();
            data.Add(recieved);
            List<int> Opened = _context.EmailChartBar.Select(p => p.CountEmailsOpened).ToList();
            data.Add(Opened);
            return data;
        }

        [HttpPost]
        public List<object> GetPreferencesData()
        {
            List<object> data = new List<object>();
            List<int> CountAll = _context.PreferencestoChartPie.Select(p => p.Count).ToList();
            data.Add(CountAll);
            List<int> CountEmailPref = _context.PreferencestoChartPie.Select(p => p.CountEmailOptin).ToList();
            data.Add(CountEmailPref);
            List<int> CountMailPref = _context.PreferencestoChartPie.Select(p => p.CountMailOptin).ToList();
            data.Add(CountMailPref);
            List<int> CountPhonePref = _context.PreferencestoChartPie.Select(p => p.CountPhoneOptin).ToList();
            data.Add(CountPhonePref);
            List<int> CountSmsPref = _context.PreferencestoChartPie.Select(p => p.CountSmsOptin).ToList();
            data.Add(CountSmsPref);
            List<int> CountNoPref = _context.PreferencestoChartPie.Select(p => p.CountNoOptin).ToList();
            data.Add(CountNoPref);
            List<int> CountSeveralPref = _context.PreferencestoChartPie.Select(p => p.CountMoreThanOneOptin).ToList();
            data.Add(CountSeveralPref);
            return data;
        }

        [HttpPost]
        public List<object> GetVisitsData()
        {
            List<object> data = new List<object>();
            List<string> MonthYear = _context.visitChart.Select(p => p.MonthYear).ToList();
            data.Add(MonthYear);
            List<int> Visitors = _context.visitChart.Select(p => p.Visitors).ToList();
            data.Add(Visitors);
            List<float> DirectSpent = _context.visitChart.Select(p => p.DirectSpent).ToList();
            data.Add(DirectSpent);
            List<float> IndirectSpent = _context.visitChart.Select(p => p.IndirectSpent).ToList();
            data.Add(IndirectSpent);
            return data;
        }
    }
}