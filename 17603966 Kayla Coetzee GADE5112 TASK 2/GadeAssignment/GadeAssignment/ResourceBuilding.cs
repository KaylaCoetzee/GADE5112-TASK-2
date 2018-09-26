using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace GadeAssignment
{
    class ResourceBuilding: Building
    {
        public string resourceType;
        public int resourcesPerTick;
        public int resourcesRemaining;

        //constructors
        public ResourceBuilding()
        {
            x = 15;
            y = 9;
            health = 100;
            symbol = "$";
            resourceType = "Food";
            resourcesPerTick = 2;
            resourcesRemaining = 100;

        }
        public ResourceBuilding(int x, int y, int health, string faction, string symbol, string resourceType, int resourcesPerTick, int resourcesRemaining)
            : base(x, y, health, faction, symbol)
        {

            this.x = x;
            this.y = y;
            this.health = health;
            this.faction = faction;
            this.symbol = symbol;
            this.resourceType = resourceType;
            this.resourcesPerTick = resourcesPerTick;
            this.resourcesRemaining = resourcesRemaining;

        }

        public void generateResources()
        {
           

            for (int i = 0; i < resourcesRemaining; i++)
            {
                
                resourcesRemaining -= resourcesPerTick;

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
                outFile = new FileStream(@"Files\resourcebuilding.txt", FileMode.Create, FileAccess.Write);
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
