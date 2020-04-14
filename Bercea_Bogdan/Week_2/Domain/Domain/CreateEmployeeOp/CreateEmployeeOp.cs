using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.CreateEmployeeOp.CreateEmployeeResult;

namespace Domain.Domain.CreateEmployeeOp
{
    public class CreateEmployeeOp : OpInterpreter<CreateEmployeeCmd, ICreateEmployeeResult, Unit>
    {
        public override Task<ICreateEmployeeResult> Work(CreateEmployeeCmd Op, Unit state)
        {
        return Exist(Op.FirstName, Op.LastName) ?
            Task.FromResult<ICreateEmployeeResult>(new EmployeeNotCreated("This employee already exist")) :
            Task.FromResult<ICreateEmployeeResult>(new EmployeeCreated(
                new Employee("Mike", "Dean", 25, "London 5'th Street", 1000m, Gender.Male, Position.Manager,
                new Restaurant("Favorit"))));
        }

        private bool Exist(string firstName, string lastName)
        {
            return true;
        }
    }
}
