using System;

namespace TrianglePascal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n; //Nombre de lignes et de colonnes pour la matrice
            string stringM; //Matrice convertie en string
            sousProgrammes sousProgrammes = new sousProgrammes();
            do//Permet de donner une valeur supérieure à 0 à n
            {
                Console.WriteLine("Que souhaitez vous comme dimension ?");
                int.TryParse(Console.ReadLine(), out n);
            } while (n < 1);

            int[,] M = new int[n, n]; //Matrice ayant n comme nombre de ligne et colonne

            sousProgrammes.GenerationUns(n, ref M);//Génère les 1 de la première colonne et en diagonale
            sousProgrammes.CalculCases(n, ref M);//Calcule l'addition de la valeur au dessus et en haut à gauche
            sousProgrammes.Concatenation(n, M, out stringM);//Convertie la matrice en string pour pouvoir l'afficher

            Console.Write(stringM);//Affiche la matrice
        }
    }
}
