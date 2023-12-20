using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_App
{
    internal class Enemy1 : Enemy
    {
        public string ImageUrl { get; set; }
        public int HP { get; set; }
        public int MAXHP { get; set; }
        public int xPos { get; set; }
        public bool Flying { get; set; }
        public bool WearingHat { get; set; }
        public int percentHealth { get; set; }
        public int dmg { get; set; }
        public bool LongRange { get; set; }
        public Enemy1(int hp, int maxhp, int xpos) : base(hp, maxhp, xpos)
        {
            HP = 10;
            MAXHP = 10;
            xPos = xpos;
            Flying = false;
            WearingHat = false;
            dmg = 1;
            LongRange = false;
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
