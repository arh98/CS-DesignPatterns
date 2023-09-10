using Bridge;

var noCoupon = new NoCoupon();
var coupon = new TwoEuroCoupon();

var meatMenu = new MeatBasedMenu(noCoupon);
Console.WriteLine($"meat base menu,  with no coupon , price : {meatMenu.CalaulatePrice()}");

var vegMenu = new VegetarianMenu(coupon);
Console.WriteLine($"vegetarian based menu,  with 2 euro coupon , price : {vegMenu.CalaulatePrice()}");
