﻿using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using static Domain.Models.Employee;

namespace Domain.Domain.CreateEmployeeOp
{
    [AsChoice]
    public static partial class CreateEmployeeResult
    {
        public class EmployeeCreated : ICreateEmployeeResult // Employee successfully created
        {
            public Employee Employee { get; }
            public Restaurant Restaurant { get; }

            public EmployeeCreated(Employee emp, Restaurant restaurant)
            {
                Employee = emp;
                Restaurant = restaurant;
            }
        }

        public class EmployeeNotCreated : ICreateEmployeeResult // Employee not created
        {
            public EmployeeErrorCode Error { get; }

            public EmployeeNotCreated(EmployeeErrorCode code)
            {
                Error = code;
            }
        }

        public interface ICreateEmployeeResult
        {
        }
    }
}