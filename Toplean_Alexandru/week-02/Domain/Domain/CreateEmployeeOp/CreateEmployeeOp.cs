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
            return Exists(Op.Name) ?
                Task.FromResult<ICreateEmployeeResult>(new EmployeeNotCreated(EmployeeErrorCode.NameExists)) : // Employee already exists
                EmptyField(Op.Name) ? Task.FromResult<ICreateEmployeeResult>(new EmployeeNotCreated(EmployeeErrorCode.EmptyField)) : // Empty String - Name
                EmptyField(Op.Salary.ToString()) ? Task.FromResult<ICreateEmployeeResult>(new EmployeeNotCreated(EmployeeErrorCode.EmptyField)) : // Empty String - Salary
                EmptyField(Op.TelephoneNumber) ? Task.FromResult<ICreateEmployeeResult>(new EmployeeNotCreated(EmployeeErrorCode.EmptyField)) : // Empty Strinng - Telephone
                EmptyField(Op.IBAN) ? Task.FromResult<ICreateEmployeeResult>(new EmployeeNotCreated(EmployeeErrorCode.EmptyField)) : // Empty String - IBAN
                IncorectInputType(Op.Salary, typeof(float)) ? Task.FromResult<ICreateEmployeeResult>(new EmployeeNotCreated(EmployeeErrorCode.IncorrectInputType)) : // Salary value other than float
                 Task.FromResult<ICreateEmployeeResult>(new EmployeeCreated(new Models.Employee(Op.Name, Op.Age, Op.Address, Op.TelephoneNumber, Op.Salary, Op.JobRole, Op.IBAN), Op.Restaurant)); // Employee created
        }

        public bool Exists(string name) => AllHardcodedValues.HarcodedVals.Employees.Contains(name) ? true : false; // Name exists in the AllHardcodedValues class

        public bool IncorectInputType(dynamic value, Type expectedType) => value.GetType() != expectedType ? true : false;  // Checks if a variable is the correct type

        public bool EmptyField(String name) => name.Length > 0 ? false : true; // Checks if a field is empty
    }
}