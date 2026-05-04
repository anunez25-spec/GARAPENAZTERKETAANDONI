namespace _3POO_5
{
    /// <summary>
    /// Aplikazioaren sarrera-puntua eta porra-sistemaren kontrol-flujo nagusia kudeatzen duen klasea.
    /// Fitxategitik datuak irakurri, menua erakutsi, emaitzak sartu eta eguneratutako
    /// puntuazioak fitxategira idazteaz arduratzen da.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Memoriako porra-zerrenda osoa gordetzen duen zerrenda estatikoa.
        /// <see cref="FitxategiaIrakurri"/> metodoak kargatzen du eta
        /// <see cref="FitxategiraPuntuak"/> metodoak gordetzen du.
        /// </summary>
        static List<Porra> lp = new List<Porra>();

        /// <summary>
        /// Aplikazioaren sarrera-puntua. Fitxategia irakurri eta menu nagusia erakusten du
        /// erabiltzaileak irten arte.
        /// </summary>
        static void Main()
        {
            int eragiketa;
            FitxategiaIrakurri();
            {
                do
                {
                    Console.WriteLine("***** PORRA ***********");
                    Console.WriteLine("Ze ariketa nahi duzun egin? Sartu bere zenbakia:");
                    Console.WriteLine("1.- Egungo porra ikusi");
                    Console.WriteLine("2.- Emaitzak sartu");
                    Console.WriteLine("3.- IRTEN");
                    eragiketa = int.Parse(Console.ReadLine());
                    switch (eragiketa)
                    {
                        case 1:
                            InprimatuPorrak();
                            break;
                        case 2:
                            SartuEmaitzak();
                            break;
                        case 3:
                            FitxategiraPuntuak();
                            return;
                        default:
                            Console.WriteLine(" *****ERAGIKETA EZ ONARTUA *****");
                            break;
                    }
                } while (eragiketa != 3);
            }
        }

        /// <summary>
        /// Erabiltzaileari partidako bi finalistak, irabazlea eta gol egile bakoitzaren
        /// datuak eskatzen dizkio, eta horiei dagozkien puntuazioak eguneratzen ditu.
        /// </summary>
        static void SartuEmaitzak()
        {
            Console.WriteLine("Zein izan dira gaurko bi arerioak, finalistak?");
            string are1 = Console.ReadLine();
            string are2 = Console.ReadLine();
            FinalisteiPuntuEguneraketa(are1, are2);
            Console.WriteLine("Eta zein izan da irabazlea? Enpate egon bada sakatu intro");
            string ir = Console.ReadLine();
            IrabazleeiPuntuEguneraketa(ir);
            int golkop = lortugolak();
            for (int i = 1; i <= golkop; i++)
            {
                Console.WriteLine("Sartu " + i + ". golaren egilea:");
                string goleatzaile = Console.ReadLine();
                GoleatzaileenPuntuEguneraketa(goleatzaile);
            }
        }

        /// <summary>
        /// Erabiltzaileari partidan izandako gol kopurua eskatzen dio.
        /// Baliogabeko sarrera bat ematen bada, berriro eskatzen du.
        /// </summary>
        /// <returns>Erabiltzaileak sartutako gol kopuru balioduna.</returns>
        static int lortugolak()
        {
            while (true)
            {
                Console.WriteLine("Zenbat gol egon dira gaur?");
                try
                {
                    int golkop = int.Parse(Console.ReadLine());
                    return golkop;
                }
                catch
                {
                    Console.Write("Zenbaki desegokia...");
                }
            }
        }

        /// <summary>
        /// Irabazlea asmatzen duten parte-hartzaile guztien puntuazioak 25 puntutan eguneratzen ditu.
        /// <see cref="Porra.AsmatuIrabazlea"/> metodoa erabiltzen du puntuazioa kalkulatzeko.
        /// </summary>
        /// <param name="ir">Partidaren irabazlearen talde-izena.</param>
        static void IrabazleeiPuntuEguneraketa(string ir)
        {
            for (int i = 0; i < lp.Count; i++)
            {
                if (lp[i].Irabazlea == ir)
                {
                    lp[i].Puntuak = lp[i].AsmatuIrabazlea();
                }
            }
        }

        /// <summary>
        /// Bi finalistak asmatzen dituzten parte-hartzaile guztien puntuazioak 20 puntutan eguneratzen ditu.
        /// Ordena axola ez duenez, bi konbinazio posibleak konprobatzen ditu.
        /// <see cref="Porra.AsmatuBiFinalistak"/> metodoa erabiltzen du.
        /// </summary>
        /// <param name="fi">Finalistetako lehenengoaren talde-izena.</param>
        /// <param name="ir">Finalistetako bigarrenaren talde-izena.</param>
        static void FinalisteiPuntuEguneraketa(string fi, string ir)
        {
            for (int i = 0; i < lp.Count; i++)
            {
                if (((lp[i].Finalista == fi) && (lp[i].Irabazlea == ir) || (lp[i].Finalista == ir) && (lp[i].Irabazlea == fi)))
                {
                    lp[i].Puntuak = lp[i].AsmatuBiFinalistak();
                }
            }
        }

        /// <summary>
        /// Gol-egile jakin bat asmatzen duten parte-hartzaile guztien puntuazioak 3 puntutan eguneratzen ditu.
        /// <see cref="Porra.Goleko"/> metodoa erabiltzen du.
        /// </summary>
        /// <param name="gol">Gola sartu duen jokalariren izena.</param>
        static void GoleatzaileenPuntuEguneraketa(string gol)
        {
            for (int i = 0; i < lp.Count; i++)
            {
                if (lp[i].Goleatzailea == gol)
                {
                    lp[i].Puntuak = lp[i].Goleko();
                }
            }
        }

        /// <summary>
        /// <c>porrak.txt</c> fitxategitik porra-zerrenda osoa irakurri eta <see cref="lp"/> zerrendan kargatzen du.
        /// Lerro bakoitza gidoi bidez banatuta dago: <c>izena-irabazlea-finalista-goleatzailea-puntuak</c>.
        /// </summary>
        static void FitxategiaIrakurri()
        {
            StreamReader sr = new StreamReader("porrak.txt");
            String lerroa;
            lerroa = sr.ReadLine();
            while (lerroa != null)
            {
                string[] zatitua = lerroa.Split("-");
                Porra p = new Porra(zatitua[0], zatitua[1], zatitua[2], zatitua[3], int.Parse(zatitua[4]));
                lp.Add(p);
                lerroa = sr.ReadLine();
            }
            sr.Close();
        }

        /// <summary>
        /// <see cref="lp"/> zerrendako porra-objektu guztiak <c>porrak.txt</c> fitxategian gordetzen ditu.
        /// <see cref="Porra.ToString"/> metodoa erabiltzen du lerro bakoitzaren formatua lortzeko.
        /// Fitxategia osoki gainidazten da (<c>append: false</c>).
        /// </summary>
        static void FitxategiraPuntuak()
        {
            StreamWriter sw = new StreamWriter("porrak.txt", false);
            foreach (Porra p in lp)
            {
                sw.WriteLine(p.ToString());
            }
            sw.Close();
        }

        /// <summary>
        /// <see cref="lp"/> zerrendako porra-objektu guztiak kontsolan inprimatzen ditu.
        /// Bakoitzarentzat <see cref="Porra.Pantailaratu"/> metodoa deitzen du.
        /// </summary>
        static void InprimatuPorrak()
        {
            Console.WriteLine("************************** EGUNGO PORRAREN EGOERA **********************************");
            foreach (Porra p in lp)
            {
                Console.WriteLine(p.Pantailaratu());
            }
            Console.WriteLine("");
        }
    }
}
