using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonteCarlo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1X2 VEIKKAUSLASKURI");
            Console.WriteLine("Copyright Tero Niemi");
            Console.WriteLine("==============================");
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Anna kotijoukkueen tehdyt maalit: ");
            double kotijoukkueentehdytmaalit = Convert.ToDouble(Console.ReadLine());
            Console.Write("Anna kotijoukkueen päästetyt maalit: ");
            double kotijoukkueenpaastetytmaalit = Convert.ToDouble(Console.ReadLine());
            Console.Write("Anna vierasjoukkueen tehdyt maalit: ");
            double vierasjoukkueentehdytmaalit = Convert.ToDouble(Console.ReadLine());
            Console.Write("Anna vierasjoukkueen päästetyt maalit: ");
            double vierasjoukkueenpaastetytmaalit = Convert.ToDouble(Console.ReadLine());
            Console.Write("Anna kotijoukkueen pelatut pelit: ");
            double kotijoukkueenpelatutpelit = Convert.ToDouble(Console.ReadLine());
            Console.Write("Anna vierasjoukkueen pelatut pelit: ");
            double vierasjoukkueenpelatutpelit = Convert.ToDouble(Console.ReadLine()); 


            double kotivoitto = 0;
            double tasapeli = 0;
            double vierasvoitto = 0;


           

            int laskuri = 0;
            
            Console.WriteLine("");
            Console.WriteLine("Suoritetaan Monte Carlo analyysi annetuilla arvoilla.\nSimuloidaan 2 000 000 peliä. Paina ENTER niin aloitetaan...");
            Console.ReadLine();

            Console.Write("Laskenta käynnissä...");
            for (laskuri=0; laskuri<2000000; laskuri++)
            {
               
                
                // alustetaan muuttujat
                double kotijoukkueetu = 1.1;
                double kotijoukkuetuuri = 1.0;
                double vierasjoukkuetuuri = 1.0;
                double kotijoukkueloukkaantuminen = 1.0;
                double vierasjoukkueloukkaantuminen = 1.0;
                double takkiaukikoti = 1.0;
                double takkiaukivieras = 1.0;
                bool rankkari = false;
                double tuloskoti = 0.00;
                double tulosvieras = 0.00;

                // arvotaan ottelulle uudet muuttujat
                Random random = new Random();
                if (random.NextDouble() < 0.2) kotijoukkuetuuri = 3;
                if (random.NextDouble() < 0.2) vierasjoukkuetuuri = 3;
                if (random.NextDouble() < 0.1) kotijoukkueloukkaantuminen = 0.5;
                if (random.NextDouble() < 0.1) vierasjoukkueloukkaantuminen = 0.5;
                if (random.NextDouble() < 0.05) takkiaukikoti = 0.2;
                if (random.NextDouble() < 0.05) takkiaukivieras = 0.2;
                if (random.NextDouble() < 0.02) kotijoukkuetuuri = 0.4;
                if (random.NextDouble() < 0.02) kotijoukkuetuuri = 0.4;
                if (random.NextDouble() < 0.02) tuloskoti = 1.0;
                if (random.NextDouble() < 0.02) tulosvieras = 1.0;
                if (random.NextDouble() < 0.04) rankkari = true;
                if (rankkari)
                {
                    if (random.NextDouble() < 0.3) tuloskoti = 1.0;
                    if (random.NextDouble() > 0.7) tulosvieras = 1.0;
                }

                // lasketaan tulos
                tuloskoti = Math.Round((tuloskoti + (kotijoukkueentehdytmaalit * kotijoukkueetu * kotijoukkuetuuri * kotijoukkueloukkaantuminen * takkiaukikoti + vierasjoukkueenpaastetytmaalit)/(kotijoukkueenpelatutpelit+vierasjoukkueenpelatutpelit)));
                tulosvieras = Math.Round((tulosvieras + (vierasjoukkueentehdytmaalit * vierasjoukkuetuuri * vierasjoukkueloukkaantuminen * takkiaukivieras + kotijoukkueenpaastetytmaalit)/(kotijoukkueenpelatutpelit+vierasjoukkueenpelatutpelit)));

                // ja tutkitaan 1X2
                if (tuloskoti>tulosvieras) kotivoitto++;
                if (tuloskoti<tulosvieras) vierasvoitto++;
                if (tuloskoti==tulosvieras) tasapeli++;

               
            }
            // ja ilmoitetaan prosentit
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Kotijoukkueen voittotodennäköiyys %: " + (kotivoitto / 2000000) * 100);
            Console.WriteLine("Tasapelin todennäköisyys %: " + (tasapeli / 2000000) * 100);
            Console.WriteLine("Vierasjoukkueen voittotodennäköisyys %: " + (vierasvoitto / 2000000) * 100);
          

            Console.ReadLine();
        }
    }
}
