using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptage
{
    public struct SousProgrammes
    {
        public void RetireEspace(string chaine, out string chaineSSEsp)
        {
            chaineSSEsp = "";
            int lg = chaineSSEsp.Length;
            for(int i = 0; i < lg; i++)
            {
                if (chaine[i] != ' ')
                {
                    chaineSSEsp = chaineSSEsp + chaine[i];
                }
            }
        }
        
        public void DimensionneMat(string cle, string texte, out char[,] matrice)
        {
            int d1 = (texte.Length / cle.Length) + 2;
            int d2 = cle.Length;
            if (texte.Length % cle.Length != 0)
            {
                d1 = d1 + 1;
            }
            matrice = new char[d1, d2];
        }

        public void EcritChainesDansMat(string cle, string texte, ref char[,] matrice)
        {
            for(int j = 0; j < matrice.GetLength(1); j++)
            {
                matrice[0, j] = cle[j];
            }
            int k = 0;
            for(int i = 2; i < matrice.GetLength(0); i++)
            {
                int j = 0;
                do
                {
                    matrice[i, j] = texte[k];
                    k = k + 1;
                    j = j + 1;
                } while (j < matrice.GetLength(1) && (k < texte.Length));
            }
        }

        public void triLigne1(ref char[,] matrice)
        {
            bool permut;
            do
            {
                permut = false;
                for (int i = 0; i < matrice.GetLength(1); i++)
                {
                    if (matrice[0, i] > matrice[0, i + 1])
                    {
                        char varEch = matrice[0, 1];
                        matrice[0, 1] = matrice[0, i + 1];
                        matrice[0, i + 1] = varEch;
                        permut = false;
                    }
                }
            } while (permut == true);
        }

        public void ClasseCle(string cle, out char[,] mttri)
        {
            mttri = new char[3, cle.Length];
            for(int j = 0; j<mttri.GetLength(1); j++)
            {
                mttri[0, j] = cle[j];
                mttri[2, j] = '0';
            }
            triLigne1(ref mttri);
            for(int j = 1; j < mttri.GetLength(1); j++)
            {
                mttri[1, j - 1] = char.Parse(j.ToString());
            }
        }

        public void AttribueRang(ref char[,] matrice, ref char[,] mttri)
        {
            for (int i = 0; i < matrice.GetLength(1); i++)
            {
                bool trouve = false;
                int j = 0;
                while(trouve = false && j < mttri.GetLength(1))
                {
                    if (matrice[0,1] == mttri[0,j] && mttri[2,j] != '1')
                    {
                        matrice[i, j] = mttri[1, j];
                        mttri[2, j] = '1';
                        trouve = true;
                    }
                    j += 1;
                }
            }
        }

        public void RealiseCrypt(char[,] matrice, out string chaineCrypt)
        {
            int i = 1;
            chaineCrypt = "";
            while (i < matrice.GetLength(1))
            {
                bool trouve = false;
                int j = 0;
                while (!trouve && j < matrice.GetLength(1))
                {
                    if(i == matrice[1, j])
                    {
                        for(int k = 2; k < matrice.GetLength(0); k++)
                        {
                            chaineCrypt += matrice[k, j];
                        }
                        chaineCrypt += " ";
                        trouve = true;
                        i = i + 1;
                    }
                    j = j + 1;
                } 
            } 
        }
    }
}
