using System;
using System.Drawing;

namespace TheseusMinotaur
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string mapOne = ".___.___.___.   .\n|     M     |    \n.   .___.   .___.\n|       |     X  \n.   .___.   .___.\n|     T     |    \n.___.___.___.   .";
            string mapTwo = ".___.___.___.___.___.___.___.\n|                           |\n.   .   .   .   .   .   .   .\n| M |   | T                 |\n.   .___.   .   .   .   .   .\n|                   |   |   |\n.   .   .   .   .   .___.   .\n|                           |\n.___.   .___.___.___.___.___.\n    | X |                    \n.   .   .   .   .   .   .   .";
            Filer2 theFiler = new Filer2();
            theFiler.LoadAscii(mapOne);
            theFiler.ConvertToObjects();
            Console.ReadKey();*/

            //new Controller(new ConsoleView(), new Game2()).Init();

           LD_Creator theLD = new LD_Creator();

            //theLD.Init(4, 4);

            //theLD.Test();

            //theLD.SelectTile(2, 0);
            //theLD.SelectTile(2, 2);

            /*
            Console.WriteLine("should have walls");
            theLD.SetMinotaur();
            theLD.NorthWall();
            theLD.SouthWall();
            theLD.EastWall();
            theLD.WestWall();

            theLD.Test();

            Console.WriteLine("shouldn't have walls");
            theLD.NorthWall();
            theLD.SouthWall();
            theLD.EastWall();
            theLD.WestWall();
            theLD.Test();
            
            theLD.SelectTile(3, 3);
            theLD.Exit();
            theLD.SelectTile(3, 0);
            theLD.EastWall();

            theLD.SelectTile(0, 1);
            theLD.WestWall();

            theLD.SelectTile(2, 1);
            theLD.EastWall();


            theLD.SelectTile(1, 1);
            theLD.SetTheseus();
            theLD.NorthWall();
            theLD.SouthWall();


            theLD.Test(); */
            
           theLD.Init(4, 3);

           theLD.SelectTile(1, 0);
           theLD.SetMinotaur();

           theLD.SelectTile(1, 2);
           theLD.SetTheseus();


           theLD.SelectTile(0, 0);
           theLD.NorthWall();
           theLD.WestWall();

           theLD.SelectTile(1, 0);
           theLD.NorthWall();
           theLD.SouthWall();

           theLD.SelectTile(2, 0);
           theLD.NorthWall();
           theLD.EastWall();

           theLD.SelectTile(0, 1);
           theLD.WestWall();

           theLD.SelectTile(1, 1);
           theLD.EastWall();
           theLD.SouthWall();

           theLD.SelectTile(3, 1);
           theLD.NorthWall();
           theLD.SouthWall();
           theLD.Exit();

           theLD.SelectTile(0, 2);
           theLD.WestWall();
           theLD.SouthWall();

           theLD.SelectTile(1, 2);
           theLD.SouthWall();

           theLD.SelectTile(2, 2);
           theLD.SouthWall();
           theLD.EastWall();



            theLD.Init(MapCreator.ObjectsToString(theLD.GetMap(), theLD.GetTheseus(), theLD.GetMinotaur()));
            //theLD.LoadAscii(theLD.DrawMap());
            //Console.WriteLine(theLD.DrawMap());

            Console.WriteLine(MapCreator.ObjectsToString(theLD.GetMap(), theLD.GetTheseus(), theLD.GetMinotaur()));

            Console.ReadKey();



        }
    }
}
