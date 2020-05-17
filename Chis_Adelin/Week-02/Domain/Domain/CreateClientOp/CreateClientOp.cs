using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.CreateClientOp.CreateClientResult;
namespace Domain.Domain.CreateClientOp
{
    public class CreateClientOp : OpInterpreter<CreateClientCmd, ICreateClientResult, Unit>
    {
        public override Task<ICreateClientResult> Work(CreateClientCmd Op, Unit state)
        {
            if (!Exists(Op.Name))
                return Task.FromResult<ICreateClientResult>(new ClientNotCreated("Client already exists !"));
            else
            {
                return Task.FromResult<ICreateClientResult>(new ClientCreated(new Client(Op.Name)));
            }
        }
        public bool Exists(string name)
        {
            return true;
        }
    }
}