using LataPrzestepne.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using LataPrzestepne.Data;
using System.Security.Claims;
using System.Collections;
using System.Drawing.Printing;
using LataPrzestepne.Interfaces;
using LataPrzestepne.Services;

namespace LataPrzestepne.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public HistoryDB HistoryDB { get; set; }

        private readonly ILogger<IndexModel> _logger;
        public IList<HistoryDB> historyDataList { get; set; }

        private readonly IHistoryDbService _HistoryDbService;
        //private readonly DataContext _context;
        public IQueryable<HistoryDB> Records { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IHistoryDbService HistoryDbService)
        {
            _logger = logger;
            _HistoryDbService = HistoryDbService;
           // _context = context;
        }

        //public void OnGet()
        //{
            //Records = _HistoryDbService.GetActivePeople();

        //    var historyDataList = _HistoryDbService.HistoryDBList();
        //}
        public IActionResult OnPost() {
            if(HistoryDB.YearOfBirth == null) { return Page(); }     
            if (HistoryDB.YearOfBirth < 1899 || HistoryDB.YearOfBirth > 2022) 
            {
               // HistoryDB.YearOfBirth = null;
                return base.Page(); 
            }
           // historyDataList = _HistoryDbService.HistoryDBList();
            HistoryDB.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            HistoryDB.Time = DateTime.Now;
            if(HistoryDB.Name == null)
            {
                if(HistoryDB.UserId != null)
                {
                    HistoryDB.Name = User.FindFirstValue(ClaimTypes.NameIdentifier);
                }
                else
                {
                    HistoryDB.Name = "random user";
                    HistoryDB.UserId = "null";
                }
            }
            else if(HistoryDB.UserId == null)
            {
                HistoryDB.UserId = "null";
            }
            if(HistoryDB.YearOfBirth % 4 == 0)
            {
                HistoryDB.Result = "To byl rok przestepny";
            }
            else
            {
                HistoryDB.Result = "To nie byl rok przestepny";
            }
            //_context.HistoryDB.Add(HistoryDB);
            //_context.SaveChanges();
            _HistoryDbService.AddHistoryDB(HistoryDB);
            return Page();
        
        }
    }
}