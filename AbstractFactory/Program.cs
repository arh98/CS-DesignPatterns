using AbstractFactory;

var iranCartFacory = new IranShoppingCartPurchaseFactory();
var shoppingCart = new ShoppingCart(iranCartFacory , 630);
shoppingCart.CalculateCost();

var turkeyCartFactory = new TurkeyShoppingCartFactory();
var shoppingCart2 = new ShoppingCart(turkeyCartFactory, 630);
shoppingCart2.CalculateCost();