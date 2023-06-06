using LataPrzestepne.Data;
using LataPrzestepne.Interfaces;
using LataPrzestepne.Models;
using static Humanizer.On;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LataPrzestepne.Services
{
    public class repository :IRepository
    {
        private readonly DataContext _context;
        public repository (DataContext context)
        {
            _context = context;
        }

        public IQueryable<HistoryDB> GetData(string Search)
        {
          
            if (Search == null)
            {
                return _context.HistoryDB;
            }
            var query = _context.HistoryDB.Where(d => d.Name.Contains(Search) || d.YearOfBirth.ToString().Contains(Search));
            query = query.OrderBy(x => x.Time);
            return query;
        }

        public void AddHistoryDB(HistoryDB historyDB) 
        { 
            _context.HistoryDB.Add(historyDB);
            _context.SaveChanges();
        }

        public void RemoveHistoryDB(HistoryDB remove)
        {
            _context.HistoryDB.Remove(remove);
            _context.SaveChanges();
        }
    }
}
