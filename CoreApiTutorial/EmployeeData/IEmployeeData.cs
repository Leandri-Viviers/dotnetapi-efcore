using CoreApiTutorial.Models;
using System;
using System.Collections.Generic;

namespace CoreApiTutorial.EmployeeData
{
    public interface IEmployeeData
    {
        List<Employee> GetEmployees();

        Employee GetEmployee(Guid id);

        Employee AddEmployee(Employee employee);

        void DeleteEmployee(Employee employee);

        Employee UpdateEmployee(Employee employee);
    }
}
