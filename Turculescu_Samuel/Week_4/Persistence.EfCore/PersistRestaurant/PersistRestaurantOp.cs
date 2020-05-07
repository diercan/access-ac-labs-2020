using Infrastructure.Free;
using LanguageExt;
using Persistence.EfCore;
using Persistence.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.PersistRestaurant.PersistRestaurantResult;

namespace Domain.Domain.PersistRestaurant
{
    public class PersistRestaurantOp : OpInterpreter<PersistRestaurantCmd, IPersistRestaurantResult, Unit>
    {
        private readonly OrderAndPayContext _dbContext;

        public PersistRestaurantOp(OrderAndPayContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IPersistRestaurantResult> Work(PersistRestaurantCmd Op, Unit state)
        {
            var r = new Restaurant()
            {
                Id = 1,
                Name = Op.DomainRestaurant.Name,
                Address = Op.DomainRestaurant.Address
            };
            await _dbContext.Restaurant.AddAsync(r);
            await _dbContext.SaveChangesAsync();
            
            return new RestaurantPersisted(r);
        }
    }
}
