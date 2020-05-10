using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Abstractions;
using Database.Context;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Operations
{
    public class GetOp<T, C, R> : OpInterpreter<C, R, Unit>
        where T : class
        where C : GetCmd<T>
        where R : GetResultType<T>
    {
        protected readonly OrderAndPayContext Context;
        protected readonly DbSet<T> Set;

        public GetOp(OrderAndPayContext context)
        {
            Context = context;
            Set = Context.Set<T>();
        }

        public override async Task<R> Work(C Op, Unit state)
        {
            if(!await Set.AnyAsync())
                return await Task.FromResult(new GetResult.NotFound<T>(GetResult.NotFoundReason.EmptyList) as R);
            var result = Set.Filter(Op.Expression).ToList();
            if (!result.Any())
                return await Task.FromResult(new GetResult.NotFound<T>(GetResult.NotFoundReason.ExpressionNotMatched) as R);
            return await Task.FromResult(new GetResult.Found<T>(result) as R);
        }
    }
    
    public class GetRestaurantEntityOp : GetOp<RestaurantEntity, GetCmd<RestaurantEntity>, GetResultType<RestaurantEntity>>
    {
        public GetRestaurantEntityOp(OrderAndPayContext context) : base(context)
        {
        }
    }
    
    public class GetMenuEntityOp : GetOp<MenuEntity, GetCmd<MenuEntity>, GetResultType<MenuEntity>>
    {
        public GetMenuEntityOp(OrderAndPayContext context) : base(context)
        {
        }
    }
}
