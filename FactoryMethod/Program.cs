using FactoryMethod;

var factories = new List<DiscountFactory> {
new CodeDiscountFactory(Guid.NewGuid()),
new CountryDiscountFactory("IR")
};

foreach (var factory in factories) {
    var discountService = factory.CreateDiscountService();
    Console.WriteLine($"Persentage  : {discountService.DiscountPercentage}\nComming from : {discountService}");
}