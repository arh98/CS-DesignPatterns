using Adapter;

//testing object adapter :
ICityAdapter cityAdapter = new CityAdapter();
var city = cityAdapter.GetCity();

Console.WriteLine(city.FullName + " " + city.Inhabitants);