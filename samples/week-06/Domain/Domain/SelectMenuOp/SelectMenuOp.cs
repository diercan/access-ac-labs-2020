using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.SelectMenuOp.SelectMenuResult;

namespace Domain.Domain.SelectMenuOp
{
    internal class SelectMenuOp : OpInterpreter<SelectMenuCmd, ISelectMenuResult, Unit>
    {
        public override Task<ISelectMenuResult> Work(SelectMenuCmd Op, Unit state)
        {
            try
            {
                Op.CheckIfValid();
                return Task.FromResult<ISelectMenuResult>(new MenuSelected(new MenuAgg(Op.Menu)));
            }
            catch (Exception exp)
            {
                return Task.FromResult<ISelectMenuResult>(new MenuNotSelected(exp.Message));
            }
        }
    }
}