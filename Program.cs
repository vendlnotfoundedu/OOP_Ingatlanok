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
    Console.WriteLine("\nIngatlannyilvántartás:");
    foreach (Ingatlan i in ingatlanok) Console.WriteLine(i);
}
