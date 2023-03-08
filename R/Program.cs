using Microsoft.EntityFrameworkCore;
using R;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Linq;
using System.Threading.Tasks;



using var context = new ProgramminClassesContext();
//////////////////////////////////task on grade 3.0
//foreach (var customer in context.Customers)
//{
//    Console.WriteLine($"{customer.FirstName} {customer.LastName} (Company Name: {customer.CompanyName}) (ID: {customer.CustomerId})");
//}
//var me = new Customer
//{
//    FirstName = "Baizhan",
//    LastName = "Dossanov",
//    PasswordHash = "parol",
//    PasswordSalt = "2sTv"
//};

//context.Customers.Add(me);
//context.SaveChanges();


//Console.WriteLine("Updated table");

//foreach (var customer in context.Customers)
//{
//    Console.WriteLine($"{customer.FirstName} {customer.LastName} (Company Name: {customer.CompanyName}) (ID: {customer.CustomerId})");
//}



///////////////////////////task on grade 4.0
var topTwoCustomersWithL = await context.Customers
    .Where(c => c.LastName.StartsWith("L"))
    // Order customers by ID in descending order
    .OrderByDescending(c => c.CustomerId)
    // Take only the top 2 customers
    .Take(2)
    // Retrieve customers in a list
    .ToListAsync();
Console.WriteLine("Top 2 customers with last name starting with L:");
foreach (var customer in topTwoCustomersWithL)
{
    Console.WriteLine($"\t- {customer.FirstName} {customer.LastName} \n");
}

//cities works
var cities =  context.Addresses
    .Select(a => a.City)
    .OrderBy(c => c)
    .Distinct()
    .ToList();

Console.WriteLine("Cities in alphabetical order:");
foreach (var city in cities)
{
    Console.WriteLine(city);
}
Console.WriteLine("\n");

var longestPName = await context.Products
                .OrderByDescending(p => p.Name.Length)
                .Select(p => p.Name)
                .FirstOrDefaultAsync();
Console.WriteLine($"Product with longest name: {longestPName}");
