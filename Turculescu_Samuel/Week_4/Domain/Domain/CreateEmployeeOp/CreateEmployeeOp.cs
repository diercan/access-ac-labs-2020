using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using Persistence.EfCore;
using static Domain.Domain.CreateEmployeeOp.CreateEmployeeResult;

namespace Domain.Domain.CreateEmployeeOp
{
    public class CreateEmployeeOp : OpInterpreter<CreateEmployeeCmd, CreateEmployeeResult.ICreateEmployeeResult, Unit>
    {
        public override Task<ICreateEmployeeResult> Work(CreateEmployeeCmd Op, Unit state)
        {
            EmployeeAgg newEmployee = new EmployeeAgg(new Employee { FirstName = Op.FirstName, LastName = Op.LastName, Email = Op.Email, Phone = Op.Phone, Job = Op.Job, Username = Op.Username, Password = Op.Password, RestaurantId = Op.RestaurantId });
            // Validate
            //return !Exists(Op.Restaurant.EmployeesList, newEmployee) ?
              //  Task.FromResult<ICreateEmployeeResult>(new EmployeeNotCreated("Employee already is hired!")) :
                return Task.FromResult<ICreateEmployeeResult>(new EmployeeCreated(newEmployee));
        }


        public bool Exists(List<EmployeeAgg> employeesList, EmployeeAgg employee)
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
