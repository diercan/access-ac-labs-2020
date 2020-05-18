using System;
using System.ComponentModel;

namespace EarlyPay.Primitives.Mocking
{
    public interface IMockableContext
    {
        void AddMock<TEnum>(TEnum action, object mock);
    }

    public static class MockableContextEx
    {
        public static void Mock<TEnum, TResult>(this IMockableContext self, TEnum action, Func<TResult> mock)
            => self.AddMock(action, mock);

        public static void Mock<TEnum, TIn1, TResult>(this IMockableContext self, TEnum action, Func<TIn1, TResult> mock)
            => self.AddMock(action, mock);

        public static void Mock<TEnum, TIn1, TIn2, TResult>(this IMockableContext self, TEnum action, Func<TIn1, TIn2, TResult> mock)
            => self.AddMock(action, mock);

        public static void Mock<TEnum, TIn1, TIn2, TIn3, TResult>(this IMockableContext self, TEnum action, Func<TIn1, TIn2, TIn3, TResult> mock)
            => self.AddMock(action, mock);

        public static void Mock<TEnum, TIn1, TIn2, TIn3, TIn4, TResult>(this IMockableContext self, TEnum action, Func<TIn1, TIn2, TIn3, TIn4, TResult> mock)
            => self.AddMock(action, mock);

        public static void Mock<TEnum, TIn1, TIn2, TIn3, TIn4, TIn5, TResult>(this IMockableContext self, TEnum action, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TResult> mock)
            => self.AddMock(action, mock);
    }

    public delegate TResult Effect0<TEnum, TResult>(TEnum defaultEffect, Func<TResult> func);

    public delegate TResult Effect1<TEnum, TIn1, TResult>(TEnum defaultEffect, Func<TIn1, TResult> func, TIn1 param1);

    public delegate TResult Effect2<TEnum, TIn1, TIn2, TResult>(TEnum defaultEffect, Func<TIn1, TIn2, TResult> func,
        TIn1 param1, TIn2 param2);

    public delegate TResult Effect3<TEnum, TIn1, TIn2, TIn3, TResult>(TEnum defaultEffect,
        Func<TIn1, TIn2, TIn3, TResult> func, TIn1 param1, TIn2 param2, TIn3 param3);

    public delegate TResult Effect4<TEnum, TIn1, TIn2, TIn3, TIn4, TResult>(TEnum defaultEffect,
        Func<TIn1, TIn2, TIn3, TIn4, TResult> func, TIn1 param1, TIn2 param2, TIn3 param3, TIn4 param4);

    public delegate TResult Effect<TEnum, TIn1, TIn2, TIn3, TIn4, TIn5, TResult>(TEnum defaultEffect, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TResult> func, TIn1 param1, TIn2 param2, TIn3 param3,
        TIn4 param4, TIn5 param5);

    public static class ExecutionContextEx
    {
        public static TResult Effect<TEnum, TResult>(this IExecutionContext self, TEnum defaultEffect, Func<TResult> func)
            => self.FindEffect(defaultEffect, func, eff => eff());

        public static TResult Effect<TEnum, TIn1, TResult>(this IExecutionContext self, TEnum defaultEffect, Func<TIn1, TResult> func, TIn1 param1)
            => self.FindEffect(defaultEffect, func, eff => eff(param1));

        public static TResult Effect<TEnum, TIn1, TIn2, TResult>(this IExecutionContext self, TEnum defaultEffect, Func<TIn1, TIn2, TResult> func, TIn1 param1, TIn2 param2)
            => self.FindEffect(defaultEffect, func, eff => eff(param1, param2));

        public static TResult Effect<TEnum, TIn1, TIn2, TIn3, TResult>(this IExecutionContext self, TEnum defaultEffect, Func<TIn1, TIn2, TIn3, TResult> func, TIn1 param1, TIn2 param2, TIn3 param3)
            => self.FindEffect(defaultEffect, func, eff => eff(param1, param2, param3));

        public static TResult Effect<TEnum, TIn1, TIn2, TIn3, TIn4, TResult>(this IExecutionContext self, TEnum defaultEffect, Func<TIn1, TIn2, TIn3, TIn4, TResult> func, TIn1 param1, TIn2 param2, TIn3 param3, TIn4 param4)
            => self.FindEffect(defaultEffect, func, eff => eff(param1, param2, param3, param4));

        public static TResult Effect<TEnum, TIn1, TIn2, TIn3, TIn4, TIn5, TResult>(this IExecutionContext self, TEnum defaultEffect, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TResult> func, TIn1 param1, TIn2 param2, TIn3 param3, TIn4 param4, TIn5 param5)
            => self.FindEffect(defaultEffect, func, eff => eff(param1, param2, param3, param4, param5));
    }

    public interface IExecutionContext : IDisposable
    {
        TResult FindEffect<TEnum, TFunc, TResult>(TEnum defaultEffect, TFunc defaultAction,
            Func<TFunc, TResult> execute);
    }
}