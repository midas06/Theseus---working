using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TheseusMinotaur
{
    class LD_Creator
    {
        int horizontal, vertical;
        Tile[,] theMap;
        Tile theTile;
        Theseus theseus;
        Minotaur minotaur;
        string[] mapArray;

        public void Init(int newHorizontal, int newVertical)
        {
            horizontal = newHorizontal - 1;
            vertical = newVertical - 1;

            theMap = MapCreator.CreateMap(newHorizontal, newVertical);
        }

        public void SelectTile(int theX, int theY)
        {
            theTile = theMap[theX, theY];
        }

        protected bool HasExit()
        {
            foreach (Tile tile in theMap)
            {
                if (tile.MyWalls.HasFlag(TheWalls.End))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsNorthmost()
        {
            if (theTile.Coordinate.Y == 0)
            {
                return true;
            }
            return false;
        }

        public bool IsSouthmost()
        {
            if (theTile.Coordinate.Y == vertical)
            {
                return true;
            }
            return false;
        }

        public bool IsWestmost()
        {
            if (theTile.Coordinate.X == 0)
            {
                return true;
            }
            return false;
        }

        public bool IsEastmost()
        {
            if (theTile.Coordinate.X == horizontal)
            {
                return true;
            }
            return false;
        }

        public void SetTheseus()
        {
            int x = theTile.Coordinate.X;
            int y = theTile.Coordinate.Y;

            if ((Object)theseus == null)
            {
                theseus = new Theseus(x, y);
            }

            // catch: minotaur/exit on same tile
        }

        public void SetMinotaur()
        {
            int x = theTile.Coordinate.X;
            int y = theTile.Coordinate.Y;

            if ((Object)minotaur == null)
            {
                minotaur = new Minotaur(x, y);
            }
           
            // catch: theseus on same tile
        }

        public void NorthWall()
        {
            Tile adjTile;
                      
            
            if (theTile.MyWalls.HasFlag(TheWalls.North))
            {
                theTile.MyWalls &= ~TheWalls.North;

                if (!IsNorthmost())
                {
                    adjTile = theMap[theTile.Coordinate.X, theTile.Coordinate.Y - 1];
                    adjTile.MyWalls &= ~TheWalls.South;
                }
            }
            else
            {
                theTile.MyWalls |= TheWalls.North;

                if (!IsNorthmost())
                {
                    adjTile = theMap[theTile.Coordinate.X, theTile.Coordinate.Y - 1];
                    adjTile.MyWalls |= TheWalls.South;
                }
            }
        }
        
        public void SouthWall()
        {
            Tile adjTile;
            if (theTile.MyWalls.HasFlag(TheWalls.South))
            {
                theTile.MyWalls &= ~TheWalls.South;

                if (!IsSouthmost())
                {
                    adjTile = theMap[theTile.Coordinate.X, theTile.Coordinate.Y + 1];
                    adjTile.MyWalls &= ~TheWalls.North;
                }
            }
            else
            {
                theTile.MyWalls |= TheWalls.South;

                if (!IsSouthmost())
                {
                    adjTile = theMap[theTile.Coordinate.X, theTile.Coordinate.Y + 1];
                    adjTile.MyWalls |= TheWalls.North;
                }
            }
        }

        public void EastWall()
        {
            Tile adjTile;


            if (theTile.MyWalls.HasFlag(TheWalls.East))
            {
                theTile.MyWalls &= ~TheWalls.East;

                if (!IsEastmost())
                {
                    adjTile = theMap[theTile.Coordinate.X + 1, theTile.Coordinate.Y];
                    adjTile.MyWalls &= ~TheWalls.West;
                }
            }
            else
            {
                theTile.MyWalls |= TheWalls.East;

                if (!IsEastmost())
                {
                    adjTile = theMap[theTile.Coordinate.X + 1, theTile.Coordinate.Y];
                    adjTile.MyWalls |= TheWalls.West;
                }
            }
        }

        public void WestWall()
        {
            Tile adjTile;


            if (theTile.MyWalls.HasFlag(TheWalls.West))
            {
                theTile.MyWalls &= ~TheWalls.West;

                if (!IsWestmost())
                {
                    adjTile = theMap[theTile.Coordinate.X - 1, theTile.Coordinate.Y];
                    adjTile.MyWalls &= ~TheWalls.East;
                }
            }
            else
            {
                theTile.MyWalls |= TheWalls.West;

                if (!IsWestmost())
                {
                    adjTile = theMap[theTile.Coordinate.X - 1, theTile.Coordinate.Y];
                    adjTile.MyWalls |= TheWalls.East;
                }
            }
        }

        public void Exit()
        {
            if (theTile.MyWalls.HasFlag(TheWalls.End))
            {
                theTile.MyWalls &= ~TheWalls.End;
            }
            else 
            {
                if (!HasExit())
                {
                    theTile.MyWalls |= TheWalls.End;
                }

            }
        }

        public Tile[,] GetMap()
        {
            return theMap;
        }
        public Theseus GetTheseus()
        {
            return theseus;
        }
        public Minotaur GetMinotaur()
        {
            return minotaur;
        }



        /**** TESTING AND SHIT ****/
        /*
        public String DrawMap()
        {
            string output = "";
            int width = theMap.GetLength(0);
            int height = theMap.GetLength(1);


            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    output += ".";
                    if (theMap[x, y].MyWalls.HasFlag(TheWalls.North))
                    {
                        output += "___";
                    }
                    else
                    {
                        output += "   ";
                    }

                }
                output += ".\n";



                for (int x = 0; x < width; x++)
                {
                    if (x != width - 1)
                    {
                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))// && !mapOne[x, y].MyWalls.HasFlag(TheWalls.East) 
                        {
                            output += "|   ";
                        }
                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))// && !mapOne[x, y].MyWalls.HasFlag(TheWalls.East) 
                        {
                            output += "    ";
                        }

                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "| X ";
                        }
                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "| X "; //"| X |";
                        }
                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "  X "; //"  X |";
                        }
                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "  X ";
                        }
                    }

                    if (x == width - 1)
                    {
                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "|    ";
                        }
                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "|   |";
                        }
                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "    |";
                        }
                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "     ";
                        }

                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "| X  ";//"| X ";
                        }
                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "| X  ";//"| X |";
                        }
                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "  X  ";//"  X |";
                        }
                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "  X  ";
                        }
                    }


                    if (x == minotaur.Coordinate.X && y == minotaur.Coordinate.Y)
                    {
                        StringBuilder minoPosition = new StringBuilder(output);
                        minoPosition[output.Length - 2] = 'M';
                        output = minoPosition.ToString();
                    }
                    if (x == theseus.Coordinate.X && y == theseus.Coordinate.Y)
                    {
                        StringBuilder thesPosition = new StringBuilder(output);
                        thesPosition[output.Length - 2] = 'T';
                        output = thesPosition.ToString();
                    }




                }
                output += "\n";


            }

            // lowest row of map
            for (int x = 0; x < width; x++)
            {
                output += ".";
                if (theMap[x, height - 1].MyWalls.HasFlag(TheWalls.South))
                {
                    output += "___";
                }
                else
                {
                    output += "   ";
                }
            }
            output += ".\n";


            return output;
        }
        */
        public void Init(string ascii)
        {
            mapArray = MapCreator.LoadAscii(ascii);
        }




        public void Test()
        {
            foreach (Tile tile in theMap)
            {
                Console.WriteLine("{0}, walls: {1}", tile.Coordinate, tile.MyWalls);
            }
            if (HasExit())
            {
                Console.WriteLine("Has end");
            }
            else
            {
                Console.WriteLine("no exit");
            }
            if ((Object)theseus != null)
            {
                Console.WriteLine("Theseus: {0}", theseus.Coordinate);
            }
           
        }

    }
}
