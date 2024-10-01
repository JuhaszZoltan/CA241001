using CA241001;
using System.Text;

List<Event> events = [];

using StreamReader sr = new(
    path: @"..\..\..\src\paralympics.txt",
    encoding: Encoding.UTF8);
_ = sr.ReadLine();
while (!sr.EndOfStream) events.Add(new(sr.ReadLine()));

Console.WriteLine("1. feladat: " +
    $"a paralimpia eddig {events.Count} alkalommal kerult megrendezesre.");

var f2 = events.Sum(e => e.Medals.Values.Sum());
Console.WriteLine("2. feladat: " +
    $"a magyar sportolok osszesen {f2} ermet szereztek");

var f3 = events.Where(e => e.Medals.Values.All(x => x == 0));
Console.WriteLine("3. feladat: a kov helyszineken nem kepviseltette magat Mo:");
foreach (var e in f3) Console.WriteLine($"\t{e.City} ({e.Year})");

var f4 = events.GroupBy(e => e.Country).Where(g => g.Count() > 1);
Console.WriteLine("4. feladat: azon orszagok, akik tobb paralimpiat is rendeztek:");
foreach (var g in f4) Console.WriteLine($"\t{g.Key} ({g.Count()} alkalom)");

Console.Write("5. feladat: irjon be egy evszamot: ");
var f5val = int.TryParse(Console.ReadLine(), out int year);
if (!f5val) Console.WriteLine("\tnem megfelelo a beirt formatum");
else
{
    var f5 = events.SingleOrDefault(e => e.Year == year);
    if (f5 is null) Console.WriteLine("\tebben az evben rem rendeztek paralimpiai jatekokat");
    else Console.WriteLine(f5);
}