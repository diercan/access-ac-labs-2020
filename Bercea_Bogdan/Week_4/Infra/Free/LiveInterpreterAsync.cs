using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Infra.Free;
using LanguageExt;

namespace Infrastructure.Free
{
    public interface IInterpreterAsync
    {
        Task<A> Interpret<A, TState>(IO<A> ma, TState state);
    }

    public class LiveInterpreterAsync : IInterpreterAsync
    {
        private readonly IServiceProvider _serviceProvider;

        public LiveInterpreterAsync(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<A> Interpret<A, TState>(IO<A> ma, TState state)
        {
            return ma is Return<A> r
                ? r.Value
                    : await ResolveInterpreter<A, TState>(ma).Interpret(ma, state, (a) => Interpret(a, state));
        }

        private IInterpreter<S> ResolveInterpreter<A, S>(IO<A> ma)
        {
            return (IInterpreter<S>)_serviceProvider.GetService(GetTypeMarker(ma));
        }

        private readonly Type _nonGenericTypeMaker = typeof(IOp);
        private Type GetTypeMarker<A>(IO<A> ma) =>
            ma.GetType().GetInterfaces().Single(p => _nonGenericTypeMaker.IsAssignableFrom(p) && p.IsGenericType);

    }
}
