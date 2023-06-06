using LataPrzestepne.Interfaces;
using LataPrzestepne.Models;
using LataPrzestepne.Data;
using System;
using NuGet.Protocol.Core.Types;
using LataPrzestepne.ViewModels;

namespace LataPrzestepne.Services
{
    public class HistoryDbService : IHistoryDbService
    {
    
        private readonly IRepository _Repo;
              public HistoryDbService(IRepository context)
              {
                  _Repo = context;
              }
        public HistoryList<HistoryDB_VM> GetHistoryDB(string search, int pageIndex) 
        { 
            var Querry = _Repo.GetData(search);
            List<HistoryDB_VM> historyDB_VMs = new List<HistoryDB_VM>();
            foreach (var item in Querry) 
            {
                var Data = new HistoryDB_VM
                {
                    Id = item.Id,
                    Name = item.Name,
                    UserId = item.UserId,
                    YearOfBirth = item.YearOfBirth,
                };
                historyDB_VMs.Add(Data);
            }
            return HistoryList < HistoryDB_VM > .Create(historyDB_VMs, pageIndex, 20);
        }
             public void AddHistoryDB(HistoryDB historyDB)
                {
            _Repo.AddHistoryDB(historyDB);
                }
        public void RemoveHistoryDB(int Id) 
        {
            var query = _Repo.GetData("");
            var remove = query.Where(d => d.Id == Id).FirstOrDefault();
            _Repo.RemoveHistoryDB(remove);
        }
      
    }

}
