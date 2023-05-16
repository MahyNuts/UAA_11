using System;

namespace Cryptage
{
    class Program
    {
        static void Main(string[] args)
        {
            SousProgrammes sousP = new SousProgrammes();
            string cle;
            string texte;
            char[,] matrice;
            string chaineSSEsp;

            do
            {

                Console.WriteLine("Mot clé : ");
                cle = Console.ReadLine();
            } while (string.IsNullOrEmpty(cle));

            do
            {
                Console.WriteLine("Texte : ");
                texte = Console.ReadLine();
            } while (string.IsNullOrEmpty(texte));

            sousP.RetireEspace(texte, out chaineSSEsp);
            sousP.DimensionneMat(cle, texte, out matrice);
        }
    }
}
