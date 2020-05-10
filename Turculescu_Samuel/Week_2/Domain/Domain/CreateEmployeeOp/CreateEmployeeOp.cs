using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.CreateEmployeeOp.CreateEmployeeResult;

namespace Domain.Domain.CreateEmployeeOp
{
    public class CreateEmployeeOp : OpInterpreter<CreateEmployeeCmd, CreateEmployeeResult.ICreateEmployeeResult, Unit>
    {
        public override Task<ICreateEmployeeResult> Work(CreateEmployeeCmd Op, Unit state)
        {
            Employee newEmployee = new Employee(Op.FirstName, Op.LastName, Op.Email, Op.Phone, Op.IdEmployee, Op.Restaurant);
            // Validate
            return !Exists(Op.Restaurant.EmployeesList, newEmployee) ?
                Task.FromResult<ICreateEmployeeResult>(new EmployeeNotCreated("Employee already is hired!")) :
                Task.FromResult<ICreateEmployeeResult>(new EmployeeCreated(newEmployee));
        }


        public bool Exists(List<Employee> employeesList, Employee employee)
        {
            if (employeesList.Contains(employee))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
