Console.Title = "Composite-Pattern";

var root = new Composite.Directory("root", 0);
var topLevelFile = new Composite.File("tfile.txt", 40);
var topLevelDir1 = new Composite.Directory("topLevelDirectory1", 4);
var topLevelDir2 = new Composite.Directory("topLevelDirectory2", 4);

root.Add(topLevelFile);
root.Add(topLevelDir1);
root.Add(topLevelDir2);

var subLevelFile1 = new Composite.File("sublevel1.txt", 200);
var subLevelFile2 = new Composite.File("sublevel2.txt", 150);

topLevelDir2.Add(subLevelFile1);
topLevelDir2.Add(subLevelFile2);

Console.WriteLine($"Size of topLevelDirectory1: {topLevelDir1.GetSize()}");
Console.WriteLine($"Size of topLevelDirectory2: {topLevelDir2.GetSize()}");
Console.WriteLine($"Size of root: {root.GetSize()}");

Console.ReadKey();