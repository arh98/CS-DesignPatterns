using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype;

//ProtoType : 
public abstract class Person {
    public abstract string Name { get; set; }
    public abstract Person Clone();
}

//concrete-ProtoType 1
public class Manager : Person {
    public override string Name { get; set; }
    public Manager(string name) {
        Name = name;
    }
    public override Person Clone() {
        //create a shallow copy of existing obj
        return (Person)MemberwiseClone();
    }
}

//concrete-ProtoType 2
public class Employee : Person {
    public override string Name { get; set; }
    public Manager Manager { get; set; }
    public Employee(string name, Manager manager) {
        Name = name;
        Manager = manager;
    }
    public override Person Clone() {
        return (Person)MemberwiseClone();
    }
}