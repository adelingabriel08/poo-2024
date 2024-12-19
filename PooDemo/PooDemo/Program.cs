// See https://aka.ms/new-console-template for more information

using System;
using System.Text;
using System.Text.Json;
using PooDemo;

const Int32 BufferSize = 128;
using (var fileStream = File.OpenRead("myFile.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize)) {
    String line;
    while ((line = streamReader.ReadLine()) != null)
    {
        Console.WriteLine(line);
    }
}


using (StreamWriter outputFile = new StreamWriter("myFile2.txt"))
{
    outputFile.WriteLine("Hello World!");
    outputFile.WriteLine("Hello World 2!");
    outputFile.WriteLine("Hello World 3!");
    outputFile.Write("abc");
    outputFile.Write("def");
}

Masina masina1 = new Masina();

masina1.Age = 5;
masina1.Height = 7.5;
masina1.Name = "Skoda";

Masina masina2 = new Masina();

masina2.Age = 5;
masina2.Height = 7.5;
masina2.Name = "BMW";

// JSON
string masina1Str = JsonSerializer.Serialize(masina1);
string masina2Str = JsonSerializer.Serialize(masina2);

using (StreamWriter outputFile = new StreamWriter("lista_masini.txt"))
{
   outputFile.WriteLine(masina1Str);
   outputFile.WriteLine(masina2Str);
}


List<Masina> masini = new List<Masina>();
using (var fileStream = File.OpenRead("lista_masini.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize)) {
    String line;
    while ((line = streamReader.ReadLine()) != null)
    {
        Masina masina = JsonSerializer.Deserialize<Masina>(line);
        masini.Add(masina);
    }
}

foreach (var masina in masini)
{
    Console.WriteLine(masina.Name);
}
