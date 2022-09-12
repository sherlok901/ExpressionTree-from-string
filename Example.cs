using System;
using System.Linq.Expressions;
using System.Linq.Dynamic;

namespace ExpressionParser
{
  class Program
  {
    public class Person
    {
      public string Name { get; set; }
      public int Age { get; set; }
      public int Weight { get; set; }
      public DateTime FavouriteDay { get; set; }
    }

    static void Main()
    {
      const string exp = @"(Person.Age > 3 AND Person.Weight > 50) OR Person.Age < 3";
      var p = Expression.Parameter(typeof(Person), "Person");
      var e = System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] { p }, null, exp);
      var bob = new Person
      {
        Name = "Bob",
        Age = 30,
        Weight = 213,
        FavouriteDay = new DateTime(2000,1,1)
      };

      var result = e.Compile().DynamicInvoke(bob);
      Console.WriteLine(result);
      Console.ReadKey();
    }
  }
}
