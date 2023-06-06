using LataPrzestepne.Interfaces;
using LataPrzestepne.Filters;
using LataPrzestepne.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace LataPrzestepne.Filters
{
    public class Filters : IAsyncPageFilter
    {
        private readonly IFilters _FilterService;
        public Filters(IFilters browser)
        {
            _FilterService = browser;
        }
        public async Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            await Task.CompletedTask;
        }
        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            var useragent = context.HttpContext.Request.Headers;
            var builder = new StringBuilder(Environment.NewLine);
            foreach (var header in useragent)
            {
                builder.AppendLine($"{header.Key}: {header.Value}");
            }
            var headersDump = builder.ToString();

            var result = await _FilterService.GetName(headersDump);
            if (result != "") context.HttpContext.Response.Redirect(result);

            await next.Invoke();
        }
    }
}