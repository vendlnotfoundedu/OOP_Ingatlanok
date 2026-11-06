using OOP_Ingatlanok;

List<Ingatlan> ingatlanok = new List<Ingatlan>();

if (File.Exists("ingatlanok.txt"))
{
    foreach (string sor in File.ReadAllLines("ingatlanok.txt"))
    {
        if (string.IsNullOrWhiteSpace(sor)) continue;
        string[] adatok = sor.Split(';');
        int db = adatok.Count();
        string azonosito = adatok[0];
        string cim = adatok[1];
        string kategoria = adatok[2];
        if (db == 4)
        {
            if (int.TryParse(adatok[3], out int alapterulet))
            {
                Ingatlan aktualis = new Ingatlan(azonosito, cim, kategoria, alapterulet);
                ingatlanok.Add(aktualis);
            }
            else Console.WriteLine($"[HIBA] A(z) {adatok[0]} azonosítójú ingatlan adatai hibásak, átugorva!");
        }
        else if (db == 5)
        {
            if (int.TryParse(adatok[3], out int alapterulet) && int.TryParse(adatok[4], out int arEzerFt))
            {
                Ingatlan aktualis = new Ingatlan(azonosito, cim, kategoria, alapterulet , arEzerFt );
                ingatlanok.Add(aktualis);
            }
            else Console.WriteLine($"[HIBA] A(z) {adatok[0]} azonosítójú ingatlan adatai hibásak, átugorva!");
        }
    }
    
}
else Console.WriteLine("Az ingatlanok.txt nevű fájl nem található!");
Console.WriteLine("\nIngatlannyilvántartás:");
foreach (Ingatlan i in ingatlanok) Console.WriteLine(i.ToString());
Console.WriteLine($"\nRegisztrált ingatlanok száma a rendszerben: {Ingatlan.OsszesRegisztraltIngatlan} db");
Console.WriteLine("\nLakás Kategóriájú Ingatlanok");
Console.WriteLine();
Console.WriteLine($"Legnagyobb alapterületű ingatlan: {ingatlanok.MaxBy(ing => ing.AlapteruletM2)}");
//Console.WriteLine($"Fizetendő vagyonszerzési illeték (4%): {Adokalkulator.VagyonszerzesiAdo(ingatlanok)}");
int atlag = 0;
int ertek = 0;
int darab = 0;
foreach (Ingatlan i in ingatlanok) 
{
    ertek += i.ArEzerFt;
    darab++;
}
atlag = ertek / darab;
//Console.WriteLine($"Ingatlanok átlagos négyzetméterára: {Ingatlan.NegyzetmeterAr(atlag)} Ft/m2");