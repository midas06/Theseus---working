using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusMinotaur
{
    class Filer
    {
        Tile[][,] allMyMaps = new Tile[8][,];
        Tile[,] theMap;
        Theseus theseus;
        Minotaur minotaur;


        protected Tile[,] CreateMap(int newWidth, int newHeight)
        {
            Tile[,] Map;
            int width = newWidth, height = newHeight;
            Map = new Tile[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Map[x, y] = new Tile(x, y);
                }
            }
            return Map;
        }
        protected Theseus SetTheseus(int newX, int newY)
        {
            theseus = new Theseus(newX, newY);
            return theseus;
        }
        protected Minotaur SetMinotaur(int newX, int newY)
        {
            minotaur = new Minotaur(newX, newY);
            return minotaur;
        }
        internal Minotaur GetMinotaur()
        {
            return minotaur;
        }
        internal Theseus GetTheseus()
        {
            return theseus;
        }


        protected void SetMapOne()
        {
            // create the map
            //Tile[,] 
            theMap = CreateMap(4, 3);
            theMap[0, 0].MyWalls = TheWalls.North | TheWalls.West;
            theMap[1, 0].MyWalls = TheWalls.North | TheWalls.South;
            theMap[2, 0].MyWalls = TheWalls.North | TheWalls.East;
            theMap[3, 0].MyWalls = TheWalls.West | TheWalls.South;

            theMap[0, 1].MyWalls = TheWalls.West;
            theMap[1, 1].MyWalls = TheWalls.North | TheWalls.East | TheWalls.South;
            theMap[2, 1].MyWalls = TheWalls.West;
            theMap[3, 1].MyWalls = TheWalls.North | TheWalls.South | TheWalls.End;

            theMap[0, 2].MyWalls = TheWalls.West | TheWalls.South;
            theMap[1, 2].MyWalls = TheWalls.South | TheWalls.North;
            theMap[2, 2].MyWalls = TheWalls.South | TheWalls.East;
            theMap[3, 2].MyWalls = TheWalls.North | TheWalls.West;

            // set positions of characters
            allMyMaps[1] = theMap;
        }


        protected void SetMapTwo()
        {
            theMap = CreateMap(7, 5);
            theMap[0, 0].MyWalls = TheWalls.North | TheWalls.West;
            theMap[6, 0].MyWalls = TheWalls.North | TheWalls.East;
            theMap[0, 3].MyWalls = TheWalls.West | TheWalls.South;
            theMap[6, 3].MyWalls = TheWalls.South | TheWalls.East;

            for (int i = 1; i < 6; i++)
            {
                theMap[i, 0].MyWalls = TheWalls.North;
            }
            for (int i = 1; i < 3; i++)
            {
                theMap[0, i].MyWalls = TheWalls.West;
            }
            for (int i = 1; i < 3; i++)
            {
                theMap[6, i].MyWalls = TheWalls.East;
            }
            for (int i = 2; i < 6; i++)
            {
                theMap[i, 3].MyWalls = TheWalls.South;
            }
            for (int i = 3; i < 7; i++)
            {
                theMap[i, 4].MyWalls = TheWalls.North;
            }

            theMap[0, 4].MyWalls = TheWalls.North | TheWalls.East;
            theMap[2, 4].MyWalls = TheWalls.North | TheWalls.West;
            theMap[1, 4].MyWalls = TheWalls.West | TheWalls.East | TheWalls.End;

            theMap[1, 1].MyWalls = TheWalls.East | TheWalls.West | TheWalls.South;
            theMap[0, 1].MyWalls = TheWalls.East | TheWalls.West;
            theMap[2, 1].MyWalls = TheWalls.West;
            theMap[1, 2].MyWalls = TheWalls.North;

            theMap[5, 2].MyWalls = TheWalls.East | TheWalls.West | TheWalls.South;
            theMap[4, 2].MyWalls = TheWalls.East;
            theMap[6, 2].MyWalls = TheWalls.West | TheWalls.East;
            theMap[5, 3].MyWalls = TheWalls.North | TheWalls.South;



            allMyMaps[2] = theMap;

        }

        protected void SetMapThree()
        {
            theMap = CreateMap(4, 4);

            for (int i = 0; i < 3; i++)
            {
                theMap[i, 0].MyWalls = TheWalls.North;
                theMap[i, 3].MyWalls = TheWalls.South;
            }
            for (int j = 0; j < 4; j++)
            {
                theMap[0, j].MyWalls = TheWalls.West;

                if (j != 1)
                {
                    theMap[2, j].MyWalls = TheWalls.East;
                    theMap[3, j].MyWalls = TheWalls.West;
                }

            }

            theMap[0, 0].MyWalls = TheWalls.North | TheWalls.West;
            theMap[2, 0].MyWalls = TheWalls.North | TheWalls.East;
            theMap[0, 3].MyWalls = TheWalls.North | TheWalls.West | TheWalls.South;
            theMap[2, 3].MyWalls = TheWalls.South | TheWalls.East;

            theMap[1, 0].MyWalls = TheWalls.North | TheWalls.South;
            theMap[1, 1].MyWalls = TheWalls.North;

            theMap[0, 2].MyWalls = TheWalls.West | TheWalls.South | TheWalls.East;
            theMap[1, 2].MyWalls = TheWalls.West;

            theMap[3, 0].MyWalls = TheWalls.South | TheWalls.West;
            theMap[3, 1].MyWalls = TheWalls.North | TheWalls.South | TheWalls.End;
            theMap[3, 2].MyWalls = TheWalls.North | TheWalls.West;







            allMyMaps[3] = theMap;
        }

        protected void SetMapFour()
        {
            theMap = CreateMap(5, 6);

            for (int i = 0; i <= 4; i++)
            {
                theMap[i, 5].MyWalls = TheWalls.South;

                if (i != 3)
                {
                    theMap[i, 0].MyWalls = TheWalls.South;
                    theMap[i, 1].MyWalls = TheWalls.North;
                }
            }
            for (int j = 1; j <= 5; j++)
            {
                theMap[0, j].MyWalls = TheWalls.West;
                theMap[4, j].MyWalls = TheWalls.East;
            }

            theMap[0, 1].MyWalls = TheWalls.North | TheWalls.West | TheWalls.East;
            theMap[1, 1].MyWalls = TheWalls.North | TheWalls.West;
            theMap[0, 0].MyWalls = TheWalls.South;

            theMap[4, 1].MyWalls = TheWalls.North | TheWalls.East;
            theMap[4, 0].MyWalls = TheWalls.West | TheWalls.South;

            theMap[0, 5].MyWalls = TheWalls.West | TheWalls.South;
            theMap[4, 5].MyWalls = TheWalls.South | TheWalls.East;

            theMap[1, 2].MyWalls = TheWalls.East | TheWalls.South;
            theMap[2, 2].MyWalls = TheWalls.West;
            theMap[1, 3].MyWalls = TheWalls.North | TheWalls.South;
            theMap[1, 4].MyWalls = TheWalls.North;

            theMap[3, 2].MyWalls = TheWalls.North | TheWalls.East;
            theMap[3, 1].MyWalls = TheWalls.South;
            theMap[4, 2].MyWalls = TheWalls.West | TheWalls.East;

            theMap[2, 3].MyWalls = TheWalls.South | TheWalls.East;
            theMap[3, 3].MyWalls = TheWalls.West;
            theMap[2, 4].MyWalls = TheWalls.North | TheWalls.East;
            theMap[3, 4].MyWalls = TheWalls.West | TheWalls.South | TheWalls.East;
            theMap[3, 5].MyWalls = TheWalls.North | TheWalls.South;
            theMap[4, 4].MyWalls = TheWalls.East | TheWalls.West;

            theMap[3, 0].MyWalls = TheWalls.East | TheWalls.West | TheWalls.End;


            allMyMaps[4] = theMap;

        }

        protected void SetMapFive()
        {
            theMap = CreateMap(7, 6);

            for (int i = 0; i < 7; i++)
            {
                theMap[i, 5].MyWalls = TheWalls.South;

                if (i != 5)
                {
                    theMap[i, 0].MyWalls = TheWalls.South;
                    theMap[i, 1].MyWalls = TheWalls.North;
                }
            }

            for (int i = 1; i < 6; i++)
            {
                theMap[0, i].MyWalls = TheWalls.West;
                theMap[6, i].MyWalls = TheWalls.East;
            }

            theMap[0, 1].MyWalls = TheWalls.North | TheWalls.West;
            theMap[0, 5].MyWalls = TheWalls.South | TheWalls.West;
            theMap[6, 5].MyWalls = TheWalls.South | TheWalls.East;

            theMap[6, 1].MyWalls = TheWalls.North | TheWalls.East | TheWalls.West;
            theMap[5, 1].MyWalls = TheWalls.East | TheWalls.South;
            theMap[5, 2].MyWalls = TheWalls.North | TheWalls.South;
            theMap[5, 3].MyWalls = TheWalls.North | TheWalls.South | TheWalls.East;
            theMap[6, 3].MyWalls = TheWalls.West | TheWalls.East;
            theMap[5, 4].MyWalls = TheWalls.North | TheWalls.West;

            theMap[4, 4].MyWalls = TheWalls.East | TheWalls.South | TheWalls.West;
            theMap[4, 5].MyWalls = TheWalls.North | TheWalls.South;
            theMap[3, 4].MyWalls = TheWalls.East | TheWalls.South;
            theMap[3, 5].MyWalls = TheWalls.North | TheWalls.South;
            theMap[2, 4].MyWalls = TheWalls.North | TheWalls.South | TheWalls.West;
            theMap[2, 5].MyWalls = TheWalls.North | TheWalls.South;
            theMap[1, 4].MyWalls = TheWalls.East;
            theMap[2, 3].MyWalls = TheWalls.South | TheWalls.East;
            theMap[3, 3].MyWalls = TheWalls.West;

            theMap[1, 2].MyWalls = TheWalls.West | TheWalls.South;
            theMap[0, 2].MyWalls = TheWalls.West | TheWalls.East;
            theMap[1, 3].MyWalls = TheWalls.North;

            theMap[3, 1].MyWalls = TheWalls.North | TheWalls.East;
            theMap[4, 1].MyWalls = TheWalls.North | TheWalls.West;

            theMap[3, 2].MyWalls = TheWalls.East;
            theMap[4, 2].MyWalls = TheWalls.West;

            theMap[5, 0].MyWalls = TheWalls.East | TheWalls.West | TheWalls.End;
            theMap[4, 0].MyWalls = TheWalls.East | TheWalls.South;
            theMap[6, 0].MyWalls = TheWalls.West | TheWalls.South;

            allMyMaps[5] = theMap;

        }

        protected void SetMapSix()
        {
            theMap = CreateMap(6, 7);

            for (int i = 0; i < 6; i++)
            {
                if (i != 4)
                {
                    theMap[i, 0].MyWalls = TheWalls.South;
                    theMap[i, 1].MyWalls = TheWalls.North;
                }
                theMap[i, 6].MyWalls = TheWalls.South;
            }
            for (int i = 1; i < 7; i++)
            {
                theMap[0, i].MyWalls = TheWalls.West;
                theMap[5, i].MyWalls = TheWalls.East;
            }

            theMap[0, 6].MyWalls = TheWalls.West | TheWalls.South;
            theMap[5, 6].MyWalls = TheWalls.South | TheWalls.East;
            theMap[0, 1].MyWalls = TheWalls.North | TheWalls.West | TheWalls.South;
            theMap[0, 2].MyWalls = TheWalls.North | TheWalls.West;
            
            theMap[5, 1].MyWalls = TheWalls.North | TheWalls.East | TheWalls.West;
            theMap[4, 1].MyWalls = TheWalls.East;

            theMap[5, 2].MyWalls = TheWalls.East | TheWalls.West;
            theMap[4, 2].MyWalls = TheWalls.East | TheWalls.South | TheWalls.West;
            theMap[3, 2].MyWalls = TheWalls.East;
            theMap[4, 3].MyWalls = TheWalls.North | TheWalls.South;
            theMap[4, 4].MyWalls = TheWalls.North | TheWalls.West;

            theMap[2, 2].MyWalls = TheWalls.West;
            theMap[1, 2].MyWalls = TheWalls.East | TheWalls.South;
            theMap[1, 3].MyWalls = TheWalls.North | TheWalls.East | TheWalls.West;
            theMap[0, 3].MyWalls = TheWalls.East | TheWalls.West;
            theMap[2, 3].MyWalls = TheWalls.West | TheWalls.South | TheWalls.East;
            theMap[3, 3].MyWalls = TheWalls.West;

            theMap[1, 4].MyWalls = TheWalls.West;
            theMap[0, 4].MyWalls = TheWalls.East | TheWalls.West;
            theMap[0, 5].MyWalls = TheWalls.East | TheWalls.West;
            theMap[1, 5].MyWalls = TheWalls.East | TheWalls.West;
            theMap[2, 5].MyWalls = TheWalls.West | TheWalls.North;
            theMap[2, 4].MyWalls = TheWalls.North | TheWalls.South;

            theMap[3, 0].MyWalls = TheWalls.East;
            theMap[4, 0].MyWalls = TheWalls.East | TheWalls.West | TheWalls.End;
            theMap[5, 0].MyWalls = TheWalls.West;

            theMap[3, 4].MyWalls = TheWalls.East;



            allMyMaps[6] = theMap;
        }

        protected void SetMapSeven()
        {
            theMap = CreateMap(6, 7);

            for (int i = 0; i < 6; i++)
            {
                if (i != 1)
                {
                    theMap[i, 0].MyWalls = TheWalls.South;
                    theMap[i, 1].MyWalls = TheWalls.North;
                }
                theMap[i, 6].MyWalls = TheWalls.South;
            }

            for (int i = 1; i < 7; i++)
            {
                theMap[0, i].MyWalls = TheWalls.West;
                theMap[5, i].MyWalls = TheWalls.East;
            }

            theMap[0, 1].MyWalls = TheWalls.North | TheWalls.West;
            theMap[0, 6].MyWalls = TheWalls.South | TheWalls.West;
            theMap[5, 6].MyWalls = TheWalls.South | TheWalls.East;
            theMap[5, 1].MyWalls = TheWalls.North | TheWalls.East | TheWalls.West;

            theMap[4, 1].MyWalls = TheWalls.North | TheWalls.East | TheWalls.South;
            theMap[4, 2].MyWalls = TheWalls.North | TheWalls.South;
            theMap[4, 3].MyWalls = TheWalls.North | TheWalls.East;
            
            theMap[5, 3].MyWalls = TheWalls.East | TheWalls.West;
            theMap[5, 4].MyWalls = TheWalls.East | TheWalls.West;
            theMap[4, 4].MyWalls = TheWalls.East | TheWalls.West | TheWalls.South;
            theMap[4, 5].MyWalls = TheWalls.North | TheWalls.East;
            theMap[5, 5].MyWalls = TheWalls.West | TheWalls.East;

            theMap[2, 5].MyWalls = TheWalls.South;
            theMap[2, 6].MyWalls = TheWalls.North | TheWalls.South;

            theMap[0, 4].MyWalls = TheWalls.West | TheWalls.South | TheWalls.East;
            theMap[1, 4].MyWalls = TheWalls.West;
            theMap[0, 5].MyWalls = TheWalls.West | TheWalls.North;

            theMap[0, 0].MyWalls = TheWalls.East | TheWalls.South;
            theMap[1, 0].MyWalls = TheWalls.West | TheWalls.East | TheWalls.End;
            theMap[2, 0].MyWalls = TheWalls.West | TheWalls.South;

            theMap[1, 1].MyWalls = TheWalls.South;
            theMap[1, 2].MyWalls = TheWalls.North;

            theMap[2, 2].MyWalls = TheWalls.East;
            theMap[3, 2].MyWalls = TheWalls.West;

            theMap[2, 3].MyWalls = TheWalls.East;
            theMap[3, 3].MyWalls = TheWalls.West;
            theMap[3, 4].MyWalls = TheWalls.East;



            allMyMaps[7] = theMap;
        }


        public void Init()
        {
            SetMapOne();
            SetMapTwo();
            SetMapThree();
            SetMapFour();
            SetMapFive();
            SetMapSix();
            SetMapSeven();
        }
        internal int GetTotalMaps()
        {
            return allMyMaps.Length - 1;
        }

        protected void SetCharacters(int theMap)
        {
            switch (theMap)
            {
                case 1:
                    minotaur = SetMinotaur(1, 0);
                    theseus = SetTheseus(1, 2);
                    break;
                case 2:
                    theseus = SetTheseus(2, 1);
                    minotaur = SetMinotaur(0, 1);
                    break;
                case 3:
                    theseus = SetTheseus(1, 1);
                    minotaur = SetMinotaur(1, 0);
                    break;
                case 4:
                    theseus = SetTheseus(1, 1);
                    minotaur = SetMinotaur(4, 2);
                    break;
                case 5:
                    theseus = SetTheseus(2, 1);
                    minotaur = SetMinotaur(2, 4);
                    break;
                case 6:
                    theseus = SetTheseus(0, 1);
                    minotaur = SetMinotaur(4, 3);
                    break;
                case 7:
                    theseus = SetTheseus(4, 5);
                    minotaur = SetMinotaur(0, 5);
                    break;
                default:
                    break;
            }
        }


        internal Tile[,] GetMap(int theMap)
        {
            SetCharacters(theMap);
            return allMyMaps[theMap];
        }

    }
}
