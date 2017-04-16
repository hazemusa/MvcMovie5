using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;
using MvcMovie.Services;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: /Movies/
        public ActionResult Index(string sortOrder, string movieGenre, string searchString, string CurrentFilter, string movieRating)
        {
            // set current sort order

            ViewBag.TitleSortParam = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.GenreSortParam = sortOrder == "genre" ? "genre_desc" : "genre";
            ViewBag.DateSortParam = sortOrder == "date" ? "date_desc" : "date";
            ViewBag.PriceSortParam = sortOrder == "price" ? "price_desc" : "price";
            ViewBag.RatingSortParam = sortOrder == "rating" ? "rating_desc" : "rating";

            ViewBag.CurrentFilter = String.IsNullOrEmpty(searchString) ? CurrentFilter : searchString;
            ViewBag.SelectedGenre = String.IsNullOrEmpty(movieGenre) ? "" : movieGenre;
            ViewBag.SelectedRating = String.IsNullOrEmpty(movieRating) ? "" : movieRating;
            ViewBag.CurrentSort = sortOrder;
            var GenreLst = new List<string>();


            var movies = _movieService.GetAllMovies();
            var GenreQry = from d in movies
                           orderby d.Genre
                           select d.Genre;
            GenreLst.AddRange(GenreQry.Distinct());

            var RatingLst = new List<string>();
            var RatingQry = from d in movies
                            orderby d.Rating
                            select d.Rating;
            RatingLst.AddRange(RatingQry.Distinct());
            ViewBag.movieRating = new SelectList(RatingLst);

            ViewBag.movieGenre = new SelectList(GenreLst);

            if (!String.IsNullOrEmpty(ViewBag.CurrentFilter))
            {
                movies = movies.Where(s => s.Title.ToLower().Contains(ViewBag.CurrentFilter));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            if (!string.IsNullOrEmpty(movieRating))
            {
                movies = movies.Where(x => x.Rating == movieRating);
            }

            switch (sortOrder)
            {
                case "title_desc":
                    movies = movies.OrderByDescending(s => s.Title);
                    ViewBag.className = "glyphicon glyphicon-triangle-down";
                    break;
                case "genre":
                    movies = movies.OrderBy(s => s.Genre);
                    break;
                case "genre_desc":
                    movies = movies.OrderByDescending(s => s.Genre);
                    ViewBag.className = "glyphicon glyphicon-triangle-down";
                    break;
                case "date":
                    movies = movies.OrderBy(s => s.ReleaseDate);
                    break;
                case "date_desc":
                    movies = movies.OrderByDescending(s => s.ReleaseDate);
                    break;
                case "Price":
                    movies = movies.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    movies = movies.OrderByDescending(s => s.Price);
                    break;
                case "rating":
                    movies = movies.OrderBy(s => s.Rating);
                    break;
                case "rating_desc":
                    movies = movies.OrderByDescending(s => s.Rating);
                    break;
                default:
                    movies = movies.OrderBy(s => s.Title);
                    break;
            }
            return View(movies);
        }

        /*
MovieDBContext db = new MovieDBContext();
Movie movie = new Movie();
movie.Title = "Gone with the Wind";
db.Movies.Add(movie);
db.SaveChanges();        // <= Will throw server side validation exception  
         * */

        // GET: /Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        public ActionResult Sort(string sortType)
        {
            return View();
        }

        // GET: /Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: /Movies/Create
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Genre,Price,Rating,movieImage")] Movie movie)
        {
            if (ModelState.IsValid)
            {


                _movieService.CreateMovie(movie);
                return RedirectToAction("Index");
            }

            return View(movie);
        }
        /*
public ActionResult Create()
{
    return View();
}

 */
        // POST: /Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
[ValidateAntiForgeryToken]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: /Movies/Edit/5
        // POST: /Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Genre,Price,Rating,movieImage")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieService.EditMovie(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }


        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }



        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _movieService.DeleteMovie(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
