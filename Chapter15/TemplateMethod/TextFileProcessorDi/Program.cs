using TextFileProcessorDi;

var service = new LineCounter();
var processor = new TextFileProcessor(service);
Console.Write("パスの入力:");
processor.Run(Console.ReadLine());

