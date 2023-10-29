namespace Strategy;

// Strategy
public interface IExportService {
    void Export(Order order);
}

// ConcreteStrategy 1
public class JsonExportService : IExportService {
    public void Export(Order order) {
        Console.WriteLine($"Exporting {order.Name} to Json.");
    }
}

// ConcreteStrategy 2
public class XMLExportService : IExportService {
    public void Export(Order order) {
        Console.WriteLine($"Exporting {order.Name} to XML.");
    }
}

// ConcreteStrategy 3
public class CSVExportService : IExportService {
    public void Export(Order order) {
        Console.WriteLine($"Exporting {order.Name} to CSV.");
    }
}

/// Context
public class Order {
    public string Customer { get; set; }
    public int Amount { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    //public IExportService ExportService { get; set; }   
    public Order(string customer, int amount, string name) {
        Customer = customer;
        Amount = amount;
        Name = name;
    }
    // no composition - with method parameter
    public void Export(IExportService exportService) {
        if (exportService is null) {
            throw new ArgumentNullException(nameof(exportService));
        }

        exportService.Export(this);
    }
}
