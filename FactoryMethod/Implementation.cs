using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod;

//abs factory method
public abstract class DiscountService {
    public abstract int DiscountPercentage { get; }
    public override string ToString() => GetType().Name;
}
// Concrete factory method 1
public class CountryDiscountService : DiscountService {
    private readonly string _countryId;
    public CountryDiscountService(string countryId) {
        _countryId = countryId;
    }
    public override int DiscountPercentage {
        get {
            return _countryId switch {
                "IR" => 30,
                _ => 10
            };
        }
    }
}
//Concrete factory method 2
public class CodeDiscountService : DiscountService {
    private readonly Guid _code;

    public CodeDiscountService(Guid code) {
        _code = code;
    }
    public override int DiscountPercentage {
        //...
        get => 15;
    }
}

//abs creator
public abstract class DiscountFactory {
    public abstract DiscountService CreateDiscountService();
}

//concrete creator 1 
public class CountryDiscountFactory : DiscountFactory {
    private readonly string _countryId;
    public CountryDiscountFactory(string countryId) {
        _countryId = countryId;
    }
    public override DiscountService CreateDiscountService() {
        return new CountryDiscountService(_countryId);
    }
}
// concrete creator 2
public class CodeDiscountFactory : DiscountFactory {
    private readonly Guid _code;
    public CodeDiscountFactory(Guid code) {
        _code = code;
    }
    public override DiscountService CreateDiscountService() {
        return new CodeDiscountService(_code);
    }
}