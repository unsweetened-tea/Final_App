using Final_App;
using System;

public class Enemy : Character
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

    public override void Attack(Character character, int baseDmg)
    {
        if (character == null) return;
        if (character == this) return;
        character.HP -= damage;
    }

    public override void Heal(int hp)
    {
        hp += 10;
    }


}
