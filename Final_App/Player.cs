using Final_App;
using System;

public class Player : Character
{
	internal Skin skin;

	internal List<Weapon> weapons;

	public int baseDmg {  get; set; }

	public double speed { get; set; }

	public int healPotionsHeld { get; set; }

	public int coins { get; set; }

	public Player(int hp, int maxhp, int xpos) : base (hp, maxhp, xpos)
	{

	}


	public override void Move(int dis)
	{
		this.xPos += dis;
	}

	public override void Attack(Character character)
	{
		if (character == null) return;
		if (character == this) return;
		character.HP -= baseDmg;
	}

    public override void Heal()
    {
        if (healPotionsHeld != 0) 
		{
			HP += 20;
			if (HP > MAXHP)
				HP = MAXHP;
			healPotionsHeld--;
		}
    }


}
