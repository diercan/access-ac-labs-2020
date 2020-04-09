using System;
using System.Threading.Tasks;
using EarlyPay.Primitives.Mocking;
using Infrastructure.Free;

namespace Infra.Free
{
    public interface IInterpreter<S> : IInterpreter
    {
        bool AppliesTo<A>(IO<A> ma);
        Task<A> Interpret<A>(IO<A> ma, S state, Func<IO<A>, Task<A>> interpret);
        Task<A> Mock<A>(MockContext mockContext, IO<A> ma, S state, Func<IO<A>, Task<A>> interpret);
    }
    public interface IInterpreter { }
}