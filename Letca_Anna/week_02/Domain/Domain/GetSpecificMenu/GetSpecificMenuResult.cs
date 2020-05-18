using System;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;
using Persistence.EfCore;
using System.Collections.Generic;


namespace Domain.Domain.GetSpecificMenu
{
    [AsChoice]
    public static partial class GetSpecificMenuResult
    {
        public interface IGetSpecificMenuResult { }

        public class SpecificMenuFound : IGetSpecificMenuResult
        {
            public Menus Menu { get; }

            public SpecificMenuFound(Menus menu)
            {
                Menu = menu;
            }
        }


        public class SpecificMenuNotFound : IGetSpecificMenuResult
        {
            public string Reason { get; }

            public SpecificMenuNotFound(string reason)
            {
                Reason = reason;
            }
        }
    }
}
