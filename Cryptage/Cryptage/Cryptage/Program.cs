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
            char[,] mttri;
            string chaineCrypt;

            do
            {
                Console.Clear();
                Console.WriteLine("Mot clé : ");
                cle = Console.ReadLine();
            } while (string.IsNullOrEmpty(cle));

            do
            {
                Console.Clear();
                Console.WriteLine("Texte : ");
                texte = Console.ReadLine();
            } while (string.IsNullOrEmpty(texte));

            sousP.RetireEspace(texte, out texte);
            sousP.DimensionneMat(cle, texte, out matrice);
            sousP.EcritChainesDansMat(cle, texte, ref matrice);
            sousP.ClasseCle(cle, out mttri);
            sousP.AttribueRang(ref matrice, ref mttri);
            sousP.RealiseCrypt(matrice, out chaineCrypt);

            Console.WriteLine(chaineCrypt);
        }
    }
}
