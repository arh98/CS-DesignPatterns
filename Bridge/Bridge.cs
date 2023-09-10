using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge;

// abstraction
public abstract class Menu {
    public readonly ICoupon _coupon = null!;
    public abstract double CalaulatePrice();
    public Menu(ICoupon coupon) {
        _coupon = coupon;
    }
}

// Refined abstaction-1
public class VegetarianMenu : Menu {
    public VegetarianMenu(ICoupon coupon) : base(coupon) {

    }
    public override double CalaulatePrice() {
        return  20 - _coupon.CouponValue;
    }
}

// Refined abstaction-2
public class MeatBasedMenu : Menu {
    public MeatBasedMenu(ICoupon coupon) : base(coupon) {

    }
    public override double CalaulatePrice() {
        return 30 - _coupon.CouponValue;
    }
}

// implementor
public interface ICoupon {
    int CouponValue { get; }
}

// concrete implementation-1
public class NoCoupon : ICoupon {
    public int CouponValue { get => 0; }
}

// concrete implementation-2
public class TwoEuroCoupon : ICoupon {
    public int CouponValue { get => 2; }
}