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
            int lg = chaine.Length;
            for (int i = 0; i < lg; i++)
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
            for (int j = 0; j < matrice.GetLength(1); j++)
            {
                matrice[0, j] = cle[j];
            }
            int k = 0;
            for (int i = 2; i < matrice.GetLength(0); i++)
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
            int n = matrice.GetLength(1);
            int EC = n / 2;
            while (EC >= 1)
            {
                bool permut = false;
                do
                {
                    permut = false;
                    for (int i = 0; i <= n - 1 - EC; i++)
                    {
                        if (matrice[0, i] > matrice[0, i + EC])
                        {
                            char tampon = matrice[0, i];
                            matrice[0, i] = matrice[0, i + EC];
                            matrice[0, i + EC] = tampon;
                            permut = true;
                        }
                    }
                } while (permut);
                EC = EC / 2;
            }
        }

        public void ClasseCle(string cle, out char[,] mttri)
        {
            mttri = new char[3, cle.Length];
            for (int j = 0; j < mttri.GetLength(1); j++)
            {
                mttri[0, j] = cle[j];
                mttri[2, j] = '0';
            }
            triLigne1(ref mttri);
            for (int j = 0; j < mttri.GetLength(1); j++)
            {
                mttri[1, j] = char.Parse((j + 1).ToString());
            }
        }

        public void AttribueRang(ref char[,] matrice, ref char[,] mttri)
        {
            for (int i = 0; i < matrice.GetLength(1); i++)
            {
                bool trouve = false;
                int j = 0;
                while (trouve == false && j < mttri.GetLength(1))
                {
                    if (matrice[0, i] == mttri[0, j] && mttri[2, j] != '1')
                    {
                        matrice[1, i] = mttri[1, j];
                        mttri[2, j] = '1';
                        trouve = true;
                    }
                    j += 1;
                }
            }
        }

        public int charToInt(char c)
        {
            int i;
            switch (c)
            {
                case '0':
                    i = 0;
                    break;
                case '1':
                    i = 1;
                    break;
                case '2':
                    i = 2;
                    break;
                case '3':
                    i = 3;
                    break;
                case '4':
                    i = 4;
                    break;
                case '5':
                    i = 5;
                    break;
                case '6':
                    i = 6;
                    break;
                case '7':
                    i = 7;
                    break;
                case '8':
                    i = 8;
                    break;
                case '9':
                    i = 9;
                    break;
                default:
                    i = -1;
                    break;
            }
            return i;
        }

        public void RealiseCrypt(char[,] matrice, out string chaineCrypt)
        {
            int i = 1;
            chaineCrypt = "";
            while (i <= matrice.GetLength(1))
            {
                bool trouve = false;
                int j = 0;
                while (!trouve && j < matrice.GetLength(1))
                {
                    if (i == charToInt(matrice[1, j]))
                    {
                        for (int k = 2; k < matrice.GetLength(0); k++)
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
