using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CFLibrary.Models;

namespace CFLibrary.Controllers
{
    public class BookBorrowsController : Controller
    {
        private readonly LibraryContext _context;

        public BookBorrowsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: BookBorrows
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.BookBorrow.Include(b => b.Book).Include(b => b.User);
            return View(await libraryContext.ToListAsync());
        }

        // GET: BookBorrows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookBorrow = await _context.BookBorrow
                .Include(b => b.Book)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (bookBorrow == null)
            {
                return NotFound();
            }

            return View(bookBorrow);
        }

        // GET: BookBorrows/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Book, "BookId", "Title");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "FirstName");
            return View();
        }

        // POST: BookBorrows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,BookId,ReturnDate")] BookBorrow bookBorrow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookBorrow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Book, "BookId", "Title", bookBorrow.BookId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "FirstName", bookBorrow.UserId);
            return View(bookBorrow);
        }

        // GET: BookBorrows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookBorrow = await _context.BookBorrow.FindAsync(id);
            if (bookBorrow == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Book, "BookId", "Title", bookBorrow.BookId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "FirstName", bookBorrow.UserId);
            return View(bookBorrow);
        }

        // POST: BookBorrows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,BookId,ReturnDate")] BookBorrow bookBorrow)
        {
            if (id != bookBorrow.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookBorrow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookBorrowExists(bookBorrow.UserId))
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
            ViewData["BookId"] = new SelectList(_context.Book, "BookId", "Title", bookBorrow.BookId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "FirstName", bookBorrow.UserId);
            return View(bookBorrow);
        }

        // GET: BookBorrows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookBorrow = await _context.BookBorrow
                .Include(b => b.Book)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (bookBorrow == null)
            {
                return NotFound();
            }

            return View(bookBorrow);
        }

        // POST: BookBorrows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookBorrow = await _context.BookBorrow.FindAsync(id);
            _context.BookBorrow.Remove(bookBorrow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookBorrowExists(int id)
        {
            return _context.BookBorrow.Any(e => e.UserId == id);
        }
    }
}
