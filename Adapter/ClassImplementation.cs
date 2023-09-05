using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAdapter;

public class CityFromExtenalSystem {
    public string Name { get; private set; }
    public string NickName { get; private set; }
    public int Inhabitants { get; private set; }
    public CityFromExtenalSystem(string name, string nickName, int inhabitants) {
        Name = name;
        NickName = nickName;
        Inhabitants = inhabitants;

    }
}

//adabtee
public class ExternalSystem {
    public CityFromExtenalSystem GetCity() {
        return new CityFromExtenalSystem("Isfahan", "nesfe jahan", 320000);
    }
}

public class City {
    public string FullName { get; private set; }
    public long Inhabitants { get; private set; }
    public City(string fullname, long inhabitants) {
        FullName = fullname;
        Inhabitants = inhabitants;
    }
}

//target 
public interface ICityAdapter {
    City GetCity();
}

//adapter 
public class CityAdapter : ExternalSystem, ICityAdapter {
    public City GetCity() {
        //Call into external system
        var cityExternal = base.GetCity();
        //adapt cityFromExternal to city
        return new City($"{cityExternal.Name} - {cityExternal.NickName}", cityExternal.Inhabitants);
    }
}