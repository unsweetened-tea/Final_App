using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_App
{
    internal class Enemy1 : Enemy
    {
        public int HP { get; set; }
        public int MAXHP { get; set; }
        public int xPos { get; set; }
        public bool Flying { get; set; }
        public bool WearingHat { get; set; }
        public int PercentHealth { get; set; }
        public int Dmg { get; set; }
        public bool LongRange { get; set; }
        public Enemy1(int hp, int maxhp, int xpos, bool flying, bool wearingHat, int percenthealth, int dmg, bool longRange)
        : base(hp, maxhp, xpos, flying, wearingHat, percenthealth, dmg, longRange)
        {
            // constructor implementation for Enemy1
        }
        public override void Attack(Enemy enemy)
        {

        }
        public override void Move(int x)
        {

        }

        public override void Run(Enemy enemy, int percentHealth)
        {

        }

        public override void update(Enemy enemy)
        {

        }

        public override void Heal()
        {
            throw new NotImplementedException();
        }

        public override void Attack(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
