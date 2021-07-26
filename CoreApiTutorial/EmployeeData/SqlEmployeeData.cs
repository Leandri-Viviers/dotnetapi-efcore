using CoreApiTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreApiTutorial.EmployeeData
{
    public class SqlEmployeeData : IEmployeeData
    {
        private EmployeeContext employeeContext;
        public SqlEmployeeData(EmployeeContext context)
        {
            employeeContext = context;
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employeeContext.Employees.Add(employee);
            employeeContext.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employeeContext.Employees.Remove(employee);
            employeeContext.SaveChanges();
        }

        public Employee GetEmployee(Guid id)
        {
            var employee = employeeContext.Employees.Find(id);
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return employeeContext.Employees.ToList();
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var result = GetEmployee(employee.Id);
            if(result != null)
            {
                result.Name = employee.Name;
                employeeContext.Employees.Update(result);
                employeeContext.SaveChanges();
            }
            return employee;
        }
    }
}
