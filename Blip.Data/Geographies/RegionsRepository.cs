using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Blip.Data
{
    public class RegionsRepository
    {
        public IEnumerable<SelectListItem> GetRegions()
        {
            List<SelectListItem> regions = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = " "
                }
            };
            return regions;
        }

        public IEnumerable<SelectListItem> GetRegions(string iso3)
        {
            if (!String.IsNullOrWhiteSpace(iso3))
            {
                using (var context = new ApplicationDbContext())
                {
                    IEnumerable<SelectListItem> regions = context.Regions.AsNoTracking()
                        .OrderBy(n => n.RegionNameEnglish)
                        .Where(n => n.Iso3 == iso3)
                        .Select(n =>
                           new SelectListItem
                           {
                               Value = n.RegionCode,
                               Text = n.RegionNameEnglish
                           }).ToList();
                    return new SelectList(regions, "Value", "Text");
                }
            }
            return null;
        }
    }
}