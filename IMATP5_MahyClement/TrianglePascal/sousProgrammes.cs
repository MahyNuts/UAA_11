using System;
using System.Collections.Generic;
using System.Text;

namespace TrianglePascal
{
    public struct sousProgrammes
    {
        public void GenerationUns(int n, ref int[,] M) //Génère les 1 de la première colonne et en diagonale
        {
            for(int i = 0; i < n; i++)
            {
                M[i, i] = 1;
                M[i, 0] = 1;
            }
        }

        public void CalculCases(int n, ref int[,] M)//Calcule l'addition de la valeur au dessus et en haut à gauche
        {
            for(int i = 1; i < n; i++)
            {
                for(int j = 2; j < n; j++)
                {
                    int k = M[i - 1, j - 1];
                    int l = M[i, j - 1];
                    M[i, j] = k + l;
                }
            }
        }

        public void Concatenation(int n, int[,] M, out string stringM)//Convertie la matrice en string pour pouvoir l'afficher
        {
            stringM = "";
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; i++)
                {
                    stringM += M[i, j] + " "; //Je pense avoir confondu dans quel sens vont les colonnes et les lignes
                }
                stringM += "\n";
            }
        }
    }
}
