using System;
using System.Collections.Generic;
using System.Text;
using Domain.Domain.CreateRestauratOp;
using Domain.Domain.GetRestaurantOp;
using Domain.Models;
using Domain.Queries;
using Infra.Free;
using LanguageExt;
using Persistence;
using Persistence.EfCore;
namespace Domain.Domain
{
    public static class RestaurantDomainEx
    {
        public static IO<CreateRestaurantResult.ICreateRestaurantResult> CreateRestaurantAndPersist(string name)
            => from restaurantCreated in RestaurantDomain.CreateRestaurant(name)
               let agg = (restaurantCreated as CreateRestaurantResult.RestaurantCreated)?.RestaurantAgg
               from db in Database.AddOrUpdate(agg.Restaurant)
               select restaurantCreated;

        public static IO<RestaurantAgg> GetRestaurant(string name)
            => from restaurant in Database.Query<FindRestaurantQuery, Restaurant>(new FindRestaurantQuery(name))
               from getResult in RestaurantDomain.GetRestaurant(restaurant)
               let agg = (getResult as GetRestaurantResult.RestaurantFound)?.RestaurantAgg
               select agg;
    }
}
