using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Abstractions
{
    public class GetCmd<T>
    {
        public Func<T,bool> Expression { get; }

        public GetCmd(Func<T,bool> expression)
        {
            Expression = expression;
        }
    }
}
