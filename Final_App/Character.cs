using System;

public abstract class Character
{
	public string ImageUrl {  get; set; }
	public int HP { get; set; }
    public int MAXHP { get; set; }
	public int xPos
	{
		get { return xPos; }
		set
		{
			if (xPos <= 0)
			{ 
				xPos = 0;
			}
		}
	}

	public Character(int hp, int maxhp, int xpos)
	{
		HP = hp;
		MAXHP = maxhp;
		xPos = xpos;
	}

	public abstract void Attack(Character character, int baseDmg);
	public abstract void Move(int x);

	public abstract void Heal(int hp);

}
