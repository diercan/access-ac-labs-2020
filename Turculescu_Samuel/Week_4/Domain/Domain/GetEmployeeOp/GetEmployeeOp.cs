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
        private List<Employee>.Enumerator e;
        public override Task<IGetEmployeeResult> Work(GetEmployeeCmd Op, Unit state)
        {
            e = Op.Restaurant.EmployeesList.GetEnumerator();    // e is enumerator for EmployeesList from Restaurant

            // Validate

            return !Exists(Op.EmployeeId) ?
                Task.FromResult<IGetEmployeeResult>(new GetEmployeeNotSuccessful($"There is no client with this id: {Op.EmployeeId}!")) :
                Task.FromResult<IGetEmployeeResult>(new GetEmployeeSuccessful(e.Current));
        }

        // Verify if restaurant selected is opened or not
        public bool Exists(string employeeId)
        {
            while (e.MoveNext())
            {
                if (employeeId.CompareTo(e.Current.EmployeeId) == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
