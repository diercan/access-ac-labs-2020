using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EarlyPay.Primitives;
using EarlyPay.Primitives.Mocking;
using Infra.Free;
using LanguageExt;

namespace Infrastructure.Free
{
    public abstract class OpInterpreter<O, R, S> : IInterpreter<S>, IOp<O, R>
    {
        public bool AppliesTo<A>(IO<A> ma) => ma is IO<O, R, A>;
        public virtual Task<(R, bool)> ShouldExecute(S state) => Task.FromResult((default(R), true));
        protected IO<O, R, A> Cast<A>(IO<A> ma) => (IO<O, R, A>)ma;

        protected virtual async Task<R> OpTypeWork(O op, S state)
        {
            var shouldExecute = await ShouldExecute(state);
            if (shouldExecute.Item2)
            {
                return await Work(op, state);
            }
            else
            {
                return shouldExecute.Item1;
            }
        }

        protected virtual Task OpBasedAssertions(S state, O op, R result) => Task.CompletedTask;

        public async Task<A> Interpret<A>(IO<A> ma, S state, Func<IO<A>, Task<A>> interpret)
        {
            return await interpret(Cast(ma).Do(await OpTypeWork(Cast(ma).Op, state)));
        }

        public async Task<A> Mock<A>(MockContext mockContext, IO<A> ma, S state, Func<IO<A>, Task<A>> interpret)
        {
            RegisterMocks(mockContext);
            var op = Cast(ma).Op;
            var result = await OpTypeWork(op, state);
            await Assertions(mockContext.GetAll(), state, Cast(ma).Op, result);
            await OpBasedAssertions(state, op, result);
            return await interpret(Cast(ma).Do(result));
        }

        public abstract Task<R> Work(O Op, S state);

        public virtual void RegisterMocks(IMockableContext executionContext) { }

        public virtual Task Assertions(object[] path, S state, O op, R result)
        {
            return Task.CompletedTask;
        }
    }
}