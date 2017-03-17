using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KCloudApp.Models.Grils
{
    public class GrilsFilterViewModel
    {
        [UIHint("GrilsFilter")]
        public GrilsFilterCheckboxViewModel[] Checkboxes { get; set; }
        public void LoadData()
        {
            var taxonomyGroupItemNames = new string[][]
            {
                new string[] { "covered", "Covered" },
                new string[] { "bikini", "Bikini" },
                new string[] { "lingerie", "Lingerie" },
                new string[] { "naked", "Naked" },
                new string[] { "topless", "Topless" },
                new string[] { "boobs", "Boobs" },
                new string[] { "small_boobs", "Small boobs" },
                new string[] { "big_boobs" , "Big BOOBS" }
            };

            Checkboxes = taxonomyGroupItemNames.Select(item =>
            {
                return new GrilsFilterCheckboxViewModel
                {
                    Codename = item[0],
                    DisplayName = item[1],
                    IsChecked = false
                };
            }).ToArray();
        }
    }
}
