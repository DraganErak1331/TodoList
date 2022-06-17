using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext db;

        public ItemController(ApplicationDbContext db)
        {
            this.db = db;
        }

        //GET method for the Home page
        //extracts all rows in Items table and puts them in the itemList variable
        //passes itemList variable to Home page
        public IActionResult Index()
        {
            IEnumerable<Item> itemList = db.Items;
            return View(itemList);
        }


        //GET method for the AddItem page
        public IActionResult AddItem()
        {
            return View();
        }

        //POST method for the AddItem page
        //creates row in Items table with attributes from the item object passed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddItem(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        //GET method for the EditItem page
        //provides details from the respective item object to go to the respective edit page
        public IActionResult EditItem(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var item = db.Items.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        //POST method for the EditItem page
        //updates item row in database with respect to attributes given in the item object
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditItem(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Update(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        //GET method for the DeleteItem page
        //provides details from the respective item object to go to the respective delete page
        public IActionResult DeleteItem(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var item = db.Items.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        //POST method for the DeleteItem page
        //removes row in database that corresponds to the attributes of the item object passed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(Item item)
        {
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
