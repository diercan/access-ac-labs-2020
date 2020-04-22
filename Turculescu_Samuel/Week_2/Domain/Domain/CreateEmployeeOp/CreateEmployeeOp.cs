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
            // Validate

            return !Exists(Op.IdEmployee) ?
                Task.FromResult<ICreateEmployeeResult>(new EmployeeNotCreated("Employee already is hired!")) :
                Task.FromResult<ICreateEmployeeResult>(new EmployeeCreated(new Employee(Op.FirstName, Op.LastName, Op.Email, Op.Phone, Op.IdEmployee)));
        }


        public bool Exists(string idEmployee)
        {
            return true;
        }
    }
}
