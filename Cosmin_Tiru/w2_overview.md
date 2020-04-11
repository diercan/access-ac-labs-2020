# Type system

## Intro

Based on the feedback I've got from the past couple of days, I'll try to review some of the concepts briefly described on Monday, maybe give them a little bit of extra context. 

Given the fact that the entire project started as UI-first, with an emphasis on the domain of the application, it was somewhat natural to continue to do the same on the backend as well. 


In any given system, regardless of its nature, we can conclude that there's always an input, an output, and eventually a side effect. Usually the existence of a side effect inflicts an impure behavior. [You can start drilling down from here](https://en.wikipedia.org/wiki/Purely_functional_programming). Or from [here](https://blog.ploeh.dk/2017/07/10/pure-interactions/).

## The input (or the command/product type/algebraic data type)

A command consists of an aggregation of all the combinations of possible inputs that a given action is required. For example, I want to do a simple operation, like, buying bread. In order to do that I can imagine 2 things I need. First, an exchange unit (i.e. money) and a selection of options (this is the aggregation parts). This is a product type. To some extent, any data type that encapsulates two or more data fields is a product type. 

For example:

```csharp
public struct BuyBreadCmd
    {
        public int Amount { get; }
        public string Type { get; }

        public BuyBreadCmd(int amount, string type)
        {
            Amount = amount;
            Type = type;
        }
    }
```
If we look at this data type, we can identify a couple of issues with it. It's way too relaxed. It's built out of an integer and a string field. This means that, a combination of a possible input can be BuyBreakCmd(-42, "flatearth"). None of those fields are valid in the domain of buying bread. I cannot buy bread with a negative amount of money and request a "flatearth" bread. This means that we've identified two possible intrinsic states that a command can be into. A valid one, or an invalid one. The aim is to reduce the number of combinations to as little as possible, while keeping a defensive approach by validating the state of command. The fact that it can be written that way, doesn't mean we should. Maybe we can rewrite it like this:

```
public struct BuyBreadCmd
    {
        public uint Amount { get; }
        public BreadTypeEnum BreadType { get; }

        public BuyBreadCmd(uint amount, BreadTypeEnum breadType)
        {
            Amount = amount;
            BreadType = breadType;
        }
    }
```

Now our command is a little more restrictive. First of all, the Amount field cannot be negative. The data type to model that simply doesn't allow negative input, therefore the validity of the usage will be enforced at compile time. If you get really creative, you can avoid that, but it will usually express itself as a runtime exception, and your operation will never get to a point to execute something. Finding those workarounds it's not encouraged and those usually are bad design smells. If we want to restrict it even more, we can model the currency and the amount in a custom data type to replace uint. Feel free to take this modeling exercise on your own.

If I'd have to give an example from a math perspective, think of it this way. If I'd have to express the "money" function from the previous example, the initial sample would be expressed in this way with an identity function: f : Z -> Z. But since we are modeling a business domain, a Z value domain doesn't actually make sense. What we did was to narrow it to a positive range (i.e. f : N -> N). Any product type/data type can be translated into a domain. That's actually a part of your business domain model. **If you business domain does not allow it, your code shouldn't allow it either. Period.**

Topic to expand: unit tests over this, specifications, etc. If anyone is interested, feel free to take a look over [fscheck](https://github.com/fscheck/FsCheck) (works with C# as well).

### Wait, but, how do I validate it?

A simple, straightforward way to validate in dotnet is to use their own data annotations (and/or develop your own for specific cases). For example:

```
 public struct BuyBreadCmd
    {
        [Range(0, int.MaxValue)]
        public int Amount { get; }
        [Required]
        public string BreadType { get; }

        public bool Validate()
        {
            var validationResults = new List<ValidationResult>();
            return Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true);
        }
    }
```

I've changed the types to provide a real usage scenario. [Here](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=netframework-4.8) you can find details on existing data annotations.

## The results (aka as the Discriminated Unions/sum types/algebraic data types)

The commands and the results are simply the two main components for a function. A function usually does something with them. It takes the input, it decides if it can apply that request, makes further validations from the environment then returns a value from a constrained set of possible outcomes. Enter discriminated union. 

Now that we've defined that overview function above, and follow the same example, we can say that given the result from the identity function (the one defined in the command paragraph) as an input, we can extrapolate 2,3, n possible outcomes for my function (i.e. BuyBread function). Whenever I want to buy bread I can:

1. Try to scam the vendor and provide them Monopoly money. (i.e. ButBreadNotAllowed)
2. Try to beg for free bread (i.e. BuyBreadNoGiveways)
3. Be an honest citizen (i.e. BuyBreadSucceeded)
4. Feel free to expand if you find other possible scenarios.

The interface that abstracts the result for that function, is implemented by all the cases from above. 

Now, once that action is executed and I get out of the store, I return that abstract token to whoever delegated that action to me, and he can infer what happened there. I need to read that token and decide what action I can do against it. I deconstruct it using the generated Match method which forces me to provide an action point for every possible outcome. Please note, and try to visualize it yourself, or imagine a different scenario, for me, as a person who wants bread, I cannot make assumptions over what happens in the store (the outcome/the result), and the store cannot make assumptions about my intentions (the input/the command). **Trust no one.** 

From a high school math concept, it's just function composition. You compose the BuyBread function with the identity function from your input and you return something that can have 1, 2, n possible elements in its domain. Please make a mental mark about functional composition, because this composition will also be composed to something else down below. (i.e: (f o g)(x))

Why this is a better alternative than a classic, imperative if-else-then statement, is simply because nobody forces me to handle those cases. The recipe to decent code lies in the ability to express and handle all the possible known cases. There's a strong correlation between bugs and failing to see/handle an edge case. 

### How do I consume it?

Well, from a code perspective, from my point of view is quite easy. And I think this should be easy for you too as long as you can wrap your head around the fact that a function can be used as an argument, and can be treated as a first class citizen. Once I get this outcome, I should provide a function that encapsulates the logic that I need to execute for each possible state. Basically, this function should compose to the composition mentioned above. 

Once I get a result back, in order to consume it, I need to invoke a Match/MatchAsync function and apply any transition I require. 

```csharp
buyBreadResult.Match(OnBuyBreadNotAllowed, OnBuyBreadNoGiveaways, OnBuyBreadSucceeded);
```
As previously mentioned, all of them are functions that take as an argument a specific type. The dotnet ecosystem heavily relies on delegates, therefore you should take a look at them if you're not comfortable. Feel free to google them, or start from [here](https://www.tutorialsteacher.com/csharp/csharp-func-delegate).

## The operation

Ok, the composition technique it's the same technique that LINQ heavily relies for its query composition. If you dig stuff about LINQ (which you should) please be aware that if LINQ applies over collection, that doesn't mean that out IO< T > should have the same properties. The inner workings of monadic compositions is not in the scope of this lab. I'm referencing them just in case anyone wants to approach them on their own.

The operation is actually the function heavily used to underline the result concept from the above. The fun part comes over how we can abstract it from the implementation. We have to work with two types:

1. The IO< T >, which is generated out of the static method NewIO<TIn, TOut>
2. The actual implementation. 

We've used that RestaurantDomain class to define, basically, a header interface for our operations. For example, between:

```csharp
public static IO<ICreateRestaurantResult> CreateRestaurant(string name) =>
            NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(name));
```

and 
```csharp
public class CreateRestaurantOp : OpInterpreter<CreateRestaurantCmd, ICreateRestaurantResult, Unit>
```
there's a 1-to-1 correlation. In order to use the implementation as an abstraction, I need to be able to provide it to our domain. Please note that the type arguments (i.e. CreateRestauratCmd and ICreateRestauratResult) match between the two. 

If we'd have to make a parallel to the real world, please imagine buying a LEGO toy that you have to assemble yourself. Last time I played around with one I received the following in the box:

1. A set of instructions
2. A bag of plastics of various shapes and sizes. 

Now, if we open the set of instructions, we'll see that everything is split into steps, from 1 to n. We can map each step from there into an operation, which takes as an input a couple of plastic pieces, and you have to follow the algorithm. But that's just the instruction. We have N instructions, carefully placed into a particular order to provide the ultimate outcome. [The Death Star](https://www.lego.com/en-us/product/death-star-75159). (that's quite expensive).

Now, the instruction set points to a couple of real objects (i.e the pieces) and tells me how to interpret it. Once I start to "interpret" that instruction set (or the manual, or however you want to call it) I just start to call each operation in part, by simply following the algorithm provided, given that I pick the right input.

Having this said, an example of manual could be this:

```csharp
 var expr =
                from restaurantResult in RestaurantDomain.CreateRestaurant("mcdonalds")
                let restaurant = (restaurantResult as RestaurantCreated)?.Restaurant
                from menuResult in RestaurantDomain.CreateMenu(restaurant, "burgers", MenuType.Meat)
                let menu = (menuResult as MenuCreated)?.Menu
                from menuItemResult in RestaurantDomain.CreateAndAddMenuItem("carbonara", 100, menu)
                from menuItemResult1 in RestaurantDomain.CreateAndAddMenuItem("carbonara", 25, menu)
                from menuItemResult2 in RestaurantDomain.CreateAndAddMenuItem("conpesto", 20, menu)
                select restaurantResult;
```
which tells me what "plastics" (i.e. domain model objects) to pick and what's the final outcome of that. 

The actual build of the Death Star (i.e. the restaurant) happens when I actually interpret that manual by invoking:
```csharp
var interpreter = new LiveInterpreterAsync(serviceProvider);
var result = await interpreter.Interpret(expr, Unit.Default);
```
This is me doing manual labor and invoking every step from the manual. 

LEGO provides the DSL (domain specific language) - (NewIO<TIn, TOut>) that they use to create a manual (an expression), which we buy for the simple joy of interpreting it. 

In our case, we have to build the DSL (models+actions), build our manuals and interpret it as well. For free :(









