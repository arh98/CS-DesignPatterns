using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder;

//product to build
public class Car {
    private readonly string _carType;
    private readonly List<string> _parts;
    public Car(string cartype) {
        _carType = cartype;
        _parts = new List<string>();
    }

    public void AddPart(string part) {
        _parts.Add(part);
    }
    public override string ToString() {
        var sb = new StringBuilder();
        foreach (var part in _parts) {
            sb.Append($"car type : {_carType} has part : {part}\n");
        }
        return sb.ToString();
    }
}

//builder
public abstract class CarBuilder {
    public Car Car { get; private set; }
    public CarBuilder(string type) {
        Car = new(type);
    }
    public abstract void BuildEngine();
    public abstract void BuildFrame();

}

//concrete builder 1
public class MiniBuilder : CarBuilder {
    public MiniBuilder() : base("MINI") {

    }
    public override void BuildEngine() {
        Car.AddPart("'not a v8'");
    }
    public override void BuildFrame() {
        Car.AddPart("'3-door with stripes'");
    }
}

//concrete builder 2
public class BMWBuilder : CarBuilder {
    public BMWBuilder() : base("BMW") {
    }
    public override void BuildEngine() {
        Car.AddPart("'a fancy v8 engine'");
    }
    public override void BuildFrame() {
        Car.AddPart("'5-door with metallic finish'");
    }
}

//director
public class Garage {
    private CarBuilder? _builder;
    public Garage() {
    }
    public void Construct(CarBuilder builder) {
        _builder = builder;
        _builder.BuildEngine();
        _builder.BuildFrame();
    }
    public void ShowResult() {
        Console.WriteLine(_builder?.Car.ToString());
    }
}
