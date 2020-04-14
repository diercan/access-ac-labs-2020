using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EarlyPay.Primitives;
using EarlyPay.Primitives.Mocking;
using Infra.Free;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Free
{
    public class MockInterpreterAsync
    {
        private readonly Type _nonGenericTypeMaker = typeof(IOp);
        public MockContext MockContext { get; }
        private readonly IServiceProvider _serviceProvider;

        public MockInterpreterAsync() : this(new ServiceCollection().BuildServiceProvider()) { }

        public MockInterpreterAsync(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<A> Interpret<A, S>(IO<A> ma, S state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (var mockContext =
                    (MockContext)scope.ServiceProvider.GetService<IExecutionContext>())
                {
                    return ma is Return<A> r
                        ? r.Value
                        : await ResolveInterpreter<A, S>(scope.ServiceProvider, ma).Mock(mockContext, ma, state, (a) => Interpret(a, state));
                }
            }
        }

        private IInterpreter<S> ResolveInterpreter<A, S>(IServiceProvider sp, IO<A> ma)
        {
            return (IInterpreter<S>)sp.GetService(GetTypeMarker(ma));
        }

        private Type GetTypeMarker<A>(IO<A> ma) =>
            ma.GetType().GetInterfaces().Single(p => _nonGenericTypeMaker.IsAssignableFrom(p) && p.IsGenericType);
    }
}
