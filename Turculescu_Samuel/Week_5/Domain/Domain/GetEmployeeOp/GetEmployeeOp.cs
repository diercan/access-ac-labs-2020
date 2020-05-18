using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.GetEmployeeOp.GetEmployeeResult;

namespace Domain.Domain.GetEmployeeOp
{
    public class GetEmployeeOp : OpInterpreter<GetEmployeeCmd, GetEmployeeResult.IGetEmployeeResult, Unit>
    {
        public override Task<IGetEmployeeResult> Work(GetEmployeeCmd Op, Unit state)
        {
           return (Op.Employee is null) ?
                Task.FromResult<IGetEmployeeResult>(new EmployeeNotFound("Employee not found!")) :
                Task.FromResult<IGetEmployeeResult>(new EmployeeFound(new EmployeeAgg(Op.Employee)));
        }
    }
}
