using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Security.Claims;
using LataPrzestepne.Data;
using LataPrzestepne.Models;
using LataPrzestepne.Services;
using LataPrzestepne.Interfaces;
using LataPrzestepne.ViewModels;

namespace LataPrzestepne.Pages
{
    public class HistoryPageModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        [BindProperty]
       // public ID ID { get; set; }

        //public HistoryDB HistoryDB { get; set; }
        public HistoryList<HistoryDB_VM> HistoryPages { get; set; }
        private readonly IHistoryDbService _context;


        public HistoryPageModel(IHistoryDbService context)
        {
            _context = context;
        }

        public void OnGet(int pageIndex = 1)
        {
            HistoryPages = _context.GetHistoryDB(Search, pageIndex);
        }

        public IActionResult OnPost(int remid, int pageIndex = 1)
        {
            System.Diagnostics.Debug.WriteLine("ERROR" + remid);
            _context.RemoveHistoryDB(remid);
            HistoryPages = _context.GetHistoryDB(Search, pageIndex);
            return Page();
        }
    }
}