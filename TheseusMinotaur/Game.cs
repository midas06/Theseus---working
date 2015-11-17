using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheseusMinotaur
{
    class Game
    {}
}
//    /*{
//        /*Minotaur minotaur;
//        Theseus theseus;
//        Tile[,] theMap;
//        Filer theFiler;
//        IView theView;
//        int currentMap;

//        /**** Import Map from Filer */

//       /* public void Init(IView newView)
//        {
//            theFiler = new Filer();
//            theFiler.Init();
//            SetView(newView);
//        }


//        public bool SetMap(int aMap)
//        {
//            currentMap = aMap;
//            if (theFiler.GetMap(aMap) != null)
//            {
//                theMap = theFiler.GetMap(aMap);
//                SetTheseus(theFiler.GetTheseus());
//                SetMinotaur(theFiler.GetMinotaur());
//                return true;
//            }
//            return false;
//        }

//        public void Restart()
//        {
//            theMap = theFiler.GetMap(currentMap);
//            SetTheseus(theFiler.GetTheseus());
//            SetMinotaur(theFiler.GetMinotaur());
//            Run();
//        }

//        public void NextMap()
//        {
//            currentMap += 1;
//            theMap = theFiler.GetMap(currentMap);
//            SetTheseus(theFiler.GetTheseus());
//            SetMinotaur(theFiler.GetMinotaur());
//            Run();  
//        }

//        /*protected void SetTheseus(Theseus newTheseus)
//        {
//            theseus = newTheseus;
//            theseus.SetGame(this);
//        }
//        protected void SetMinotaur(Minotaur newMinotaur)
//        {
//            minotaur = newMinotaur;
//            minotaur.SetGame(this);
//        }*/

//        protected String DrawMap()
//        {
//            string output = "";
//            int width = theMap.GetLength(0);
//            int height = theMap.GetLength(1);


//            for (int y = 0; y < height; y++)
//            {
//                for (int x = 0; x < width; x++)
//                {
//                    output += ".";
//                    if (theMap[x, y].MyWalls.HasFlag(TheWalls.North))
//                    {
//                        output += "___";
//                    }
//                    else
//                    {
//                        output += "   ";
//                    }

//                }
//                output += ".\n";



//                for (int x = 0; x < width; x++)
//                {
//                    if (x != width - 1)
//                    {
//                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))// && !mapOne[x, y].MyWalls.HasFlag(TheWalls.East) 
//                        {
//                            output += "|   ";
//                        }
//                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))// && !mapOne[x, y].MyWalls.HasFlag(TheWalls.East) 
//                        {
//                            output += "    ";
//                        }

//                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
//                        {
//                            output += "| X ";
//                        }
//                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
//                        {
//                            output += "| X "; //"| X |";
//                        }
//                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
//                        {
//                            output += "  X "; //"  X |";
//                        }
//                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
//                        {
//                            output += "  X ";
//                        }
//                    }

//                    if (x == width - 1)
//                    {
//                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))
//                        {
//                            output += "|   ";
//                        }
//                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))
//                        {
//                            output += "|   |";
//                        }
//                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))
//                        {
//                            output += "    |";
//                        }
//                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))
//                        {
//                            output += "    ";
//                        }

//                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
//                        {
//                            output += "| X ";//"| X ";
//                        }
//                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
//                        {
//                            output += "| X ";//"| X |";
//                        }
//                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
//                        {
//                            output += "  X ";//"  X |";
//                        }
//                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
//                        {
//                            output += "  X ";
//                        }
//                    }


//                    if (x == minotaur.Coordinate.X && y == minotaur.Coordinate.Y)
//                    {
//                        StringBuilder minoPosition = new StringBuilder(output);
//                        minoPosition[output.Length - 2] = 'M';
//                        output = minoPosition.ToString();
//                    }
//                    if (x == theseus.Coordinate.X && y == theseus.Coordinate.Y)
//                    {
//                        StringBuilder thesPosition = new StringBuilder(output);
//                        thesPosition[output.Length - 2] = 'T';
//                        output = thesPosition.ToString();
//                    }

                    
                    

//                }
//                output += "\n";


//            }

//            // lowest row of map
//            for (int x = 0; x < width; x++)
//            {
//                output += ".";
//                if (theMap[x, height - 1].MyWalls.HasFlag(TheWalls.South))
//                {
//                    output += "___";
//                }
//                else
//                {
//                    output += "   ";
//                }
//            }
//            output += ".\n";


//           return output;
//        }



//        /**** Get functions for Thing class */
//        internal Tile[,] GetMap()
//        {
//            return theMap;
//        }

//        internal Theseus GetTheseus()
//        {
//            return theseus;
//        }
//        internal Minotaur GetMinotaur()
//        {
//            return minotaur;
//        }

//        /**** Test functions */
//        /*protected String TestMap(Tile[,] aMap)
//        {
//            string output = "";
//            foreach (Tile tile in aMap)
//            {
//                output += tile.Coordinate + " " + tile.MyWalls + "\n";
//            }
//            output += "minotaur " + minotaur.Coordinate + "\n" + "theseus " + theseus.Coordinate;
//            return output;
//        }*/


//        /**** Game functions */

//        // return the Player's move
//        protected Point PlayersTurn()
//        {
//            ConsoleKeyInfo theKey = Console.ReadKey(true);

//            if (theKey.Key == ConsoleKey.UpArrow)
//            {
//                return Direction.Up;
//            }
//            if (theKey.Key == ConsoleKey.DownArrow)
//            {
//                return Direction.Down;
//            }
//            if (theKey.Key == ConsoleKey.LeftArrow)
//            {
//                return Direction.Left;
//            }
//            if (theKey.Key == ConsoleKey.RightArrow)
//            {
//                return Direction.Right;
//            }
//            if (theKey.Key == ConsoleKey.A)
//            {
//                return Direction.Pass;
//            }
//            return new Point();
//        }

//        protected bool Move()
//        {
//            Point direction = PlayersTurn();
//            if (direction != null)
//            {
//                return (theseus.Move(direction));

//            }
//            return false;
//        }

//        protected bool IsGameOver()
//        {
//            if (theseus.IsFinished() || minotaur.HasEaten())
//            {
//                return true;
//            }
//            return false;
//        }

//        public int GetLevel()
//        {
//            return currentMap;
//        }
//        public int GetTotalMaps()
//        {
//            return theFiler.GetTotalMaps();
//        }

//        public void SetView(IView newView)
//        {
//            theView = newView;
//        }

//        /* The go button */
//        public bool Run()
//        {
//            theView.Start();
//            theView.Display("**** LEVEL " + currentMap.ToString() + " ****\n");
//            theView.Display(DrawMap());
//            while (IsGameOver() == false)
//            {
//                theView.Display("\nPress Up, Down, Left, Right to move; Press A to do nothing");
//                while (!Move())
//                {
//                    theView.Start();
//                    theView.Display("**** LEVEL " + currentMap.ToString() + " ****\n");
//                    theView.Display(DrawMap());
//                    theView.Display("\nPress Up, Down, Left, Right to move; Press A to do nothing");
//                    theView.Display("blocked");
//                }
//                if (!theseus.IsFinished())
//                {
//                    minotaur.Hunt();

//                }
//                theView.Start();
//                theView.Display("**** LEVEL " + currentMap.ToString() + " ****\n");
//                theView.Display(DrawMap());

//            }
//            if (IsGameOver() && theseus.IsFinished())
//            {
//                theView.Display("Congrats!");
//                return false;
//            }
//            if (IsGameOver() && minotaur.HasEaten())
//            {
//                theView.Display("You were eaten by the Minotaur :(\n");
//                theView.Display("Game over\n");
//                return false;
//            }
//            return true;
//        }


//    }
//}
