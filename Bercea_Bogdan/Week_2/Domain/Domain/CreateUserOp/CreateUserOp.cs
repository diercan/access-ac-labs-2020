using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.CreateUserOp
{
    public class CreateUserOp : OpInterpreter<CreateUserCmd, CreateUserResult.ICreateUserResult, Unit>
    {
        public override Task<CreateUserResult.ICreateUserResult> Work(CreateUserCmd Op, Unit state)
        {
            return !UserNameExist(Op.UserName) ?
                Task.FromResult<CreateUserResult.ICreateUserResult>
                    (new CreateUserResult.UserNotCreated("This username i already taken")) :
                Task.FromResult<CreateUserResult.ICreateUserResult>
                    (new CreateUserResult.UserCreated(new Models.User("Mikey", "myPass", 23)));
        }

        private bool UserNameExist(string userName)
        {
            return false;
        }
    }
}
