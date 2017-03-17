using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KenticoCloud.Delivery;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KCloudApp.Controllers
{
    public class AboutController : Controller
    {
        private IConfiguration Configuration { get; set; }

        public AboutController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET: /<controller>/
        public async Task<ActionResult> Index()
        {
            DeliveryClient client = new DeliveryClient("319c48d5-d9bc-4614-af9e-a0949d901573");

            var responseAbout = await client.GetItemAsync("about_us");

            return View(responseAbout.Item);
        }
    }
}
