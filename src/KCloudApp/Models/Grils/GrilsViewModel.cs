using KenticoCloud.Delivery;
using System.Collections;
using System.Collections.Generic;

namespace KCloudApp.Models.Grils
{
    public class GrilsViewModel
    {
        public GrilsFilterViewModel Filter { get; }
        public IEnumerable<ContentItem> Grils { get; }

        public GrilsViewModel(IEnumerable<ContentItem> girls, GrilsFilterViewModel filter)
        {
            Filter = filter;
            Grils = girls;
        }
    }
}