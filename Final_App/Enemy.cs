using Final_App;
using System;

public abstract class Enemy : Character
{
    public int damage {  get; set; }
    public double speed { get; set; }

    public int coinsDropped { get; set; }

    public Enemy(int hp, int maxhp, int xpos) : base(hp, maxhp, xpos)
    {

    }

    public override void Move(int dis)
    {
        // if '+=' then we need negative dis
        this.xPos -= dis;
    }

    public override void Attack(Character character)
    {
        if (character == null) return;
        if (character == this) return;
        character.HP -= damage;
    }

    public override void Heal()
    {
        HP += 10;
    }

    public abstract void Attack(Enemy enemy);

    public abstract void Run(Enemy enemy, int percentHealth);

    public abstract void update(Enemy enemy);



}
