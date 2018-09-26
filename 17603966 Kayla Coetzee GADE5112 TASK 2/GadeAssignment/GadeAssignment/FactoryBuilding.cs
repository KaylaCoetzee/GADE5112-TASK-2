using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace GadeAssignment
{
    class FactoryBuilding: Building
    {
        public string unitsToProduce;
        public int ticksPerProduction = 5;
        public int spawnPoint;

        //constructors
        public FactoryBuilding()
        {
            x = 4;
            y = 16;
            health = 100;
            faction = "Green";
            symbol = "#";
        }
        public FactoryBuilding(int x, int y, int health, string faction, string symbol)
            : base(x, y, health, faction, symbol)
        {

            this.x = x;
            this.y = y;
            this.health = health;
            this.faction = faction;
            this.symbol = symbol;

        }

        public void spawnUnits()
        {
            int unitSpawn;
            Random rnd = new Random();
            Random unit = new Random();
            unitSpawn = unit.Next(1, 3);
            if (unitSpawn % 2 == 0)
            {
                unitsToProduce = "M";

                if (rnd.Next(0,20) % 2 == 0)
                {
                    spawnPoint = x - 1;
                }

                else
                {
                    spawnPoint = x + 1;
                }

            }

            else
            {
                unitsToProduce = "R";

                if (rnd.Next(0, 20) % 2 == 0)
                {
                    spawnPoint = y - 1;
                }

                else
                {
                    spawnPoint = y + 1;
                }

            }
           
        }


        public override bool isActive()
        {
            if (Health <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public override string toString()
        {
            string output = "x : " + X + Environment.NewLine
                + "y : " + Y + Environment.NewLine
                + "Health : " + Health + Environment.NewLine
                + "Faction : " + Faction + Environment.NewLine
                + "Symbol : " + Symbol + Environment.NewLine;
            return output;
        }

        public override void save()
        {
            FileStream outFile = null;
            StreamWriter writer = null;

            try
            {
                //open file
                outFile = new FileStream(@"Files\factorybuilding.txt", FileMode.Create, FileAccess.Write);
                writer = new StreamWriter(outFile);

                //wrtite to the file
                writer.WriteLine(x);
                writer.WriteLine(y);
                writer.WriteLine(health);
                writer.WriteLine(faction);
                writer.WriteLine(symbol);

                writer.Close();
                outFile.Close();

            }
            catch (Exception fe)
            {
                Debug.WriteLine(fe.Message);
            }

        }
        public override void read() { }


    }
}
