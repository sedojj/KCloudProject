using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using KenticoCloud.Delivery;

namespace KCloudApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DeliveryClient client = new DeliveryClient("319c48d5-d9bc-4614-af9e-a0949d901573");

        // GET: /<controller>/
        public async Task<ActionResult> Index()
        {

            var responseAbout = await client.GetItemAsync("currentintropage",
                new DepthParameter(2));

            return View(responseAbout.Item);
        }
    }
}
