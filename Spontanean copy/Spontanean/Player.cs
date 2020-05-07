using System;
using static System.Console;

namespace Spontanean
{
    public class Player
    {
        public decimal Money;
        public bool Befriended;
        public bool CombObtained;
        public bool BalloonObtained;

        public Player(decimal money, bool befriended, bool combObtained, bool balloonObtained)
        {
            Money = money;
            Befriended = befriended;
            CombObtained = combObtained;
            BalloonObtained = balloonObtained;
        }

        public void CheckBank()
        {
            WriteLine($"Your current balence is ${Money}.");
        }

        public void EnterShop()
        {
            Clear();
            WriteLine("You walk into the gift shop! Most of the souvenirs have been cleared out but there are two items for sale:");

            Shop comb = new Shop("switchblade comb", "It's a gag gift hair-styling tool from the 80s meant to look like a weapon", 379);
            comb.Listing();
            Shop balloon = new Shop("single water balloon", "It's a pretty steep price for such a cheap object but times are tough", 25);
            balloon.Listing();

            CheckBank();

            string wouldYouLikeToBuy;
            Write("Would you like to buy either of these items?");
            wouldYouLikeToBuy = ReadLine().Trim().ToUpper();
            if (wouldYouLikeToBuy == "YES")
            {
                //proceedshopping

                string prompt = "What would you like to buy?";
                string[] options = { $"{comb.Name} (${comb.Price})", $"{balloon.Name} (${balloon.Price})" };
                Menu shopMenu = new Menu(prompt, options);
                int selectedIndex = shopMenu.RunMenu();

                switch (selectedIndex)
                {
                    case 0:
                        if (Money >= comb.Price)
                        {
                            Money -= comb.Price;
                            CombObtained = true;
                            WriteLine("You now have a comb!");
                            CheckBank();
                            Menu.Continue();
                            //return to mainstreet
                        }
                        else
                        {
                            if (Befriended == true)
                            {
                                CombObtained = true;
                                WriteLine("You do not have enough money, but Alex from The Improbable New Sensations says he can spot you a few bucks. You now have a comb!");
                                Menu.Continue();
                                //return to mainstreet
                            }
                            else
                            {
                                WriteLine("You do not have enough money!");
                                Menu.Continue();
                                //return to mainstreet
                            }
                        }
                        break;
                    case 1:
                        if (Money >= balloon.Price)
                        {
                            Money -= balloon.Price;
                            BalloonObtained = true;
                            WriteLine("You now have a balloon!");
                            CheckBank();
                            Menu.Continue();
                            //return to mainstreet
                        }
                        else
                        {
                            if (Befriended == true)
                            {
                                BalloonObtained = true;
                                WriteLine("You do not have enough money, but Alex from The Improbable New Sensations says he can spot you a few bucks. You now have a balloon!");
                                Menu.Continue();
                                //return to mainstreet
                            }
                            else
                            {
                                WriteLine("You do not have enough money!");
                                Menu.Continue();
                                //return to mainstreet
                            }
                        }
                        break;
                }
            }
            else
            {
                WriteLine("Okay!");
                Menu.Continue();
                //return to mainstreet
            }
        }
    }
}
