using Strategy;

var order = new Order("JetBrains", 3, "IDEA License");
order.Export(new CSVExportService());
order.Export(new JsonExportService());