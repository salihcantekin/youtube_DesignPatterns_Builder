// Singleton Design Pattern
using System;
using DesignPatterns.SingletonPattern;

#region Explanation

/* *** Pros ***
    - Ensure single instance (can be use for memory caching)
    - Globally Access
    - Created only when requested
*/

/* *** Cons ***
    - Difficult to UnitTest (mocking)
    - In multithread word, threads cannot create its own instance
*/

#endregion


Console.WriteLine(DateTime.Now.ToLongTimeString());
var countries = await CountryProvider.Instance.GetCountries();


//foreach (var country in countries)
//{
//    Console.WriteLine(country.Name);
//}

// Another service

var countries1 = await CountryProvider.Instance.GetCountries();

Console.WriteLine(CountryProvider.Instance.CountryCount);

Console.WriteLine(DateTime.Now.ToLongTimeString());