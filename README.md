
# Crud operation using asp.net core

1.Entity Framework (EF) Core is a lightweight, extensible, open source and cross-platform version of the popular Entity Framework data access technology.

2. EF Core can serve as an object-relational mapper (O/RM), enabling .NET developers to work with a database using .NET objects, and eliminating the need for most of the data-access code they usually need to write.

    a. What is the object-relational mapper?
    
         i. (O/RM) is an programming technique for converting data between relational database and C# objects

3. With EFCore, Data access is performed using the model. The model is made up of entity Class and DbContext object.

4. Allowing You to query(LINQ) and save the data

# Working with the Data Providers

  1. https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli
  
  2. Entity Framework Core can access many different databases through plug-in libraries called database providers.
  
  3. Microsoft.EntityFrameworkCore.SqlServer is the nugget package to work with Sql Server
  
      a. This database provider allows Entity Framework Core to be used with Microsoft SQL Server (including Azure SQL Database).
      
 # Creating and configuring a model     
 
 1. Entity Framework uses a set of conventions to build a model based on the shape of your entity classes. You can specify additional configuration to supplement and/or override what was discovered by convention.
 
      1. Using Data Annotations
     
      2. Using Fluent API
      



