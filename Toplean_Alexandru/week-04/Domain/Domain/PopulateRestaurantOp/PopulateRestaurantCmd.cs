using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.PopulateRestaurantOp
{
    internal class PopulateRestaurantCmd
    {
        public RestaurantAgg RestaurantAgg { get; }
        public Func<int, IO<ICollection<Menu>>> GetAllMenus { get; set; }

        public Func<int, IO<ICollection<MenuItem>>> GetAllMenuItems { get; set; }

        public LiveInterpreterAsync interpreter { get; }

        public PopulateRestaurantCmd(RestaurantAgg restaurant, Func<int, IO<ICollection<Menu>>> getAllMenus, Func<int, IO<ICollection<MenuItem>>> getAllMenuItems, LiveInterpreterAsync interpreter)
        {
            RestaurantAgg = restaurant;
            GetAllMenus = getAllMenus;
            GetAllMenuItems = getAllMenuItems;
            this.interpreter = interpreter;
        }
    }
}