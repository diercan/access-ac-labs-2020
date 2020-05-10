using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using static Domain.Domain.SetMenuAvalabilityOp.SetMenuAvalabilityResult;
using Persistence.EfCore;

namespace Domain.Domain.SetMenuAvalabilityOp
{
    public class SetMenuAvalabilityOp : OpInterpreter<SetMenuAvalabilityCmd, ISetMenuAvalabilityResult, Unit>
    {
        public override Task<ISetMenuAvalabilityResult> Work(SetMenuAvalabilityCmd Op, Unit state)
        {
            (bool CommandIsValid, String Error) = Op.IsValid();
            if (CommandIsValid)
            {
                // If there is no existent key with the specified time period, stored in Op.Hour, it will create that key with an empty Menu List
                if (Op.MenuVisibilityTypes == MenuVisibilityTypes.SpecialMenu)
                {
                    Op.MenuAgg.DisplayTime = Op.Hour;
                }
                // Setting the menu to a special or regular menu
                Op.MenuAgg.MenuVisibilityTypes = Op.MenuVisibilityTypes;

                return Task.FromResult<ISetMenuAvalabilityResult>(new MenuAvalabilitySet());
            }
            else
                return Task.FromResult<ISetMenuAvalabilityResult>(new MenuAvalabilityNotSet(Error));
        }
    }
}