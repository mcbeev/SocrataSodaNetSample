using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WebApplication.Models;
using WebApplication.Helpers;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult Index(string SortOrder, string CurrentFilter, string SearchQuery, int? CurrentPage)
        {
            int pageSize = 25;
            int pageNumber = (CurrentPage ?? 1);

            ViewBag.CurrentSort = SortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(SortOrder) ? "name_desc" : "Name";
            ViewBag.DBASortParm = String.IsNullOrEmpty(SortOrder) ? "dba_desc" : "DBA";

            //TODO: sorting

            if (!string.IsNullOrEmpty(SearchQuery))
            {
                CurrentPage = 1;
            }
            else
            {
                SearchQuery = CurrentFilter;
            }

            ViewBag.CurrentFilter = SearchQuery;

            if (!string.IsNullOrEmpty(SearchQuery))
            {
                string cleanQuery = SearchQuery.ToUpper().Trim();
                var bigData = SODAHelper.GetBusinessLocations(SearchQuery, pageNumber, pageSize);
                return View(bigData); 
            }
            else
            {
                var bigData = SODAHelper.GetBusinessLocations(pageNumber, pageSize);
                return View(bigData);
            }

            
        }

        //public ViewResult Index(string SortOrder, string CurrentFilter, string SearchQuery, int ? CurrentPage)
        //{
        //    ViewBag.CurrentSort = SortOrder;
        //    ViewBag.FirstNameSortParm = String.IsNullOrEmpty(SortOrder) ? "firstname_desc" : "First";
        //    ViewBag.LastNameSortParm = String.IsNullOrEmpty(SortOrder) ? "lastname_desc" : "Last";
        //    ViewBag.DateSortParm = SortOrder == "Date" ? "date_desc" : "Date";

        //    var studentRepo = new List<Student> { 
        //        new Student(){ FirstName="Brian", LastName="McKeiver", Age=34, EnrolledOn=DateTime.Now},
        //        new Student(){ FirstName="Mark", LastName="Schmidt", Age=35, EnrolledOn=DateTime.Now},
        //        new Student(){ FirstName="Tim", LastName="Stauffer", Age=30, EnrolledOn=DateTime.Now},
        //        new Student(){ FirstName="Audrey", LastName="McKeiver", Age=7, EnrolledOn=DateTime.Now},
        //        new Student(){ FirstName="Josh", LastName="Schmidt", Age=35, EnrolledOn=DateTime.Now},
        //        new Student(){ FirstName="Riley", LastName="McKeiver", Age=4, EnrolledOn=DateTime.Now},
        //        new Student(){ FirstName="Anne", LastName="McKeiver", Age=35, EnrolledOn=DateTime.Now},
        //        new Student(){ FirstName="Mark", LastName="Schmidt", Age=25, EnrolledOn=DateTime.Now},
        //        new Student(){ FirstName="Tim", LastName="Reece", Age=10, EnrolledOn=DateTime.Now},
        //        new Student(){ FirstName="Maggie", LastName="McKeiver", Age=9, EnrolledOn=DateTime.Now},
        //        new Student(){ FirstName="Mark", LastName="Schmidt", Age=19, EnrolledOn=DateTime.Now},
        //        new Student(){ FirstName="Tim", LastName="Trench", Age=56, EnrolledOn=DateTime.Now}
        //    };

        //    if (!string.IsNullOrEmpty(SearchQuery))
        //    {
        //        CurrentPage = 1;
        //    }
        //    else
        //    {
        //        SearchQuery = CurrentFilter;
        //    }

        //    ViewBag.CurrentFilter = SearchQuery;

        //    var students = from s in studentRepo
        //                   select s;

        //    if(!string.IsNullOrEmpty(SearchQuery))
        //    {
        //        string cleanQuery = SearchQuery.ToUpper().Trim();
        //        students = students.Where(s => s.LastName.ToUpper().Contains(cleanQuery) || s.FirstName.ToUpper().Contains(cleanQuery));
        //    }

        //    switch (SortOrder)
        //    {
        //        case "First":
        //            students = students.OrderBy(s => s.FirstName);
        //            break;
        //        case "firstname_desc":
        //            students = students.OrderByDescending(s => s.FirstName);
        //            break;
        //        case "lastname_desc":
        //            students = students.OrderByDescending(s => s.LastName);
        //            break;
        //        case "Date":
        //            students = students.OrderBy(s => s.EnrolledOn);
        //            break;
        //        case "date_desc":
        //            students = students.OrderByDescending(s => s.EnrolledOn);
        //            break;
        //        default:
        //            students = students.OrderBy(s => s.LastName);
        //            break;
        //    }

        //    int pageSize = 5;
        //    int pageNumber = (CurrentPage ?? 1);
        //    return View(students.ToPagedList(pageNumber, pageSize));

        //}

        public ActionResult About()
        {
            ViewBag.Message = "A Sample Application designed to show SODA.Net";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


    }
}