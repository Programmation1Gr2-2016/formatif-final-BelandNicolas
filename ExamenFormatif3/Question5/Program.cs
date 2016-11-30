using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Nicolas Béland
 * 2016-11-29
 * Question no 5 de l'examen formatif 3
 */
namespace Question5
{
    class Program
    {
        static void Main(string[] args)
        {

            bool[] tableau = new bool[100];
            string[] tableauJoueur = new string[100];
            Random random = new Random();
            int position = 0;
            int nbEssai = 0;
            string touche;
            do
            {
                touche = "";

                for (int i = 0; i < tableau.Length; i++)
                {
                    if (random.Next(0, 2) == 1)
                    {
                        //est true
                        tableau[i] = true;
                    }
                    else
                    {//est false
                        tableau[i] = false;
                    }
                    tableauJoueur[i] = "-";
                }

                //Réservation de la cellule 0 et 99
                tableau[0] = true;
                tableau[99] = true;

                //Vérification automatique si le jeu dois se terminer maintenant
                if (tableau[position + 1] == false && tableau[position + 2] == false && tableau[position + 3] == false && tableau[position + 4] == false) //Impossible de continuer car 4 faux
                {
                    touche = "Q";
                }
                else if (position == 0 && tableau[2] == false && tableau[4] == false) //Bug joueur qui ne peut pas avancé directe au début
                {
                    touche = "Q";
                }

            } while (touche.ToUpper() == "Q");

            //On intéragie
            while (touche.ToUpper() != "Q")
            {
                Console.WriteLine("Position : " + position);
                Console.WriteLine("Nombre d'essai : " + nbEssai);
                Console.Write("Touche : ");
                touche = Console.ReadLine();
                Console.Clear();

                #region touche Switch
                switch (touche.ToUpper())
                {
                    case "A":

                        if (position - 3 >= 0 && tableau[position - 3] == true)
                        {
                            position -= 3;
                        }
                        else
                        {
                            Console.WriteLine("impossible, recommence!");
                        }
                        break;

                    case "S":
                        if (position - 2 >= 0 && tableau[position - 2] == true)
                        {
                            position -= 2;
                        }
                        else
                        {
                            Console.WriteLine("impossible, recommence!");
                        }
                        break;

                    case "D":
                        if (position - 1 >= 0 && tableau[position - 1] == true)
                        {
                            position -= 1;
                        }
                        else
                        {
                            Console.WriteLine("impossible, recommence!");
                        }
                        break;

                    case "G":
                        if (position + 2 <= tableau.Length && tableau[position + 2] == true)
                        {
                            position += 2;
                        }
                        else
                        {
                            Console.WriteLine("impossible, recommence!");
                        }
                        break;

                    case "H":
                        if (position + 4 <= tableau.Length && tableau[position + 4] == true)
                        {
                            position += 4;
                        }
                        else
                        {
                            Console.WriteLine("impossible, recommence!");
                        }
                        break;

                    case "Y":
                        AffichageEntier(tableau, tableauJoueur, position);
                        break;

                    case "P":
                        Affichage10(tableau, position);
                        break;

                    case "Q":
                        Console.WriteLine("Merci d'avoir jouer!");
                        Console.WriteLine("Position : " + position);
                        Console.WriteLine("Nombre d'essai : " + nbEssai);
                        Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("impossible, recommence!");
                        break;
                }
                #endregion

                nbEssai++;

                //Vérification automatique si le jeu dois se terminer maintenant

                if (tableau[position + 1] == false && tableau[position + 2] == false && tableau[position + 3] == false && tableau[position + 4] == false) //Impossible de continuer car 4 faux
                {
                    Console.WriteLine("Impossible de continuer, partie terminé!");
                    Console.WriteLine("Position : " + position);
                    Console.WriteLine("Nombre d'essai : " + nbEssai);
                    Console.ReadLine();
                    touche = "Q";
                }
                else if (position == tableau.Length) //Arrivé à la fin
                {
                    Console.WriteLine("Partie terminé, vous avez réussi!");
                    Console.WriteLine("Position : " + position);
                    Console.WriteLine("Nombre d'essai : " + nbEssai);
                    Console.ReadLine();
                    touche = "Q";
                }
                else if (position - 4 >= 0 && tableau[position - 1] == false && tableau[position - 2] == false && tableau[position - 3] == false && tableau[position + 2] == false && tableau[position + 4] == false) //Impossible de bouger
                {
                    Console.WriteLine("Impossible de continuer, partie terminé!");
                    Console.WriteLine("Position : " + position);
                    Console.WriteLine("Nombre d'essai : " + nbEssai);
                    Console.ReadLine();
                    touche = "Q";
                }

            }
        }
        public static void AffichageEntier(bool[] tableau, string[] tableauJoueur, int position)
        {
            //Affiche le tableau
            for (int i = 0; i < tableau.Length; i++)
            {
                Console.Write(tableau[i] + " ");
            }
            Console.WriteLine("\n");
            for (int i = 0; i < tableauJoueur.Length; i++)
            {
                if (i == position)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(tableauJoueur[i]);
                }
            }
            Console.WriteLine("\n");
        }
        public static void Affichage10(bool[] tableau, int position)
        {
            //Affiche uniquement les 10 cellules à la suite du personnage
            for (int i = position + 1; i < position + 11; i++)
            {
                if (i <= tableau.Length)
                {
                    Console.Write(tableau[i] + " ");
                }
            }
            Console.WriteLine("\n");
        }
    }
}
