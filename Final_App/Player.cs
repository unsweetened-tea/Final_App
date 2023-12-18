using System;

public class Player : Character
{
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


}
