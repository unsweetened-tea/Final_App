using Final_App;
using System;

public class Player : Character
{
	internal Skin skin;

	internal List<Weapon> weapons;

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

	public override void Attack(Character character, int baseDmg)
	{
		if (character == null) return;
		if (character == this) return;
		character.HP -= baseDmg;
	}

    public override void Heal(int hp)
    {
        if (healPotionsHeld != 0) 
		{
			hp += 20;
			if (hp > MAXHP)
				hp = MAXHP;
			healPotionsHeld--;
		}
    }


}
