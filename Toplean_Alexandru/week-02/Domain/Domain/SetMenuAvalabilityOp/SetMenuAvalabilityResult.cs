using CSharp.Choices.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.SetMenuAvalabilityOp
{
    [AsChoice]
    public static partial class SetMenuAvalabilityResult
    {
        public interface ISetMenuAvalabilityResult { }

        public class MenuAvalabilitySet : ISetMenuAvalabilityResult
        {
            public MenuAvalabilitySet()
            {
            }
        }

        public class MenuAvalabilityNotSet : ISetMenuAvalabilityResult
        {
            public String Reason;

            public MenuAvalabilityNotSet(String reason)
            {
                Reason = reason;
            }
        }
    }
}