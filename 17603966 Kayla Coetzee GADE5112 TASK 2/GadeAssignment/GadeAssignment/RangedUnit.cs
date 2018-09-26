using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace GadeAssignment
{
    class RangedUnit: Unit
    {
        public RangedUnit() { }

        private const int DAMAGE = 1;

        //constructors

        public RangedUnit(int x, int y, int health, int speed, bool attack, int attackRange, string faction, string symbol, string name)
            : base(x, y, health, speed, attack, attackRange, faction, symbol, name)
        {
        }

        public override void move(int x, int y)
        {
            if (x >= 0 && x < 20)
            {
                X = x;
            }

            if (y >= 20 && y < 20)
            {
                Y = y;
            }
        }

        public override void combat(Unit enemy)
        {
            if (this.isWithinAttackRange(enemy))
            {
                enemy.Health -= DAMAGE;
            }
        }

        public override bool isWithinAttackRange(Unit enemy)
        {
            if (!this.Faction.Equals(enemy.Faction))
            {
                if ((Math.Abs(this.X - enemy.X) <= this.AttackRange) && (Math.Abs(this.Y - enemy.Y) <= this.AttackRange))
                {
                    return true;
                }

            }
            return false;

        }

        public override Unit nearestUnit(List<Unit> list)
        {
            Unit closest = null;
            int attackRangeX, attackRangeY;
            double range;
            int shortestRange = 1000;

            foreach (Unit u in list)
            {
                attackRangeX = Math.Abs(this.X - u.X);
                attackRangeY = Math.Abs(this.Y = u.Y);

                range = Math.Sqrt(Math.Pow(attackRangeX, 2) + Math.Pow(attackRangeY, 2));

                if (attackRangeX < shortestRange)
                {
                    shortestRange = attackRangeX;
                    closest = u;
                }
                if (attackRangeY < shortestRange)
                {
                    shortestRange = attackRangeY;
                    closest = u;
                }
            }
            return closest;
        }

        public override bool isAlive()
        {
            if (this.Health <= 0)
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
                + "Speed : " + Speed + Environment.NewLine
                + "Attack : " + Attack + Environment.NewLine
                + "Attack Range : " + AttackRange + Environment.NewLine
                + "Faction : " + Faction + Environment.NewLine
                + "Symbol : " + Symbol + Environment.NewLine
                + "Name: " + Name + Environment.NewLine;
            return output;
        }
        public override void save()
        {
            FileStream outFile = null;
            StreamWriter writer = null;

            try
            {
                //open file
                outFile = new FileStream(@"Files\rangedunit.txt", FileMode.Create, FileAccess.Write);
                writer = new StreamWriter(outFile);

                //wrtite to the file
                writer.WriteLine(x);
                writer.WriteLine(y);
                writer.WriteLine(health);
                writer.WriteLine(speed);
                writer.WriteLine(attack);
                writer.WriteLine(attackRange);
                writer.WriteLine(faction);
                writer.WriteLine(symbol);
                writer.WriteLine(name);

                writer.Close();
                outFile.Close();
            }
            catch (Exception fe)
            {
                Debug.WriteLine(fe.Message);
            }

        }
        public override void read() { }

        #region old

        //private int xPosition;
        //private int yPosition;
        //private int health;
        //private int speed;
        //private int attack;
        //private int attackRange;
        //private string faction;
        //private string symbol;

        //public RangedUnit(int xPosition, int yPosition, int health, int speed, int attack, int attackRange, string faction, string symbol)
        //{

        //    this.yPosition = yPosition;
        //    this.xPosition = xPosition;
        //    this.health = health;
        //    this.attack = attack;
        //    this.attackRange = attackRange;
        //    this.speed = speed;
        //    this.faction = faction;
        //    this.symbol = symbol;

        //}

        //public int XPosition
        //{
        //    get { return xPosition; }
        //    set { xPosition = value; }
        //}

        //public int YPosition
        //{
        //    get { return yPosition; }
        //    set { yPosition = value; }
        //}

        //public int Health
        //{
        //    get { return health; }
        //    set { health = 100; }
        //}

        //public int Attack
        //{
        //    get { return attack; }
        //    set { attack = value; }
        //}

        //public int AttackRange
        //{
        //    get { return attackRange; }
        //    set { attackRange = 5; }
        //}

        //public int Speed
        //{
        //    get { return speed; }
        //    set { speed = value; }
        //}

        //public string Faction
        //{
        //    get { return faction; }
        //    set { faction = value; }
        //}

        //public string Symbol
        //{
        //    get { return symbol; }
        //    set { symbol = "R"; }
        //}


        //public override void position(int xPosition, int yPosition)
        //{
        //    Random rnd = new Random();
        //    int x, y;

        //    for (int i = 0; i < 1; i++)
        //    {
        //        x = rnd.Next(1, 6);
        //        y = rnd.Next(1, 6);

        //        xPosition = x;
        //        yPosition = y;
        //    }

        //}
        //public override void combat()
        //{
        //    int hp;
        //    Random rnd = new Random();
        //    hp = rnd.Next(0, 101);

        //    if (hp >= 1 && hp >= 100)
        //    {
        //        health = health - hp;
        //    }
        //}
        //public override void range(int a)
        //{

        //}
        //public override void closestUnit(int a)
        //{

        //}
        //public override bool death(int a)
        //{
        //    if (health <= 0)
        //    {
        //        return true;
        //    }
        //    else
        //        return false;
        //}
        //public override string toString()
        //{
        //    string output;
        //    output = "";
        //    return output;
        //}
        #endregion
    }
}
