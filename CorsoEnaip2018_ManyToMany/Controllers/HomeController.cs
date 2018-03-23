using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CorsoEnaip2018_ManyToMany.Models;
using Microsoft.EntityFrameworkCore;

namespace CorsoEnaip2018_ManyToMany.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var b1 = new Book { Id = 1, Title = "book 1" };
            var b2 = new Book { Id = 2, Title = "book 2" };
            var b3 = new Book { Id = 3, Title = "book 3" };
            _context.Books.AddRange(new[] { b1, b2, b3 });
            _context.SaveChanges();

            var a1 = new Author { Id = 1, Name = "Mario Rossi" };
            var a2 = new Author { Id = 2, Name = "Luigi Neri" };
            var a3 = new Author { Id = 3, Name = "Anna Gialli" };
            _context.Authors.AddRange(new[] { a1, a2, a3 });
            _context.SaveChanges();

            var a = _context.Authors.First(x => x.Id == 1);
            var ab1 = _context.Books.First(x => x.Id == 1);
            var ab2 = _context.Books.First(x => x.Id == 2);

            a.Books = new List<AuthorBook>
            {
                new AuthorBook { AuthorId = 1, BookId = 1 },
                new AuthorBook { AuthorId = 1, BookId = 2 },
            };

            _context.Authors.Update(a);
            _context.SaveChanges();

            var finalAuthor = _context.Authors
                .Include(x => x.Books)
                .First(x => x.Id == 1);

            var finalBook1 = _context.Books
                .Include(x => x.Authors)
                .First(x => x.Id == 1);

            var finalBook2 = _context.Books
                .Include(x => x.Authors)
                .First(x => x.Id == 2);

            ViewData["authors"] = _context.Authors.ToList();

            return View(finalBook1);
        }

        [HttpPost]
        public IActionResult Index(Book book)
        {
            return RedirectToAction(nameof(Index));
        }

        private static bool IfIdMatch(Author a)
        {
            return a.Id == 1;
        }
    }
}
