using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Infrasctructure;
using CRUD.Models;

namespace CRUD.Services
{
    public class EmployeeService
    {
        private EmployeeRepository _repo;

        public EmployeeService(EmployeeRepository repo)
        {
            _repo = repo;
        }
      public IList<Employee> GetEmployees()
        {
            return _repo.List().ToList();
        }

        public Employee FindEmployee(int id)
        {
            return _repo.Find(id);
        }

        public IList<MinEmployee> GetMinifiedEmployees()
        {
            var employees = _repo.List();
            return (from e in employees
                    select new MinEmployee
                    {
                        Id = e.Id,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Email = e.Email

                    }).ToList();
        }

        public void AddEmployee(Employee emp)
        {
            _repo.Add(emp);
            _repo.SaveChanges();
        }

        public void UpdateEmployees(Employee emp)
        {
            _repo.Update(emp);
            _repo.SaveChanges();
            
        }

        public void DeleteEmployee(int id)
        {
            var emp = _repo.Find(id);
            _repo.Delete(emp);
            _repo.SaveChanges();
        }

    }
}
