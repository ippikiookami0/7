using LataPrzestepne.Models;
using System;
using LataPrzestepne.ViewModels;
namespace LataPrzestepne.Interfaces
{
    public interface IHistoryDbService
    {
        //public List<HistoryDB> HistoryDBList();
        public HistoryList<HistoryDB_VM> GetHistoryDB(string search, int pageIndex);
        public void AddHistoryDB(HistoryDB historyDB);
        public void RemoveHistoryDB(int Id);
        //public IQueryable<HistoryDB> GetActivePeople();
    }
}
