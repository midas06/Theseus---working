using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TheseusMinotaur
{
    class Filer2
    {
        Tile[,] theMap;
        Theseus theseus;
        Minotaur minotaur;
        string[] mapArray;
        int x, y;

  
        protected void SetTheseus(int newX, int newY)
        {
            theseus = new Theseus(newX, newY);
        }
        protected void SetMinotaur(int newX, int newY)
        {
            minotaur = new Minotaur(newX, newY);
        }
        public Theseus GetTheseus()
        {
            return theseus;
        }
        public Minotaur GetMinotaur()
        {
            return minotaur;
        }

        //public void LoadAscii(string ascii)

        public void Init(string ascii)
        {
            /***
             * Initialise map variables - width, height, & break into string array
             * */
            int length;

            mapArray = MapCreator.LoadAscii(ascii);
            //Console.WriteLine(mapArray.Length);
            /*foreach (string line in mapArray)
            {
                Console.WriteLine(line + Environment.NewLine);
            }*/

            // get length of each string array
            // TO DO ***************
            // Catch throw if map isn't formatted correctly
            length = mapArray[0].Length;

            //Console.WriteLine("the longest line is {0} characters", longest);
            x = (length - 1) / 4;

            //Console.WriteLine("# of line breaks = {0}", Regex.Matches(ascii, "\n").Count);
            y = Regex.Matches(ascii, "\n").Count / 2;

            //Console.WriteLine("x = {0}, y = {1}", x, y);

            theMap = MapCreator.CreateMap(x, y);
        }

        public void ConvertToObjects(int startingPoint)
        {
            Tile theTile;

            // for every horizontal tile, check characters in string array to see if a wall is present
            for (int xTiles = 0; xTiles < x; xTiles++)
            {
                theTile = theMap[xTiles, startingPoint];
                int startingCharX = (xTiles * 4);
                int startingCharY = startingPoint * 2;
                int north, south, east, west, centre;
                north = startingCharX + 2;
                west = startingCharX;
                east = startingCharX + 4;
                south = startingCharX + 2;
                centre = startingCharX + 2;


                if (mapArray[startingCharY][north] == '_')
                {
                    theTile.MyWalls |= TheWalls.North;
                }
                if (mapArray[startingCharY + 1][west] == '|')
                {
                    theTile.MyWalls |= TheWalls.West;
                }
                if (mapArray[startingCharY + 1][east] == '|')
                {
                    theTile.MyWalls |= TheWalls.East;
                }
                if (mapArray[startingCharY + 2][south] == '_')
                {
                    theTile.MyWalls |= TheWalls.South;
                }
                if (mapArray[startingCharY + 1][centre] == 'X')
                {
                    theTile.MyWalls |= TheWalls.End;
                }
                if (mapArray[startingCharY + 1][centre] == 'T')
                {
                    SetTheseus(theTile.Coordinate.X, theTile.Coordinate.Y);
                }
                if (mapArray[startingCharY + 1][centre] == 'M')
                {
                    SetMinotaur(theTile.Coordinate.X, theTile.Coordinate.Y);
                }
            }
        }


        public void ObjectifyMap()
        {
            for (int row = 0; row < y; row++)
            {
                ConvertToObjects(row);
            }
        }


        public Tile[,] GetMap()
        {
            ObjectifyMap();
            return theMap;
        }

    }
}
