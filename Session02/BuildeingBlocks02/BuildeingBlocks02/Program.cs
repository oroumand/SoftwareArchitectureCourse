// See https://aka.ms/new-console-template for more information
using BuildeingBlocks02;

Console.WriteLine("Hello, World!");
Person person = new Person();

FirstName a = new FirstName( Console.ReadLine());
LastName b = new LastName (Console.ReadLine());
person.FirstName = a;
person.LastName = b;