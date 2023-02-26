using forremember.Data;
using forremember.Models;
using Microsoft.AspNetCore.Mvc;

namespace forremember.Controllers
{
    public class ItemController : Controller
    {
        public ItemController(ApplicationDbContext contex)
        {
            _context = contex;
        }

        private readonly ApplicationDbContext _context;
        public IActionResult Index()
        {
            IEnumerable<Item> Listitems = _context.Items.ToList();

            return View(Listitems);
        }
        //  [HttpGet]
        public IActionResult New()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Item item)
        {
            if (item.Name == "100")
            {
                ModelState.AddModelError("Name", "name Not valid 100");

            }
            if (ModelState.IsValid)
            {
                _context.Items.Add(item);
                TempData["SuccessData"] = "Item id added sucssefully";
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(item);
        }


        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var item = _context.Items.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        {
            if (item.Name == "100")
            {
                ModelState.AddModelError("Name", "name Not valid 100");

            }
            if (ModelState.IsValid)
            {
                _context.Items.Update(item);
                TempData["SuccessData"] = "Item id Edited sucssefully";
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(item);
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var item = _context.Items.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]

        public IActionResult DeleteItem(int? Id)
        {
            var item = _context.Items.Find(Id);
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            _context.Remove(item);
            TempData["SuccessData"] = "Item id Deleted sucssefully";
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
