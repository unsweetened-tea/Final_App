using Final_App;
using System;

public abstract class Enemy
{
    public int hp { get; set; }
    public int maxhp { get; set; }
    public int xpos { get; set; }
    public bool flying { get; set; }
    public bool wearingHat { get; set; }
    public int percentHealth { get; set; }
    public int dmg { get; set; }
    public bool longRange { get; set; }

    public Enemy(int hp, int maxhp, int xpos, bool flying, bool wearingHat, int percentHealth, int dmg, bool longRange)
    {

    }

    public abstract void Move(int xPos);

    public abstract void Attack(Character character);

    public abstract void Heal();

    public abstract void Attack(Enemy enemy);

    public abstract void Run(Enemy enemy, int percentHealth);

    public abstract void update(Enemy enemy);



}
