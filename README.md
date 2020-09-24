
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
      
 # DbContext Class
 1. A DbContext instance represents a session with the database and can be used to query and save instances of your entities.
 
 2. DbContext must have an instance of DbContextOptions in order to perform any work. The DbContextOptions instance carries configuration information such as:
 
       1. Dataprovider
       2. ConnectionString
  
  3. Example with initializing at constructor level
     
            public class SomeDbContext : DbContext
            {
            public BloggingContext(DbContextOptions<SomeDbContext> options)
                : base(options)
            { }

            public DbSet<Employee> Employees { get; set; }
             }
 
 4. Example with initializing at method level instead of constructor level
  
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         { 
             if(!optionBuilder ,IsConfigured)
              {
                 //initializing.......
             }
         }
 
 # Creating and configuring a model     
 
 1. Entity Framework uses a set of conventions to build a model based on the shape of your entity classes. You can specify additional configuration to supplement and/or override what was discovered by convention.
 
      1. Using Data Annotations
     
      2. Using Fluent API
      
  # using Data Annotations
  1. using System.ComponentModel.DataAnnotations will apply the attributes towards classes and Properties
               
            public class Employee
            {
                public int EmpId { get; set; }
                [Required]
                public string EmpName { get; set; }
            }
            
   # Using Fluent API
   1. We can override the OnModelCreating method in your derived context and use the ModelBuilder API to configure your model. This is the most powerful method of configuration and allows configuration to be specified without modifying your entity classes. Fluent API configuration has the highest precedence and will override conventions and data annotations.
   
          protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Employee>()
                    .Property(b => b.EmpName)
                    .IsRequired();
            }
            
        
   # Migrations
   1. Migration is a way to keep the database schema in sync with the EF Core model by preserving data
         1. Add-Migration
         
         2. Remove-Migration
         
         3. Update- Database
         
         4. Scaffold-Dbcontext
         
              i. Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
              
              
   # Working With ASP.Net Core
   1. To add EF Core support to a project, install the
   
     1. Microsoft.EntityFrameworkCore
     
     2. Microsoft.EntityFrameworkCore.SqlServer
     
     3. Microsoft.EntityFrameworkCore.Tools
    
              
              
   



