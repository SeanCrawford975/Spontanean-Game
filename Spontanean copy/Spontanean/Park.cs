using System;
using static System.Console;

namespace Spontanean
{
    public class Park
    {

        private Player newPlayer;
        public Park()
        {
            newPlayer = new Player(5, false, false, false);
        }

        public void Intro()
        {
            WriteLine("While the rest world is panicing over the end of the world you've headed south to explore the abandoned remains of Disneyland. As you're hopping the chainlink fence into the park, you spot $5 on the ground and put it in your pocket.");
            newPlayer.CheckBank();
            Menu.Continue();
            ExploreWarehouses();
        }

        public void ExploreWarehouses()
        {
            string prompt = "You find yourself amongst a city of warehouses near the back of Tom Sawyer Island. You can";
            string[] options = { "hop the fairy to the island", "continue to the center of the park" };
            Menu warehouseMenu = new Menu(prompt, options);
            int selectedIndex = warehouseMenu.RunMenu();

            switch(selectedIndex)
            {
                case 0:
                    //this used to be the raid tom sawyer island method
                    Clear();
                    WriteLine("Wow there's treasure for days on this island! You pocket $20 worth of gold and head back to the mainland.");
                    newPlayer.Money += 20;
                    newPlayer.CheckBank();
                    Menu.Continue();
                    ExploreWarehouses();
                    break;
                case 1:
                    ExploreCastle();
                    break;
            }
        }

        public void ExploreCastle()
        {
            string prompt = "The castle spires dwarf on you and you see the iconic statue of Walt Disney with his signature character, Mickey Mouse. You can";
            string[] options = { "enter Tomorrowland", "explore mainstreet", "go back to the warehouses" };
            Menu castleMenu = new Menu(prompt, options);
            int selectedIndex = castleMenu.RunMenu();

            switch (selectedIndex)
            {
                case 0:
                    EnterTomorrowland();
                    break;
                case 1:
                    ExploreMainstreet();
                    break;
                case 2:
                    ExploreWarehouses();
                    break;
            }
        }

        public void ExploreMainstreet()
        {
            string prompt = "Mainstreet is empty but the gift shop seems open and there seems to be a muffled two tone beat eminating from the firehouse. You can";
            string[] options = { "check out the firehouse", "enter the gift shop", "go back to the castle" };
            Menu mainstreetMenu = new Menu(prompt, options);
            int selectedIndex = mainstreetMenu.RunMenu();

            switch (selectedIndex)
            {
                case 0:
                    EnterFirehouse();
                    break;
                case 1:
                    newPlayer.EnterShop();
                    ExploreMainstreet();
                    break;
                case 2:
                    ExploreCastle();
                    break;
            }
        }

        public void EnterTomorrowland()
        {
            Clear();
            if (newPlayer.BalloonObtained == true)
            {
                if(newPlayer.CombObtained == true)
                {
                    //player has both items
                    string prompt = @"You stumble upon a group of scary looking men who call themselves ""the troops"". They appear to be armed, but you have a balloon and a comb at your disposal. What would you like to do?";
                    string[] options = { "Use balloon", "Use comb", "Retreat" };
                    Menu balloonAttack = new Menu(prompt, options);
                    int selectedIndex = balloonAttack.RunMenu();

                    switch (selectedIndex)
                    {
                        case 0:
                            UseBalloon();
                            break;
                        case 1:
                            UseComb();
                            break;
                        case 2:
                            ExploreCastle();
                            break;
                    }
                }
                else
                {
                    //player has balloon only
                    string prompt = @"You stumble upon a group of scary looking men who call themselves ""the troops"". They appear to be armed, but you have a balloon at your disposal. Do you want to use it?";
                    string[] options = { "Use balloon", "Retreat" };
                    Menu balloonAttack = new Menu(prompt, options);
                    int selectedIndex = balloonAttack.RunMenu();

                    switch (selectedIndex)
                    {
                        case 0:
                            UseBalloon();
                            break;
                        case 1:
                            ExploreCastle();
                            break;
                    }
                }
            }
            else
            {
                if(newPlayer.CombObtained == true)
                {
                    //player has comb only
                    string prompt = @"You stumble upon a group of scary looking men who call themselves ""the troops"". They appear to be armed, but you have a comb at your disposal. Do you want to use it?";
                    string[] options = { "Use comb", "Retreat" };
                    Menu combAttack = new Menu(prompt, options);
                    int selectedIndex = combAttack.RunMenu();

                    switch (selectedIndex)
                    {
                        case 0:
                            UseComb();
                            break;
                        case 1:
                            ExploreCastle();
                            break;
                    }
                }
                else
                {
                    //player has no items
                    WriteLine(@"You stumble upon a group of scary looking men who call themselves ""the troops"". They appear to be armed. Best to stay away.");
                    Menu.Continue();
                    ExploreCastle();
                }
            }
        }

        public void EnterFirehouse()
        {
            if (newPlayer.Money >= 3)
            {
                string prompt = "There is a band playing ska in the top floor of the firehouse. They call themselves ''The Improbable New Sensations''. They've got a tip jar. Do you wanna pitch in a few bucks?";
                string[] options = { "Yes", "No" };
                Menu firehouseMenu = new Menu(prompt, options);
                int selectedIndex = firehouseMenu.RunMenu();

                switch (selectedIndex)
                {
                    case 0:
                        newPlayer.Money -= 3;
                        newPlayer.Befriended = true;
                        newPlayer.CheckBank();
                        WriteLine("The band band stops playing and thanks you for your contribution. After talking for a little while you become good friends and decide to continue exploring as a group.");
                        Menu.Continue();
                        ExploreMainstreet();
                        break;
                    case 1:
                        ExploreMainstreet();
                        break;
                }
            }
            else
            {
                Clear(); 
                WriteLine("There is a band playing ska in the top floor of the firehouse. They call themselves ''The Improbable New Sensations''. They've got a tip jar, but you don't have much to give them.");
                Menu.Continue();
                ExploreMainstreet();
            }
        }

        public void UseBalloon()
        {
            Clear();
            WriteLine("The balloon alerts the troops to your presence and they quickly chase you away.");
            newPlayer.BalloonObtained = false;
            Menu.Continue();
            ExploreCastle();
        }

        public void UseComb()
        {
            Clear();
            WriteLine("The troops see your comb from afar and assume it to be a switch blade. Despite being heavily armed with post-apocalyptic artillery they are extremely intimidated by the prospect of engaging in combat and immediately scatter.");
            Menu.Continue();
            Clear();
            WriteLine(@"  
               ,n888888n,
             .8888888888b
             888888888888nd8P~''8g,
             88888888888888   _  `'~\.  .n.
             `Y888888888888. / _  |~\\ (8""8b
            ,nnn.. 8888888b.  |  \ \m\|8888P
          ,d8888888888888888b. \8b|.\P~ ~P8~
          888888888888888P~~_~  `8B_|      |
          ~888888888~'8'   d8.    ~      _/
           ~Y8888P'   ~\ | |~|~b,__ __--~
       --~~\   ,d8888888b.\`\_/ __/~
            \_ d88888888888b\_-~8888888bn.
              \8888P   ""Y888888888888""888888bn.
           /~'\_""__)      ""d88888888P,-~~-~888
          /  / )   ~\     ,888888/~' /  / / 8'
       .-(  / / / |) )-----------(/ ~  / /  |---.
______ | (   '    /_/  You've been (__/     /   |_______
\      |   (_(_ ( /~  crowned king  \___/_/'    |      /
 \     |     of post-apocalyptic Disneyland     |     /
 /     (________________________________________)     \
/__________)     __--|~mb  ,g8888b.         (__________\
               _/    8888b(.8P""~'~---__
              /       ~~~| / ,/~~~~--, `\
             (       ~\,_) (/         ~-_`\
              \  -__---~._ \             ~\\
              (           )\\              ))
              `\          )  ""-_           `|
                \__    __/      ~-__   __--~
                   ~~""~             ~~~");
            //ASCII art was obtained from https://www.asciiart.eu/cartoons/mickey-mouse
            WriteLine("It doesn't mean much now that the world has gone to shit but good on you");
            ReadKey(true);
        }


    }
}
