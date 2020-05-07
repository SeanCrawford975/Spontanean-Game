using System;
using static System.Console;

namespace Spontanean
{
    class Program
    {
        static void Main(string[] args)
        {
            Title = "Spontanean";
       
            WriteLine(@"   _____                   __                             
  / ___/____  ____  ____  / /_____ _____  ___  ____ _____ 
  \__ \/ __ \/ __ \/ __ \/ __/ __ `/ __ \/ _ \/ __ `/ __ \
 ___/ / /_/ / /_/ / / / / /_/ /_/ / / / /  __/ /_/ / / / /
/____/ .___/\____/_/ /_/\__/\__,_/_/ /_/\___/\__,_/_/ /_/ 
    /_/                                                   ");


            
            Park myPark = new Park();
            myPark.Intro();
            
        }
    }
}