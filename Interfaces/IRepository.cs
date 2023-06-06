using LataPrzestepne.ViewModels;
using LataPrzestepne.Models;
namespace LataPrzestepne.Interfaces
{
    public interface IRepository
    {
        public IQueryable<HistoryDB> GetData(string search);
        public void AddHistoryDB(HistoryDB data);
        public void RemoveHistoryDB(HistoryDB remove);
    }
}
