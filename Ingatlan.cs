using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Ingatlanok
{
    public class Ingatlan
    {
        private int alapteruletM2;
        private int arEzerFt;
        private static int osszesRegisztraltIngatlan = 0;
        public string Azonosito { get; set; }
        public string Cim { get; set; }
        public string Kategoria { get; set; }
        public int AlapteruletM2
        { get => alapteruletM2;
            set => alapteruletM2 = value < 10 ? 10 : value;
        }
        public int ArEzerFt
        { get => arEzerFt;
            set => arEzerFt = value < 10 ? 10 : value;
        }
        public static int OsszesRegisztraltIngatlan { get => osszesRegisztraltIngatlan; }
        public Ingatlan(string azonosito, string cim, string kategoria, int alapteruletM2) : this(azonosito, cim, kategoria, alapteruletM2, alapteruletM2 * 500)
        {
            
        }
        public Ingatlan(string azonosito, string cim, string kategoria, int alapteruletM2, int arEzerFt)
        {
            Azonosito = azonosito;
            Cim = cim;
            Kategoria = kategoria;
            AlapteruletM2 = alapteruletM2;
            ArEzerFt = arEzerFt;
            osszesRegisztraltIngatlan++;
        }
        public override string ToString()
        {
            return $"[{Azonosito}] {Cim} ({Kategoria}) - Terület: {AlapteruletM2} m2 | Ár: {ArEzerFt} ezer Ft";
        }
        public double NegyzetmeterAr()
        {
            return (ArEzerFt * 1000.0) / AlapteruletM2;
        }
        //public bool KategoriaEgyezik(string keresettKategoria)
        //{
        //    if (keresettKategoria.ToUpper == Kategoria.ToUpper)
        //    {
        //        return 
        //    }
        //}
    }
}
