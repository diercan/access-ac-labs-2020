using System;
using System.Collections.Generic;
using System.Text;
using Domain.Domain;

namespace Domain.Domain.CreateIngredientOp
{
    public struct CreateIngredientCmd
    {
        public string Name { get; }

        public CreateIngredientCmd(string name)
        {
            Name = name;
        }
    }
}
