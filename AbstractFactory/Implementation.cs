using System;
using System.Reflection;

namespace AbstractFactory;

//abstract factory
public interface IShoppingCartPurchaseFactory {
    IDiscountService CreateDiscountService();
    IShippingCostService CreateShippingCostService();
}

//abstract product a
public interface IDiscountService {
    int DiscountPercentage { get; }
}

//abstract product b
public interface IShippingCostService {
    decimal ShippingCost { get; }
}

// concrete product a1
public class IranDiscountService : IDiscountService {
    public int DiscountPercentage => 25;
}

//concrete product a2
public class TurkeyDiscountService : IDiscountService {
    public int DiscountPercentage => 20;
}

//concrete product b1
public class IranShippingCost : IShippingCostService {
    public decimal ShippingCost => 20;
}
//concrete product b2
public class TurkeyShippingCost : IShippingCostService {
    public decimal ShippingCost => 25;
}

//factories : one factory per family 
//factory 1
public class IranShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory {
    public IDiscountService CreateDiscountService() {
        return new IranDiscountService();
    }

    public IShippingCostService CreateShippingCostService() {
        return new IranShippingCost();
    }
}

//factory 2
public class TurkeyShoppingCartFactory : IShoppingCartPurchaseFactory {
    public IDiscountService CreateDiscountService() {
        return new TurkeyDiscountService();
    }

    public IShippingCostService CreateShippingCostService() {
        return new TurkeyShippingCost();
    }
}

//client class
public class ShoppingCart {
    private readonly IDiscountService _discountService;
    private readonly IShippingCostService _shippingCostService;
    private int _orderCost;
    public ShoppingCart(IShoppingCartPurchaseFactory factory , int cost) {
        _discountService = factory.CreateDiscountService();
        _shippingCostService = factory.CreateShippingCostService();
        _orderCost = cost;
    }

    public void CalculateCost() {
        Console.WriteLine("Total Cost is : " +
            $"{_orderCost - (_orderCost / 100 * _discountService.DiscountPercentage) + _shippingCostService.ShippingCost}");

    }

}