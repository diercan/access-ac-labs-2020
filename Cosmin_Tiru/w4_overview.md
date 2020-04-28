# Week 4


## Persistence

In yesterday's session we described how we can introduce persistence in our application. So far, we've worked with our domain, tried to implement it as best as we could. 

A note here, the IStore example was just a way to demonstrate an alternative given the static approach.

## What's changed?

Well, we've realized that we have a small conflict between our models and the database entities. Basically, the models and everything you've built so far aim for the denormalized domain, while the database entities aim for the normalized domain (i.e. the database structure).

The terminology from now on for our classes that represent the denomralized domain will be "aggregates" and our entities will stay "entities".

The basic rule of thumbs:

1. We don't write aggregates to DB, we write only entities
2. We build our aggregates based on entities (and/or other input data)

## How to build the database

We won't try to automate the database creation. We'll keep it simple, just do the schema changes required for your database in your local instance of SqlServer. However, after every change we'll have to rebuild our EFCore context. This is the query that I've used yesterday to run the scaffolding process:

```powershell
scaffold-dbcontext "Data Source=localhost;Initial Catalog=OrderAndPay;Integrated Security=true" -Provider "Microsoft.EntityFrameworkCore.SqlServer" -OutputDir "..\Domain\Entities" -ContextDir Context 
```

Please run this in the "Package Management Console" after you've installed the appropriate packages. If you're having trouble finding them, here's a list of the NuGet packages required by EFCore.

```xml
 <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="3.1.3" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="3.1.3" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="3.1.3" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="3.1.3" />
  </ItemGroup>
```

## How does this blend in?

So far we've required basic hardcoded input for our operations, now we need to link them in our domain. For example, we have the following scenario, where our requirement is to create a restaurant. Most of you did a basic operation where you're returned a result that contained a restaurant. In my example, I've renamed the "original" restaurant in "RestaurantAgg" (as stated earlier) and extended my application to take advantage of my database.

### Create restaurant

```csharp
  public static IO<CreateRestaurantResult.ICreateRestaurantResult> CreateRestaurantAndPersist(string name)
            => from restaurantCreated in RestaurantDomain.CreateRestaurant(name) //the original op
               let agg = (restaurantCreated as CreateRestaurantResult.RestaurantCreated)?.Restaurant //get the entity
               from db in Database.AddOrUpdate(agg.Restaurant) //persist it
               select restaurantCreated; //don't change the result
```
### Get restaurant

```csharp
 public static IO<RestaurantAgg> GetRestaurant(string name)
            => from restaurant in Database.Query<FindRestaurantQuery, Restaurant>(new FindRestaurantQuery(name)) //a simple query that returns a Restaurant entity
               from getResult in RestaurantDomain.GetRestaurant(restaurant) //create the Restaurant out of that entity
               let agg = (getResult as GetRestaurantResult.RestaurantFound)?.Agg
               select agg; //don't change the result
```

Unfortunately, here, I had to change the original GetRestaurant operation in order for it to take advantage of the entity to build the aggregate (RestaurantAgg). An alternative would have been to have an entire new operation and swap them altogether. In DDD terminology the Query acts as a repository while the GetRestaurantOp acts as a Factory. 

## DatabaseDomain

You now have 3 new operations you can take advantage for your database. 

```csharp
 public static class Database
    {
        public static IO<AddOrUpdateResult.IAddOrUpdateResult> AddOrUpdate<T>(T item)
            => NewIO<AddOrUpdateCmd, AddOrUpdateResult.IAddOrUpdateResult>(new AddOrUpdateCmd(item));

        public static IO<DeleteResult.IDeleteResult> Delete<T>(T item)
            => NewIO<DeleteCmd, DeleteResult.IDeleteResult>(new DeleteCmd(item));

        public static IO<TResult> Query<TQuery, TResult>(TQuery query) => NewIO<TQuery, TResult>(query);
    }
```

Those ones are generic. The AddOrUpdate can take as an input any entity type and it will persist it/update it (hope the update works, I haven't actually test it), and the Delete will remove the entity if it finds it attached to our DbContext. Feel free to correct/extend it if you require so. 

The query operation is a bit more tricky. There's a generic command that takes as an input a function over DbContext*. This allows you to tap into Set< T > and query whatever table you like. You have one type per query where you have to specify the function in the base constructor. For example:

```csharp
 public class FindRestaurantQuery : Query<Restaurant>
    {
        public FindRestaurantQuery(string restaurantName) : base(async (ctx) =>
        {
            return 
                await ctx.Set<Restaurant>()
                    .Where(p => p.Name.Equals(restaurantName))
                    .FirstOrDefaultAsync();
        }) {}
    }
```

This takes as an input a name (from outside) and it's able to define the EFCore expression that resolves what's required. Please note how it's used:

```csharp
from restaurant in Database.Query<FindRestaurantQuery, Restaurant>(new FindRestaurantQuery(name)) 
```
here, the Restaurant type is the return type of the Database.Query op, and the type argument for FindRestaurantQuery. Feel free to create as many queries you like and play with them. 

*I've actually leaked the DbContext here, for simplicity and faster development. The query should contain an actual abstraction. If this goes well, I'll update the code to prove this. 
