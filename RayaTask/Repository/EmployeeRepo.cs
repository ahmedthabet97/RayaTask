using Domain;
using Microsoft.EntityFrameworkCore;
using RayaTask.Interface;
using RayaTask.ViewModels;
using System.Collections.Generic;

namespace RayaTask.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly RayaContext context;
        public EmployeeRepo(RayaContext _context)
        {
            this.context = _context;
        }
        public void AddEmployee(EmployeeVM employee)
        {
            var emp = new Employee() 
            {
                Name = employee.Name,
                Salary = employee.Salary,
                Email = employee.Email,
                Job= employee.Job,
                IsApporved = employee.IsApproved

            };
            context.Employees.Add(emp);
            context.SaveChanges();
        }

       public void DeleteEmployee(int id)
        {
            var emp = context.Employees.Where(e => e.Id == id ).FirstOrDefault();
            context.Employees.Remove(emp);
            context.SaveChanges();
        }

        public void EditEmployee(EmployeeVM employee)
        {
            var Emp = context.Employees.Where(e => e.Id == employee.Id).FirstOrDefault();
           
            Emp.Name = employee.Name;
            Emp.Email = employee.Email;
            Emp.IsApporved = employee.IsApproved;
            Emp.Job = employee.Job;
            Emp.Salary = employee.Salary;
            context.SaveChanges();


        }

       public IEnumerable<EmployeeVM> GetAll()
        {
            //IEnumerable<EmployeeVM> employees = new IList<EmployeeVM>();
            IEnumerable<EmployeeVM> employees = context.Employees.Select(Emp=> new EmployeeVM()
            {
                Email = Emp.Email,
                Name = Emp.Name,
                Job = Emp.Job,
                Salary = Emp.Salary,
                IsApproved = Emp.IsApporved,
                Id =Emp.Id

            });
            return employees;
           
        }
        public IEnumerable<EmployeeVM> Filter(EmployeeVM model)
        {
            List<EmployeeVM> emps = new List<EmployeeVM>();

            IEnumerable<Employee> res = context.Employees.Select(emp=>emp)
                            .Where(e => model.Name == null || e.Name.ToLower().Contains(model.Name.ToLower()))
                .Where(e => model.Salary == 0 || e.Salary == model.Salary)
                .Where(e => model.Email == null || e.Email.ToLower().Contains(model.Email.ToLower()))
           ;
            foreach (var em in res)
            {
                var e = new EmployeeVM()
                {
                    Email = em.Email,
                    Name = em.Name,
                    Salary = em.Salary,
                    IsApproved = em.IsApporved,
                    Job= em.Job,
                    Id=em.Id
                };
                emps.Add(e);
                
            }
            return emps;
        }
        public EmployeeVM GetEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
