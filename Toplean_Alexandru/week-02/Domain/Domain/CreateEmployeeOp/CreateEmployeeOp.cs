using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.CreateEmployeeOp.CreateEmployeeResult;
using static Domain.Models.Employee;

namespace Domain.Domain.CreateEmployeeOp
{
    public class CreateEmployeeOp : OpInterpreter<CreateEmployeeCmd, ICreateEmployeeResult, Unit>
    {
        public override Task<ICreateEmployeeResult> Work(CreateEmployeeCmd Op, Unit state)
        {
            if (Exists(Op.Name))
                return Task.FromResult<ICreateEmployeeResult>(new EmployeeNotCreated($"There already is an employee with the name {Op.Name}")); // Employee already exists
            else
            {
                (bool CommandIsValid, String error) = Op.IsValid();

                if (CommandIsValid)
                {
                    // Adds the employee to the restaurant's employee list
                    Employee emp = new Employee(Op.Name, Op.Age, Op.Address, Op.TelephoneNumber, Op.Salary, Op.JobRole, Op.IBAN, Op.Restaurant);
                    Op.Restaurant.Employees.Add(emp);

                    return Task.FromResult<ICreateEmployeeResult>(new EmployeeCreated(emp));// Employee created
                }
                else
                    return Task.FromResult<ICreateEmployeeResult>(new EmployeeNotCreated(error)); // Employee not created
            }
        }

        public bool Exists(string name) => AllHardcodedValues.HarcodedVals.Employees.Contains(name) ? true : false; // Name exists in the AllHardcodedValues class
    }
}