using System;

namespace Infra.Free
{
    public interface IO<out A>
    {
        IO<B> Bind<B>(Func<A, IO<B>> f);
    }

    public interface IOp { }
    public interface IOp<O, R> : IOp { }

    public class IO<O, R, A> : IO<A>, IOp<O, R>
    {
        public readonly O Op;
        public readonly Func<R, IO<A>> Do;
        public IO(O op, Func<R, IO<A>> @do)
        {
            Op = op;
            Do = @do;
        }
        public IO<B> Bind<B>(Func<A, IO<B>> f) => new IO<O, R, B>(Op, r => Do(r).Bind(f));
    }

    public class Return<A> : IO<A>
    {
        public readonly A Value;
        public Return(A value) =>
            Value = value;

        public IO<B> Bind<B>(Func<A, IO<B>> f) => f(Value);
    }
}
