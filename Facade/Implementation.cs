using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade;

//sub-system class 1
public class OrderService {
    public bool HasEnoughOrder(int customerId) {
        //fake calculation
        return customerId > 1;
    }
}
//sub-system class 2
public class CustomerDiscountBaseService {
    public double CalulateDiscountBase(int customerId) {
        //fake calculation
        return customerId > 8 ? 10 : 20;
    }
}

//sub-system class 3
public class DayOfWeekFactorService {
    public double CalculateDayFactor() {
        //fake calculation
        return DateTime.UtcNow.DayOfWeek switch {
            DayOfWeek.Saturday or DayOfWeek.Sunday => 0.8,
            _ => 1.2,
        };
    }
}

//Facade
public class DiscountFacade {
    private readonly OrderService _orderService;
    private readonly CustomerDiscountBaseService _discountBaseService;
    private readonly DayOfWeekFactorService _dayFactorService;
    public DiscountFacade() {
        _discountBaseService = new();
        _orderService = new();
        _dayFactorService = new();
    }

    public double CalculateDiscountPercentage(int customerId) {
        if (!_orderService.HasEnoughOrder(customerId)) {
            return 0;
        }
        return _discountBaseService.CalulateDiscountBase(customerId)
            * _dayFactorService.CalculateDayFactor();
    }
}