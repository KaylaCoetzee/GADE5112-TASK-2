using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace GadeAssignment
{
    public class Map
    {
        
        private string[,] map = new string[20, 20];
        private MeleeUnit[] mU = new MeleeUnit[50];
        private int numberMeleeUnits = 0;
        private int numberRangeUnits = 0;


        private RangedUnit[] rU = new RangedUnit[50];

        //public string unitFaction;

        //public void team()
        //{
        //    Random rnd = new Random();
        //    int factionChoice = rnd.Next(1, 3);

        //    if (factionChoice == 1)
        //    {
        //        unitFaction = "G";
        //    }
        //    else if (factionChoice == 2)
        //    {
        //        unitFaction = "B";
        //    }

        //}


        public string initialiseMap()
        {
            string showMap = "";


            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    map[i, j] = ".";

                }
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    showMap += map[i, j];
                }
                showMap += "\n";
            }

            FactoryBuilding f = new FactoryBuilding(4, 16, 100, "Green", "#");
            factoryList.Add(f);
            map[4, 16] = factoryList[0].Symbol;
            ResourceBuilding rb = new ResourceBuilding(15, 9, 100, "Blue", "$", "Food", 2, 100);
            resourceList.Add(rb);
            map[15, 9] = resourceList[0].Symbol;

            return showMap;


        }

        public string redraw()
        {
            
            string display = "";
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    display += map[i, j] + " ";
                }
                display += Environment.NewLine;
            }
            return display;

            
        }
        //placing units in different teams

        private void placeMeleeUnit(int xPosition, int yPosition)
        {
            map[xPosition, yPosition] = "M";

        }
        private void placeRangeUnit(int xPosition, int yPosition)
        {
            map[xPosition, yPosition] = "R";

        }
        



        public void generateUnits()
        {

            //team();

            Random rnd = new Random();
                numberMeleeUnits = rnd.Next(0, 25);
                int x, y;

            //blue team

                for (int i = 0; i < numberMeleeUnits; i++)
                {
                    x = rnd.Next(0, 20);
                    y = rnd.Next(0, 20);
                    do
                    {
                    x = rnd.Next(0, 20);
                    y = rnd.Next(0, 20);
                    } while (map[x, y] != ".");


                    mU[i] = new MeleeUnit(x, y, 100, -1, true, 1, "B", "M", "Foot Soldier");
                    placeMeleeUnit(x, y);
                }

                //Random rand = new Random();
                numberRangeUnits = rnd.Next(0, 25);
                //int a, b;

                for (int i = 0; i < numberRangeUnits; i++)
                {
                    x = rnd.Next(0, 20);
                    y = rnd.Next(0, 20);
                    do
                    {
                        x = rnd.Next(0, 20);
                        y = rnd.Next(0, 20);
                    } while (map[x, y] != ".");

                    rU[i] = new RangedUnit(x, y, 100, -1, true, 5, "G", "R", "Archer");
                    placeRangeUnit(x, y);
                }

        }

        public void moveUnit()
        {

            
        }

        #region read
        //reading from a file
        private List<MeleeUnit> meleeList = new List<MeleeUnit>();
        private List<MeleeUnit> MeleeList
        {
            get { return meleeList; }
        }

        private List<RangedUnit> rangedList = new List<RangedUnit>();
        private List<RangedUnit> RangedList
        {
            get { return rangedList; }
        }

        private List<FactoryBuilding> factoryList = new List<FactoryBuilding>();
        private List<FactoryBuilding> FactoryBuilding
        {
            get { return factoryList; }
        }

        private List<ResourceBuilding> resourceList = new List<ResourceBuilding>();
        private List<ResourceBuilding> ResourceList

        {
            get { return resourceList; }
        }

   



        public void loadMap()
        {

            FileStream inFile = null;
            StreamReader reader = null;
            string input;
            int x;
            int y;
            int health;
            int speed;
            bool attack;
            int attackRange;
            string faction;
            string symbol;
            string name;
            string resourceType;
            int resourcesPerTick;
            int resourcesRemaining;

            try
            {
                inFile = new FileStream(@"Files\meleeunit.txt", FileMode.Open, FileAccess.Read);
                reader = new StreamReader(inFile);
                input = reader.ReadLine();      // priming read
                while (input != null)
                {
                    x = int.Parse(reader.ReadLine());
                    y = int.Parse(reader.ReadLine());
                    health = int.Parse(reader.ReadLine());
                    speed = int.Parse(reader.ReadLine());
                    attack = bool.Parse(reader.ReadLine());
                    attackRange = int.Parse(reader.ReadLine());
                    faction = reader.ReadLine();
                    symbol = reader.ReadLine();
                    name = reader.ReadLine();

                    MeleeUnit m = new MeleeUnit(x,y,health,speed,attack,attackRange,faction,symbol,name);
                    meleeList.Add(m);
                    input = reader.ReadLine();      // secondary read
                }
                reader.Close();
                inFile.Close();
            }
            catch (Exception fe)
            {
                Debug.WriteLine(fe.Message);
            }
            finally
            {
                if (inFile != null)
                {
                    reader.Close();
                    inFile.Close();
                }
            }
            
            
            try
            {
                inFile = new FileStream(@"Files\rangedunit.txt", FileMode.Open, FileAccess.Read);
                reader = new StreamReader(inFile);
                input = reader.ReadLine();      // priming read
                while (input != null)
                {
                    x = int.Parse(reader.ReadLine());
                    y = int.Parse(reader.ReadLine());
                    health = int.Parse(reader.ReadLine());
                    speed = int.Parse(reader.ReadLine());
                    attack = bool.Parse(reader.ReadLine());
                    attackRange = int.Parse(reader.ReadLine());
                    faction = reader.ReadLine();
                    symbol = reader.ReadLine();
                    name = reader.ReadLine();

                    RangedUnit r = new RangedUnit(x, y, health, speed, attack, attackRange, faction, symbol, name);
                    rangedList.Add(r);
                    input = reader.ReadLine();      // secondary read
                }
                reader.Close();
                inFile.Close();
            }
            catch (Exception fe)
            {
                Debug.WriteLine(fe.Message);
            }
            finally
            {
                if (inFile != null)
                {
                    reader.Close();
                    inFile.Close();
                }
            }

            try
            {
                inFile = new FileStream(@"Files\factorybuilding.txt", FileMode.Open, FileAccess.Read);
                reader = new StreamReader(inFile);
                input = reader.ReadLine();      // priming read
                while (input != null)
                {
                    x = int.Parse(reader.ReadLine());
                    y = int.Parse(reader.ReadLine());
                    health = int.Parse(reader.ReadLine());
                    faction = reader.ReadLine();
                    symbol = reader.ReadLine();
                    
                    FactoryBuilding f = new FactoryBuilding(x, y, health, faction, symbol);
                    factoryList.Add(f);
                    input = reader.ReadLine();      // secondary read
                }
                reader.Close();
                inFile.Close();
            }
            catch (Exception fe)
            {
                Debug.WriteLine(fe.Message);
            }
            finally
            {
                if (inFile != null)
                {
                    reader.Close();
                    inFile.Close();
                }
            }

            try
            {
                inFile = new FileStream(@"Files\resourcebuilding.txt", FileMode.Open, FileAccess.Read);
                reader = new StreamReader(inFile);
                input = reader.ReadLine();      // priming read
                while (input != null)
                {
                    x = int.Parse(reader.ReadLine());
                    y = int.Parse(reader.ReadLine());
                    health = int.Parse(reader.ReadLine());
                    faction = reader.ReadLine();
                    symbol = reader.ReadLine();
                    resourceType = reader.ReadLine();
                    resourcesPerTick = int.Parse(reader.ReadLine());
                    resourcesRemaining = int.Parse(reader.ReadLine());


                    ResourceBuilding rb = new ResourceBuilding(x, y, health, faction, symbol, resourceType, resourcesPerTick, resourcesRemaining);
                    resourceList.Add(rb);
                    input = reader.ReadLine();      // secondary read
                }
                reader.Close();
                inFile.Close();
            }
            catch (Exception fe)
            {
                Debug.WriteLine(fe.Message);
            }
            finally
            {
                if (inFile != null)
                {
                    reader.Close();
                    inFile.Close();
                }
            }

             
        }

        #endregion

        //public void (MeleeUnit, int x, int y)
        //{
        //    mU.X = x;
        //    meleeUnit.Y = y;
        //}

        //public void update(Map.mU)
        //{
        //    map[uRange.X, uRange.Y] = ".";
        //    position(mU, new X, new Y);
        //    map[mU.X, M.Y] = ".";
        //}
    }

}

