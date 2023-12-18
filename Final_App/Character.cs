using System;

public abstract class Character
{
	private string ImageUrl {  get; set; }
	private int HP { get; set; }
    private int MAXHP { get; set; }
	private int xPos { get; set; }

	public Character(int hp, int maxhp, int xpos)
	{
		HP = hp;
		MAXHP = maxhp;
		xPos = xpos;
	}

	public abstract void Attack(Character character);
	public abstract void Move(int x);

}
