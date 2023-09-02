using Prototype;

var manager = new Manager("cindy");
var managerClone = (Manager)manager.Clone();
Console.WriteLine($"Manager was cloned : {managerClone.Name}");

var employee = new Employee("alex" , managerClone);
var employeeClone = (Employee)employee.Clone();
Console.WriteLine($"employee was cloned : {employeeClone.Name} -- manager : {employeeClone.Manager.Name}");

managerClone.Name = "jack";
Console.WriteLine($"employee was cloned : {employeeClone.Name} -- manager : {employeeClone.Manager.Name}");
