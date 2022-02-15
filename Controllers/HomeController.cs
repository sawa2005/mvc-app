using Microsoft.AspNetCore.Mvc;
using MVCApp.Models;
using Newtonsoft.Json;

namespace MVCApp.Controllers {
    public class HomeController : Controller {
        // Startsida
        public IActionResult Start() {
            // Läs in
            var JsonStr = System.IO.File.ReadAllText("courses.json");
            var JsonObj = JsonConvert.DeserializeObject<List<CourseModel>>(JsonStr);

            // Sessionsvariabel
            string s = "Exempeltext från sessionsvariabeln";
            HttpContext.Session.SetString("test", s);

            return View(JsonObj);
        }

        // Sida med sessionsvariabel
        public IActionResult Session() {
            string? s2 = HttpContext.Session.GetString("test");
            ViewBag.text = s2;

            return View();
        }

        // Om sidan
        public IActionResult About() {
            List<AboutModel> abouts = new List<AboutModel> {
                new AboutModel {Id = 1, Info = "Sidan skapades 2022-02-11."},
                new AboutModel {Id = 2, Info = "Sidan ingår i Moment 2 av kursen Webbutveckling med .NET."},
                new AboutModel {Id = 3, Info = "Sidan skapades av Samuel Ward."},
                new AboutModel {Id = 4, Info = "Sidan har skapats från grunden genom Visual Studio Code och CLI."},
            };

            ViewData["aboutlist"] = abouts;         // ViewData

            ViewBag.abouts = abouts;                // ViewBag

            ViewModel vm = new ViewModel {          // ViewModel
                AboutList = abouts
            };

            return View(vm);
        }

        // Kurssida
        public IActionResult Courses() {
            return View();
        }

        [HttpPost]
        public IActionResult Courses(CourseModel model) {
            if (ModelState.IsValid) {
                // Läs in
                var JsonStr = System.IO.File.ReadAllText("courses.json");
                var JsonObj = JsonConvert.DeserializeObject<List<CourseModel>>(JsonStr);

                // Lägg till
                if (JsonObj != null)
                {
                    JsonObj.Add(model);
                }

                // Konvertera objekt till JSON och lagra
                System.IO.File.WriteAllText("courses.json", JsonConvert.SerializeObject(JsonObj, Formatting.Indented));

                // Rensa formuläret
                ModelState.Clear();
            }
            return View();
        }
    }
}