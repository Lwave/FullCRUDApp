using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Data;
using CRUD.Models;

namespace CRUD.Infrasctructure
{
    public class EmployeeRepository : GenericRepository<Employee>
    {
        EmployeeRepository(ApplicationDbContext db) : base(db)
        {

        }
        public Employee Find(int id)
        {
            return (from e in _db.Employee where e.Id == id select e).FirstOrDefault();
        }
        public void Update(Employee emp)
        {
            var orig = Find(emp.Id);
                orig.FirstName = emp.FirstName;
                orig.LastName = emp.LastName;
                orig.Email = emp.Email;
                orig.SSN = emp.SSN;
                orig.HourlyWage = emp.HourlyWage;
                orig.Benefits = emp.Benefits;
            }
        }
    }
}
