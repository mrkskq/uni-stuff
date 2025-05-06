using Lab2A.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2A.Controllers
{
    public class EventController : Controller
    {
        private static List<EventModel> events = new List<EventModel>() {
            new EventModel {Id = 1, Ime = "Fudbal", Lokacija = "Skopje"},
            new EventModel {Id = 2, Ime = "Kosarka", Lokacija = "Ohrid"},
            new EventModel {Id = 3, Ime = "Odbojka", Lokacija = "Struga"}
        };
        public static int nextId = 3;
        // GET: Event
        public ActionResult Index()
        {
            return View(events);
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            var eventModel = events.FirstOrDefault(e => e.Id == id);
            if (eventModel == null)
            {
                return HttpNotFound();
            }
            return View(eventModel);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(EventModel eventModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    nextId++;
                    eventModel.Id = nextId;
                    events.Add(eventModel);
                }
                return RedirectToAction("Details", new { id = eventModel.Id });
            }
            catch
            {
                return View(eventModel);
            }
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            var eventModel = events.FirstOrDefault(e => e.Id == id);
            if (eventModel == null)
            {
                return HttpNotFound();
            }
            return View(eventModel);
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EventModel eventModel)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var existingEvent = events.FirstOrDefault(e => e.Id == eventModel.Id);
                    if (existingEvent != null)
                    {
                        existingEvent.Ime = eventModel.Ime;
                        existingEvent.Lokacija = eventModel.Lokacija;
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(eventModel);
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            var eventModel = events.FirstOrDefault(e => e.Id == id);
            if (eventModel == null)
            {
                return HttpNotFound();
            }
            events.Remove(eventModel);
            nextId--;
            return RedirectToAction("Index");
        }
    }
}
