using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EarlyPay.Primitives.Mocking
{
    public class MockContext : IExecutionContext, IMockableContext
    {
        private readonly object[] _ctx;
        private readonly List<EffectOverride> _effects = new List<EffectOverride>();

        public static MockContext GetInstance(params object[] ctx) => new MockContext(ctx);

        private MockContext(params object[] ctx)
        {
            _ctx = ctx;
        }

        public MockContext CreateScope()
        {
            return new MockContext(_ctx);
        }

        public T Get<T>()
        {
            return _ctx.OfType<T>().SingleOrDefault();
        }

        public object[] GetAll()
        {
            return _ctx;
        }

        public TResult FindEffect<TEnum, TFunc, TResult>(TEnum defaultEffect, TFunc defaultAction, Func<TFunc, TResult> execute)
        {
            var specific = this.Get<TEnum>();
            if (specific == null)
                specific = defaultEffect;
            var effect = _effects
                .Where(p => p.CaseType.Equals(typeof(TEnum)))
                .SingleOrDefault(p => ((TEnum)p.Case).Equals(specific));
            if (effect == null)
                throw new Exception("A mock context has been set but you haven't defined any mocks in your operations. Review your RegisterMocks() implementation");
            var result = execute((TFunc)effect.Override);
            return result;
        }
        public void AddMock<TEnum>(TEnum action, object mock)
        {
            if (_effects.All(p => !p.Case.Equals(action)))
            {
                _effects.Add(new EffectOverride(action, mock));
            }
        }

        public void Dispose()
        {
            Console.WriteLine("Called dispose");
        }
    }
}