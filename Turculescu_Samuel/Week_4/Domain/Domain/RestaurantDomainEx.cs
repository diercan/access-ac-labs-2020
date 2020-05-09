using System;
using System.Collections.Generic;
using System.Text;
using Domain.Domain.CreateRestaurantOp;
using Domain.Domain.ClientRoles.GetRestaurantOp;
using Domain.Models;
using Domain.Queries;
using Infra.Free;
using LanguageExt;
using Persistence;
using Persistence.EfCore;
using Domain.Domain.CreateClientOp;
using Domain.Domain.CreateEmployeeOp;
using Domain.Domain.GetClientOp;
using Domain.Domain.GetEmployeeOp;

namespace Domain.Domain
{
    public static class RestaurantDomainEx
    {
        // Create a Restaurant
        public static IO<CreateRestaurantResult.ICreateRestaurantResult> CreateRestaurantAndPersist(string name, string address)
            => from restaurantCreated in RestaurantDomain.CreateRestaurant(name, address)
               let agg = (restaurantCreated as CreateRestaurantResult.RestaurantCreated)?.Restaurant
               from db in Database.AddOrUpdate(agg.Restaurant)
               select restaurantCreated;

        // Get a Restaurant by name
        public static IO<RestaurantAgg> GetRestaurant(string name)
            => from restaurant in Database.Query<FindRestaurantQuery, Restaurant>(new FindRestaurantQuery(name))
               from getResult in RestaurantDomain.GetRestaurant(restaurant)
               let agg = (getResult as GetRestaurantResult.RestaurantFound)?.Agg
               select agg;

        // Create a Client
        public static IO<CreateClientResult.ICreateClientResult> CreateClientAndPersist(string firstName, string lastName, string email, string phone, string cardNumber, string username, string password)
            => from clientCreated in RestaurantDomain.CreateClient(firstName, lastName, email, phone, cardNumber, username, password)
               let agg = (clientCreated as CreateClientResult.ClientCreated)?.Client
               from db in Database.AddOrUpdate(agg.Client)
               select clientCreated;

        // Get a Client by Id
        public static IO<ClientAgg> GetClient(int clientId)
            => from client in Database.Query<FindClientQuery, Client>(new FindClientQuery(clientId))
               from getResult in RestaurantDomain.GetClient(client)
               let agg = (getResult as GetClientResult.ClientFound)?.Agg
               select agg;

        // Create an Employee
        public static IO<CreateEmployeeResult.ICreateEmployeeResult> CreateEmployeeAndPersist(string firstName, string lastName, string email, string phone, string job, string username, string password, int restaurantId)
            => from employeeCreated in RestaurantDomain.CreateEmployee(firstName, lastName, email, phone, job, username, password, restaurantId)
               let agg = (employeeCreated as CreateEmployeeResult.EmployeeCreated)?.Employee
               from db in Database.AddOrUpdate(agg.Employee)
               select employeeCreated;

        // Get an Employee by Restaurant Id and Employee Id 
        public static IO<EmployeeAgg> GetEmployee(int restaurantId, int employeeId)
            => from employee in Database.Query<FindEmployeeQuery, Employee>(new FindEmployeeQuery(restaurantId, employeeId))
               from getResult in RestaurantDomain.GetEmployee(employee)
               let agg = (getResult as GetEmployeeResult.EmployeeFound)?.Agg
               select agg;

    }
}
