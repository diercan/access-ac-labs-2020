using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetOp
{
    public class GetCmd<T>
    {
        public List<T> Items { get; }
        public Predicate<T> Expression { get; }

        public GetCmd(List<T> items, Predicate<T> expression)
        {
            Items = items;
            Expression = expression;
        }
    }
}
