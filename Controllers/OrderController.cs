using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BiletApp.Data;
using BiletApp.Models;
using BiletApp.ViewModels;

namespace BiletApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Order
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .Include(o => o.Ticket)
                    .ThenInclude(t => t.Event)
                .ToListAsync();
            return View(orders);
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Ticket)
                    .ThenInclude(t => t.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            var viewModel = new OrderCreateViewModel
            {
                Tickets = _context.Tickets
                    .Include(t => t.Event)
                    .Select(t => new TicketInfo
                    {
                        Id = t.Id,
                        DisplayText = $"{t.Event.Name} - {t.TicketType} ({t.Price:C})",
                        Price = t.Price,
                        StockQuantity = t.StockQuantity
                    })
                    .ToList()
            };
            return View(viewModel);
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var ticket = await _context.Tickets.FindAsync(viewModel.TicketId);
                if (ticket == null)
                {
                    ModelState.AddModelError("TicketId", "Seçilen bilet bulunamadı.");
                    viewModel.Tickets = _context.Tickets
                        .Include(t => t.Event)
                        .Select(t => new TicketInfo
                        {
                            Id = t.Id,
                            DisplayText = $"{t.Event.Name} - {t.TicketType} ({t.Price:C})",
                            Price = t.Price,
                            StockQuantity = t.StockQuantity
                        })
                        .ToList();
                    return View(viewModel);
                }

                if (ticket.StockQuantity < viewModel.Quantity)
                {
                    ModelState.AddModelError("Quantity", $"Yeterli stok yok. Mevcut stok: {ticket.StockQuantity}");
                    viewModel.Tickets = _context.Tickets
                        .Include(t => t.Event)
                        .Select(t => new TicketInfo
                        {
                            Id = t.Id,
                            DisplayText = $"{t.Event.Name} - {t.TicketType} ({t.Price:C})",
                            Price = t.Price,
                            StockQuantity = t.StockQuantity
                        })
                        .ToList();
                    return View(viewModel);
                }

                var order = new Order
                {
                    CustomerName = viewModel.CustomerName,
                    CustomerEmail = viewModel.CustomerEmail,
                    CustomerPhone = viewModel.CustomerPhone,
                    Quantity = viewModel.Quantity,
                    TicketId = viewModel.TicketId,
                    TotalAmount = ticket.Price * viewModel.Quantity,
                    OrderDate = DateTime.Now
                };

                // Stok güncelleme
                ticket.StockQuantity -= viewModel.Quantity;

                _context.Add(order);
                _context.Update(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            viewModel.Tickets = _context.Tickets
                .Include(t => t.Event)
                .Select(t => new TicketInfo
                {
                    Id = t.Id,
                    DisplayText = $"{t.Event.Name} - {t.TicketType} ({t.Price:C})",
                    Price = t.Price,
                    StockQuantity = t.StockQuantity
                })
                .ToList();
            return View(viewModel);
        }

        // GET: Order/Edit/5
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

            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "TicketType", order.TicketId);
            return View(order);
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerName,CustomerEmail,CustomerPhone,Quantity,TotalAmount,OrderDate,TicketId")] Order order)
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
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "TicketType", order.TicketId);
            return View(order);
        }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Ticket)
                    .ThenInclude(t => t.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                // Stok geri ekleme
                var ticket = await _context.Tickets.FindAsync(order.TicketId);
                if (ticket != null)
                {
                    ticket.StockQuantity += order.Quantity;
                    _context.Update(ticket);
                }

                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}

