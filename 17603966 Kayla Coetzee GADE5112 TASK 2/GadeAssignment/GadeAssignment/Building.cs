using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadeAssignment
{
    abstract class Building
    {
        //variables
        protected int x;
        protected int y;
        protected int health;
        protected string faction;
        protected string symbol;

        //constructors

        public Building()
        {

        } 
        public Building(int x, int y, int health, string faction, string symbol)
        {

            this.x = x;
            this.y = y;
            this.health = health;
            this.faction = faction;
            this.symbol = symbol;
        }

        //accessors

        public int X

        {
            get { return x; }
            set { x = value; }
        }
        public int Y

        {
            get { return y; }
            set { y = value; }
        }

        public int Health

        {
            get { return health; }
            set { health = value; }
        }


        public string Faction

        {
            get { return faction; }
            set { faction = value; }
        }
        public string Symbol

        {
            get { return symbol; }
            set { symbol = value; }
        }

        //destructor
        ~Building()
        {
        }

        public abstract bool isActive();
        public abstract string toString();

        //method

        public abstract void save();
        public abstract void read();

    }
}
