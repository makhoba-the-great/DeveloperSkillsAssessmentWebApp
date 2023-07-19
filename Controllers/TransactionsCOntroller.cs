using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperSkillsAssessment.WebApp.Controllers
{
    public class TransactionsCOntroller : Controller
    {
        // GET: TransactionsCOntroller
        public ActionResult Index()
        {
            return View();
        }

        // GET: TransactionsCOntroller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TransactionsCOntroller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionsCOntroller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionsCOntroller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TransactionsCOntroller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionsCOntroller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransactionsCOntroller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
