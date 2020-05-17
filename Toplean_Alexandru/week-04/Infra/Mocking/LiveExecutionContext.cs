using System;

namespace EarlyPay.Primitives.Mocking
{
    public class LiveExecutionContext : IExecutionContext
    {
        public static LiveExecutionContext Instance = new LiveExecutionContext();

        public TResult FindEffect<TEnum, TFunc, TResult>(TEnum defaultEffect, TFunc defaultAction, Func<TFunc, TResult> execute)
        {
            return execute(defaultAction);
        }

        public void Dispose()
        {
        }
    }
}