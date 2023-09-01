using Builder;

Garage garage = new();
var bmwBuilder = new BMWBuilder();
var miniBuilder = new MiniBuilder();

garage.Construct(bmwBuilder);
garage.ShowResult();

garage.Construct(miniBuilder);
garage.ShowResult();