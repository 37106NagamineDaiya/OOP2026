using System.ComponentModel;
using System.Runtime.CompilerServices;
using TextFileProcessor;

//Console.Write("カウントしたい単語のパス");
//string path = Console.ReadLine()??"";
string path = @"C:\Users\infosys\source\repos\OOP2026\Chapter14\Section04\Program.cs";
TextProcessor.Run<FileCounterProcessor>(path);
string? countName = Console.ReadLine();
public class FileCounterProcessor : TextProcessor {
    private int _count = 0;
    private string _countName = string.Empty;

    protected override void Initialize(string fname) {
        _count = 0;
        Console.Write("カウントしたい単語:");
        _countName = Console.ReadLine() ??"";

    }

    protected override void Execute(string line) =>
        _count += line.Split(_countName).Length - 1;

    protected override void Terminate() =>
    Console.WriteLine("{0}個", _count);
}