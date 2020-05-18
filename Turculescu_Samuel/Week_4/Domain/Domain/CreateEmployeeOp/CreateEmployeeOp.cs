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
            // Validate
            //if (Exists(Op.RestaurantId, Op.EmployeeId))
            //{
            //    return Task.FromResult<ICreateEmployeeResult>(new EmployeeNotCreated("Employee already is hired!"));
            //}
            //else
            //{
                EmployeeAgg newEmployee = new EmployeeAgg(new Employee { FirstName = Op.FirstName, LastName = Op.LastName, Email = Op.Email, Phone = Op.Phone, Job = Op.Job, EmployeeId = Op.EmployeeId, Password = Op.Password, RestaurantId = Op.RestaurantId });
                return Task.FromResult<ICreateEmployeeResult>(new EmployeeCreated(newEmployee));
            //}
            
        }


        public bool Exists(int restaurantId, string employeeId)
        {
            if (RestaurantDomainEx.GetEmployee(restaurantId, employeeId) is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
