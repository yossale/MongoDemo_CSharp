# C# Mongo Client

Using the `sample_mflix` DB and `movies` collection to show case some of C# driver capabilities.

We're running the same queries in 3 different ways:
1. `nflix.mongodb` is a natural mdb sample.
2. `MongoClient` uses regular C# constructs (`Filter`)
3. `MongoClient_Linq` is resolving the queries using LINQ.


## Setup: 
1. Make sure to add you IP to the Atlas whitelist! 

1. Add a `setEnv.sh` file that looks like this:
```
export MFLIX_DEMO_USER=<YOUR_USER_NAME>
export MFLIX_DEMO_PASS=<YOUR_PASS>
export ATLAS_URI="mongodb+srv://${MFLIX_DEMO_USER}:${MFLIX_DEMO_PASS}@<YOUR_CLUSTER_URI>.mongodb.net/?retryWrites=true&w=majority"
```

1. Cd to your favourite project.

2. make sure to install MongoDB .Net driver:
```
dotnet add package MongoDB.Driver
```

3. run! 
```
./run.sh
```

## Resources:

[C# On Mac - Quick Start](https://dotnet.microsoft.com/en-us/learn/dotnet/hello-world-tutorial/install)

[Mongo Driver - Quick Start C#](https://www.mongodb.com/docs/drivers/csharp/current/quick-start/)

[LINQ](https://www.mongodb.com/docs/drivers/csharp/current/fundamentals/linq/)

[How to Create a .NET Core App with MongoDB Atlas
](https://www.youtube.com/watch?v=iklJHXn8D1s&t=2s&ab_channel=MongoDB)
