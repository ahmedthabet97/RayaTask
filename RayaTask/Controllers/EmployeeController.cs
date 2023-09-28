using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RayaTask.Interface;
using RayaTask.ViewModels;

namespace RayaTask.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo employeeRepo;

        public EmployeeController(IEmployeeRepo employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }
        public IActionResult Index()
        {

            var employees = employeeRepo.GetAll();
            ViewBag.Employees = employees;
            return View();
        }
        [HttpPost]
        //data: { Id: id, Name: name, Salary: salary, Job: job, Email: email,IsApproved:isApproved },
        [Authorize(Roles = "HRAdmin")]
        public IActionResult Edit(string Id, string Name, string Salary, string Job, string Email, string IsApproved)
        {
            if (ModelState.IsValid == false)
            {
                var errors =
                    ModelState.SelectMany(i => i.Value.Errors.Select(x => x.ErrorMessage));

                foreach (string err in errors)
                {
                    ModelState.AddModelError("", err);
                }

                return View("Index");
            }
            else
            {
                EmployeeVM employee = new EmployeeVM()
                {
                    Id = int.Parse(Id),
                    Name = Name,
                    Email = Email,
                    Job = Job,
                    Salary = double.Parse(Salary),
                    IsApproved = (int.Parse(IsApproved) == 0) ? false : true
                };
                employeeRepo.EditEmployee(employee);
                return Redirect("Index");
            }
        }

        [HttpPost]
        //        data: {  Name: nameNew, Salary: salaryNew, Job: jobNew, Email: emailNew},

        public IActionResult Add(string Name, string Salary, string Job, string Email)
        {
            if (ModelState.IsValid == false)
            {
                var errors =
                    ModelState.SelectMany(i => i.Value.Errors.Select(x => x.ErrorMessage));

                foreach (string err in errors)
                {
                    ModelState.AddModelError("", err);
                }

                return View("Index");
            }
            else
            {
                EmployeeVM employee = new EmployeeVM()
                {
                    Name = Name,
                    Email = Email,
                    Job = Job,
                    Salary = double.Parse(Salary),
                };
                employeeRepo.AddEmployee(employee);
                return Redirect("Index");
            }
        }
        [Authorize(Roles = "HRAdmin")]
        public IActionResult Delete(int Id)
        {
            employeeRepo.DeleteEmployee(Id);
            return Redirect("Index");
        }
        public IActionResult Filter(EmployeeVM emp)
        {
            var res = employeeRepo.Filter(emp);
            ViewBag.Employees = res;
            return View("Index");
        }
    }
}
