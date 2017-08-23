using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Blip.Data
{
    public class CountriesRepository
    {
        public IEnumerable<SelectListItem> GetCountries()
        {
            using (var context = new ApplicationDbContext())
            {
                List<SelectListItem> countries = context.Countries.AsNoTracking()
                    .OrderBy(n => n.CountryNameEnglish)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.Iso3.ToString(),
                            Text = n.CountryNameEnglish
                        }).ToList();
                var countrytip = new SelectListItem()
                {
                    Value = null,
                    Text = "--- select country ---"
                };
                countries.Insert(0, countrytip);
                return new SelectList(countries, "Value", "Text");
            }
        }
    }
}