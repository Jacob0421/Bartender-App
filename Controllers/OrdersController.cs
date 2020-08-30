using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bartender_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;

namespace Bartender_App.Controllers
{
    public class OrdersController : Controller
    {
        private readonly BartenderDbContext _context;

        public OrdersController(BartenderDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult MyOrder(string nameIn, string drinkOrderedIn)
        {
            if (string.IsNullOrEmpty(nameIn) || string.IsNullOrEmpty(drinkOrderedIn))
            {
                TempData["error"] = "One or more blank fields was entered. Please Try Again";
                return View("Index");
            }
            ViewData["SpotInLine"] = (_context.Orders.IndexOf(_context.Orders.FirstOrDefault(o => o.OrderName == nameIn && o.DrinkOrdered == drinkOrderedIn))) - 1;


            return View(_context.Orders.FirstOrDefault(o => o.OrderName.ToLower() == nameIn.ToLower() && o.DrinkOrdered.ToLower() == drinkOrderedIn.ToLower()));
        }

        public IActionResult BartenderLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BartenderLogin(string username, string password)
        {
            if(username == "Bartender" && password == "Login")
            {
                return RedirectToAction("BartenderList");
            }

            TempData["error"] = "U:Bartender P:Login";
            return View("BartenderLogin");
        } 

        // GET: Orders
        public IActionResult BartenderList()
        {
            BartenderListViewModel displayLists = new BartenderListViewModel
            {
                PendingOrders = _context.Orders.Where(o => o.Ready != true && o.PickedUp != true),
                ReadyOrders = _context.Orders.Where(o => o.Ready == true && o.PickedUp != true)
            };
            return View(displayLists);
        }

        [HttpGet]
        public async Task<IActionResult> Ready(int id)
        {
            Order orderReady = _context.Orders.FirstOrDefault(o => o.Id == id);

            orderReady.Ready = true;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException){
                if ((await _context.Orders.FirstOrDefaultAsync(o => o.Id == id)) == null)
                {
                    return NotFound();
                }
            }
            TempData["MethodResult"] = "The Order for " + orderReady.OrderName + " is ready.";
            return RedirectToAction("BartenderList");
        }
        
        [HttpGet]
        public async Task<IActionResult> PickedUp(int id)
        {
            Order pickedUpOrder = _context.Orders.FirstOrDefault(o => o.Id == id);

            pickedUpOrder.PickedUp = true;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException){
                if ((await _context.Orders.FirstOrDefaultAsync(o => o.Id == id)) == null)
                {
                    return NotFound();
                }
            }
            TempData["MethodResult"] = "The Order for " + pickedUpOrder.OrderName + " has been picked up.";
            return RedirectToAction("BartenderList");
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string drinkOrderedIn, string totalIn, string orderNameIn)
        {
            Order orderIn = new Order()
            {
                DrinkOrdered = drinkOrderedIn,
                Total = totalIn,
                OrderName = orderNameIn
            };

            if (ModelState.IsValid)
            {
                _context.Add(orderIn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            TempData["MethodResult"] = "Your order for a " + orderIn.DrinkOrdered + " under the name: " + orderIn.OrderName + " has been created.";
            return View(orderIn);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderName,DinkOrdered,Total")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
