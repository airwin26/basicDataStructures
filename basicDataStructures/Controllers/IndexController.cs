using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace basicDataStructures.Controllers
{    public class IndexController : Controller
    {
        //Random Name Generator
        public static Random random = new Random();

        public static string randomName()
        {
            string[] names = new string[8] { "Dan Morain", "Emily Bell", "Carol Roche", "Ann Rose", "John Miller", "Greg Anderson", "Arthur McKinney", "Joann Fisher" };
            int randomIndex = Convert.ToInt32(random.NextDouble() * 7);
            return names[randomIndex];
        }

        //Random Number Generator
        public static int randomNumberInRange()
        {
            return Convert.ToInt32(random.NextDouble() * 20);
        }
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        // GET: Index
        public ActionResult Index()
        {
            Queue<string> custList = new Queue<string>();
            
            

            // Load List with 100 Customers
            for (int counter = 0; counter < 100; ++counter)
            {
                custList.Enqueue(randomName());
            }


            // Load Dictionary with Unique Customers
            var distinctCust = new HashSet<string>(custList);
            for (int counter = 0; counter < 8; ++counter)
            {
                dictionary.Add(distinctCust.ElementAt(counter), 0);
            }


            // Load Dictionary with # of burgers eaten
            for (int counter = 0; counter < 100; ++counter)
            { 
                dictionary[custList.ElementAt(counter)] += randomNumberInRange();
            }

            //Display dictionary
            /* int displaycounter = 0;
             foreach (KeyValuePair<string, int> orderTotals in dictionary)
             {
                 ViewBag.dictData +=
                    // "<p>" + orderTotals + "</p>";

                     "<p>" + dictionary.ElementAt(displaycounter).Key + ": " + dictionary.ElementAt(displaycounter).Value + "</p>";
                     displaycounter++;

             }*/

           

            var items = from pair in dictionary
                        orderby pair.Value descending
                        select pair;
            foreach (KeyValuePair<string, int> kvp in items)
            {
                ViewBag.dictData += string.Format("{0}: {1} ", kvp.Key, kvp.Value) + "<br>";
            }
     



            return View();
        }  
        public ActionResult button (object senter, EventArgs e)
        {
            var items = from pair in dictionary
                        orderby pair.Value descending
                        select pair;
            foreach (KeyValuePair<string, int> kvp in items)
            {
                ViewBag.dictData += string.Format("{0}: {1}; ", kvp.Key, kvp.Value) + "<br>";
            }
            return View();
        }
    }
}