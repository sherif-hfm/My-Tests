using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MVCBasics.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            Person fatherPerson = new Person() { PersonId = 1, PersonName = "Hamdy", Country = new Country() { CountryId = 1, CountryName = "Town1" } };
            Person motherPerson = new Person() { PersonId = 2, PersonName = "Mam", Country = new Country() { CountryId = 2, CountryName = "Town2" } };
            
            MVCBasicsCnn cnn = new MVCBasicsCnn();
            var persons = from p in cnn.Persons select p;
            
            List<Person> PersonList = new List<Person>();
            foreach (var dbPerson in persons)
            {
                Person person = new Person() { PersonId = dbPerson.PersonId, PersonName = dbPerson.PersonName, CountryId = dbPerson.Countries.CountryId, Country = new Country() { CountryId = dbPerson.Countries.CountryId, CountryName = dbPerson.Countries.CountryName } };
                PersonList.Add(person);
            }
            ViewBag.PersonList = PersonList;
            ViewBag.Address = "My Address";
            ViewBag.Mam = motherPerson;

            return View(fatherPerson);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVCBasicsCnn cnn = new MVCBasicsCnn();
            var dbPersons = cnn.Persons.Where(p => p.PersonId == id);
            if (dbPersons.Count() > 0)
            {
                var dbPerson = dbPersons.First();
                Person person = new Person() { PersonId = dbPerson.PersonId, PersonName = dbPerson.PersonName, CountryId = dbPerson.Countries.CountryId, Country = new Country() { CountryId = dbPerson.Countries.CountryId, CountryName = dbPerson.Countries.CountryName } };
                List<Country> countries = new List<Country>();
                foreach (var dbCountry in cnn.Countries)
                {
                    Country country = new Country() { CountryId = dbCountry.CountryId, CountryName = dbCountry.CountryName };
                    countries.Add(country);
                }
                ViewBag.Countries = countries;
                //ModelState.AddModelError("PersonName", "What a terrible name!"); // Add Validation Error Message
                //ModelState.AddModelError("", "What a terrible name!"); // Add Validation Error Message to Summary
                return View(person);
            }
                
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,PersonName,CountryId,PersonAge,UserLogin")]Person _person)
        {
            //ModelState.IsValidField("PersonName") == false;
            //ModelState["PersonName"].Errors.Count > 0;
            if (ModelState.IsValid)
            {
                Person person = new Person();
                // invokes model binding
                this.UpdateModel(person);
                //this.UpdateModel(person, new[] { "PersonId,PersonName,CountryId"});
                //this.TryUpdateModel(person);

                MVCBasicsCnn cnn = new MVCBasicsCnn();
                var dbPersons = cnn.Persons.Where(p => p.PersonId == _person.PersonId);
                if (dbPersons.Count() > 0)
                {
                    var dbPerson = dbPersons.First();
                    dbPerson.PersonName = _person.PersonName;
                    dbPerson.CountryId = _person.CountryId;
                    cnn.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
                return Edit(_person.PersonId);
             
        }

        public ActionResult Search()
        {
            List<Person> PersonList = new List<Person>();
            ViewBag.PersonList = PersonList;
            return View();
        }

        [HttpPost]
        public ActionResult Search(string personName)
        {

            MVCBasicsCnn cnn = new MVCBasicsCnn();
            var persons = from p in cnn.Persons where p.PersonName.StartsWith(personName) select p;

            List<Person> PersonList = new List<Person>();
            foreach (var dbPerson in persons)
            {
                Person person = new Person() { PersonId = dbPerson.PersonId, PersonName = dbPerson.PersonName, CountryId = dbPerson.Countries.CountryId, Country = new Country() { CountryId = dbPerson.Countries.CountryId, CountryName = dbPerson.Countries.CountryName } };
                PersonList.Add(person);
            }
            ViewBag.PersonList = PersonList;
            return View();
        }

        public ActionResult PersonStatus()
        {

            MVCBasicsCnn cnn = new MVCBasicsCnn();
            var persons = from p in cnn.Persons select p;

            List<Person> PersonList = new List<Person>();
            foreach (var dbPerson in persons)
            {
                Person person = new Person() { PersonId = dbPerson.PersonId, PersonName = dbPerson.PersonName, CountryId = dbPerson.Countries.CountryId, Country = new Country() { CountryId = dbPerson.Countries.CountryId, CountryName = dbPerson.Countries.CountryName } };
                PersonList.Add(person);
            }
            
            ViewBag.PersonList = PersonList;
            var asd = PersonList[0];

            return View(PersonList);
        }

        [HttpPost]
        public ActionResult PersonStatus(ICollection<Person> _person)
        {
            if (ModelState.IsValid)
            { }
            return PersonStatus();
        }
        
        public JsonResult CheckUserLogin(string UserLogin)
        {
            var result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult New()
        {
            MVCBasicsCnn cnn = new MVCBasicsCnn();
            List<Country> countries = new List<Country>();
            foreach (var dbCountry in cnn.Countries)
            {
                Country country = new Country() { CountryId = dbCountry.CountryId, CountryName = dbCountry.CountryName };
                countries.Add(country);
            }
            ViewBag.Countries = countries;
            return View();
        }

        [HttpPost]
        public ActionResult SaveNew(Person _person)
        {
            MVCBasicsCnn cnn = new MVCBasicsCnn();
            List<Country> countries = new List<Country>();
            foreach (var dbCountry in cnn.Countries)
            {
                Country country = new Country() { CountryId = dbCountry.CountryId, CountryName = dbCountry.CountryName };
                countries.Add(country);
            }
            ViewBag.Countries = countries;
            return View("New", _person);
        }
    }
}