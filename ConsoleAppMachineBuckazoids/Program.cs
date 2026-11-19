using System.ComponentModel.Design;

namespace ConsoleAppMachineBuckazoids
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int JACKPOT_DEPART = 100;
            string[] symboles = { "Fusée", "Alien", "Planète", "Comète", "Robot", "Étoile" };
            int[] rouleaux = new int[3];
            Random alea = new Random();

            int jackpot = JACKPOT_DEPART;
            int buckazoids = 20;
            int credits = 0;
            int choix;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Machine à buckazoids");
                Console.WriteLine("--------------------");
                Console.WriteLine("Montant du jackpot : {0}", jackpot);
                Console.WriteLine("Buckazoids : {0}", buckazoids);
                Console.WriteLine("Crédits : {0}", credits);
                Console.WriteLine("1 - Insérer une pièce");
                Console.WriteLine("2 - Jouer");
                Console.WriteLine("3 - Quitter");
                Console.Write("Votre choix : ");

                if (!int.TryParse(Console.ReadLine(), out choix))
                {
                    choix = 0;
                }

                if (choix == 1)
                {
                    if (buckazoids > 0)
                    {
                        buckazoids = buckazoids - 1;
                        credits = credits + 1;
                        jackpot = jackpot + 1;
                    }
                    else
                    {
                        Console.WriteLine("Plus de buckazoids en poche !");
                    }
                }
                else if (choix == 2)
                {
                    if (credits == 0)
                    {
                        Console.WriteLine("Insérer d’abord une pièce.");
                    }
                    else
                    {
                        credits = credits - 1;

                        for (int i = 0; i < rouleaux.Length; i++)
                        {
                            rouleaux[i] = alea.Next(0, symboles.Length);
                        }

                        Console.WriteLine("--------------------------------------------");
                        Console.Write("|");
                        for (int i = 0; i < rouleaux.Length; i++)
                        {
                            Console.Write(" {0} |", symboles[rouleaux[i]]);
                        }
                        Console.WriteLine();
                        Console.WriteLine("--------------------------------------------");

                        if (rouleaux[0] == rouleaux[1] && rouleaux[1] == rouleaux[2])
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("JACKPOT ! Vous gagnez {0} buckazoids !", jackpot);
                            Console.ResetColor();
                            buckazoids = buckazoids + jackpot;
                            jackpot = JACKPOT_DEPART;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Perdu !");
                            Console.ResetColor();
                        }
                    }
                }
                else if (choix != 3)
                {
                    Console.WriteLine("Choix inconnu.");
                }

            } while (choix != 3);

            Console.WriteLine("Vous quittez le bar avec {0} buckazoids.", buckazoids);
        }
    }
}   
        
