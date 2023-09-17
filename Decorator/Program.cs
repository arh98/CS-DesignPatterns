using Decorator;
using System.ComponentModel;

//instantiate mail services
var cloudMailService = new CloudMailService();
cloudMailService.SendMail("hi there");

var onPremiseMailService = new OnPremiseMailService();
onPremiseMailService.SendMail("hi there");

//add behvior
var statisticsDecorator = new StatisticsDecorator(cloudMailService);
statisticsDecorator.SendMail($"hi there via {nameof(statisticsDecorator)} wraper");

var messageDatabaseDecorator = new MessageDBDecorator(onPremiseMailService);
messageDatabaseDecorator.SendMail($"Hi there via {nameof(MessageDBDecorator)} wrapper, message 1.");
messageDatabaseDecorator.SendMail($"Hi there via {nameof(MessageDBDecorator)} wrapper, message 2.");

foreach (var message in messageDatabaseDecorator.SentMessagesDB) {
    Console.WriteLine($"Stored message: \"{message}\"");
}