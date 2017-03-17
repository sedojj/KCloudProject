using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KenticoCloud.Delivery;
using KCloudApp.Models.Grils;
using System.Linq;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KCloudApp.Controllers
{
    public class GrilsController : Controller
    {


        private readonly DeliveryClient client = new DeliveryClient("319c48d5-d9bc-4614-af9e-a0949d901573");

        // GET: /<controller>/
        public async Task<ActionResult> Index()
        {

            var grils = await client.GetItemsAsync(
                new EqualsFilter("system.type", "gril"));

            var filter = new GrilsFilterViewModel();
            filter.LoadData();

            var filteredGirls = Filter(filter, grils.Items);
            var grilsViewModel = new GrilsViewModel(filteredGirls, filter);
            return View(grilsViewModel);
        }


        [HttpPost]
        public async Task<ActionResult> Filter(GrilsFilterViewModel filter)
        {
            var grils = await client.GetItemsAsync(
                new EqualsFilter("system.type", "gril"));

            var filteredGirls = Filter(filter, grils.Items);
            return PartialView("GrilsList", filteredGirls);
        }


        private IEnumerable<ContentItem> Filter(GrilsFilterViewModel filter, IReadOnlyCollection<ContentItem> grils)
        {
            var checkboxes = filter.Checkboxes
                .Where(x => x.IsChecked)
                .Select(x => x.Codename);

            var filteredGrils = grils
                .Where(gril => {
                    var terms = gril.GetTaxonomyTerms("gril")
                    .Select(tag => tag.Codename)
                    .All(term => !checkboxes.Contains(term));
                    return !terms;
                    })
                .ToList();
            return filteredGrils;
        }

        public async Task<ActionResult> GrilDetail(string id)
        {
            var grildetail = await client.GetItemAsync(id);
            return View(grildetail.Item);
        }


    }
}
