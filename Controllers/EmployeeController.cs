using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MvcCrud.Data;
using MvcCrud.Models;
using System.Linq;

namespace MvcCrud.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext context;

        public EmployeeController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.Employees.ToList();
            return View(result);
        }
        public IActionResult Create(Employee model)

        {
            if (ModelState.IsValid)
            {
                var emp = new Employee()
                {
                    Name = model.Name,
                    Age = model.Age,
                    Dept = model.Dept,
                    Salary = model.Salary,
                };
                context.Employees.Add(emp);
                context.SaveChanges();
                TempData["error"] = "Record Saved!";
                return RedirectToAction("Index");
                //return View();
            }
            else
            {
                TempData["message"] = "Empty fields cannot submit";
                return View(model);
            }
        }
        public IActionResult Delete(int id)
        {
            var emp = context.Employees.SingleOrDefault(e => e.id == id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            TempData["error"] = "Record Deleted!";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id) {
            var emp = context.Employees.SingleOrDefault(e => e.id == id);

            var result = new Employee()
            {
            Name=emp.Name,
            Age=emp.Age,
            Dept=emp.Dept,
            Salary=emp.Salary,

            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            var emp = new Employee()
            {
                id=model.id,
                Name = model.Name,
                Age = model.Age,
                Dept=model.Dept,
                Salary=model.Salary,
            };
            context.Employees.Update(emp);
            context.SaveChanges();
            TempData["error"] = "Record Updated!";
            return RedirectToAction("Index");
        }
	}
}