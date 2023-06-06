using LataPrzestepne.Interfaces;
using static System.Net.WebRequestMethods;

namespace LataPrzestepne.Services
{
    public class FiltersService : IFilters
    {
        public async Task<string> GetName(string name)
        {
            if(name.Contains("Edge") || name.Contains("Explorer"))
            {
                return "https://www.mozilla.org/pl/firefox/new/";
            }
            return "";
        }
    }
}
