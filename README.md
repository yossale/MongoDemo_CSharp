# C# Mongo Client

Using the `sample_mflix` DB and `movies` collection to show case some of C# driver capabilities.


## Setup: 
1. Make sure to add you IP to the Atlas whitelist! 

1. Add a `setEnv.sh` file that looks like this:
```
export MFLIX_DEMO_USER=<YOUR_USER_NAME>
export MFLIX_DEMO_PASS=<YOUR_PASS>
export ATLAS_URI="mongodb+srv://${MFLIX_DEMO_USER}:${MFLIX_DEMO_PASS}@<YOUR_CLUSTER_URI>.mongodb.net/?retryWrites=true&w=majority"
```

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
