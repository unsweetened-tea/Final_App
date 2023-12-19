using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_App
{
    internal class Enemy1 : Enemy
    {
        private string ImageUrl { get; set; }
        private int HP { get; set; }
        private int MAXHP { get; set; }
        private int xPos { get; set; }
        private bool Flying { get; set; }
        private bool WearingHat { get; set; }
        private int percentHealth { get; set; }
        private int dmg { get; set; }
        private bool LongRange { get; set; }
        public Enemy1(int xpos)
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
    }
}
