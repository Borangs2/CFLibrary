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
    public class LibraryBooksController : Controller
    {
        private readonly LibraryContext _context;

        public LibraryBooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: LibraryBooks
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.LibraryBooks.Include(l => l.Book).Include(l => l.Library);
            return View(await libraryContext.ToListAsync());
        }

        // GET: LibraryBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryBooks = await _context.LibraryBooks
                .Include(l => l.Book)
                .Include(l => l.Library)
                .FirstOrDefaultAsync(m => m.LibraryId == id);
            if (libraryBooks == null)
            {
                return NotFound();
            }

            return View(libraryBooks);
        }

        // GET: LibraryBooks/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Book, "BookId", "Title");
            ViewData["LibraryId"] = new SelectList(_context.Library, "LibraryId", "City");
            return View();
        }

        // POST: LibraryBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LibraryId,BookId")] LibraryBooks libraryBooks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libraryBooks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Book, "BookId", "Title", libraryBooks.BookId);
            ViewData["LibraryId"] = new SelectList(_context.Library, "LibraryId", "City", libraryBooks.LibraryId);
            return View(libraryBooks);
        }

        // GET: LibraryBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryBooks = await _context.LibraryBooks.FindAsync(id);
            if (libraryBooks == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Book, "BookId", "Title", libraryBooks.BookId);
            ViewData["LibraryId"] = new SelectList(_context.Library, "LibraryId", "City", libraryBooks.LibraryId);
            return View(libraryBooks);
        }

        // POST: LibraryBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LibraryId,BookId")] LibraryBooks libraryBooks)
        {
            if (id != libraryBooks.LibraryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libraryBooks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraryBooksExists(libraryBooks.LibraryId))
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
            ViewData["BookId"] = new SelectList(_context.Book, "BookId", "Title", libraryBooks.BookId);
            ViewData["LibraryId"] = new SelectList(_context.Library, "LibraryId", "City", libraryBooks.LibraryId);
            return View(libraryBooks);
        }

        // GET: LibraryBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryBooks = await _context.LibraryBooks
                .Include(l => l.Book)
                .Include(l => l.Library)
                .FirstOrDefaultAsync(m => m.LibraryId == id);
            if (libraryBooks == null)
            {
                return NotFound();
            }

            return View(libraryBooks);
        }

        // POST: LibraryBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libraryBooks = await _context.LibraryBooks.FindAsync(id);
            _context.LibraryBooks.Remove(libraryBooks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibraryBooksExists(int id)
        {
            return _context.LibraryBooks.Any(e => e.LibraryId == id);
        }
    }
}
