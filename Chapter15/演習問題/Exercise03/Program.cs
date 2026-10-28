using Exercise03;
using TextFileProcessorDi;

var service = new Take20Processor();
var processor = new TextFileProcessor(service);
Console.Write("パスの入力:");
processor.Run(Console.ReadLine());

