using CoreApiTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreApiTutorial.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>
        {
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Gojo Satoru"
            },
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Nanami Kento"
            }
        };

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(e => e.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var result = GetEmployee(employee.Id);
            result.Name = employee.Name;
            return result;
        }
    }
}
