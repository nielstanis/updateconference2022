using System.Runtime.InteropServices;

Console.WriteLine($"Hello from {RuntimeInformation.OSArchitecture}!");

var file = System.IO.File.ReadAllText("/etc/hosts");
Console.WriteLine(file);