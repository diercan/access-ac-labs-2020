using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain;
using EarlyPay.Primitives.Mocking;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.Extensions.DependencyInjection;

namespace OpTests
{
    public class OpTest
    {
        public IServiceProvider CreateServiceProvider(MockContext exec)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<MockInterpreterAsync>();
            serviceCollection.AddSingleton<LiveInterpreterAsync>();
            serviceCollection.AddOperations(typeof(RestaurantDomain).Assembly);
            serviceCollection.AddLogging();
            serviceCollection.AddScoped<IExecutionContext>(sp => exec.CreateScope());
            return serviceCollection.BuildServiceProvider();
        }

        public async Task<A> TestExpr<A>(IO<A> expr, params object[] paths)
        {
            var mockContext = MockContext.GetInstance(paths);
            var sp = CreateServiceProvider(mockContext);
            var interpreter = new MockInterpreterAsync(sp);
            var result = await interpreter.Interpret(expr, Unit.Default);
            return result;
        }

    }
}
