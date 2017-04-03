using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FormationForHeroes
{
	[SerializeField]private CharacterHero[] _heroes;

	public CharacterHero[] heroes{ get { return _heroes; } }

	public FormationForHeroes ()
	{
		_heroes = new CharacterHero[6];
	}

	public CharacterHero SetHeroesToFormation (CharacterHero hero, int position)
	{
		CharacterHero current = _heroes [position];

		_heroes [position] = hero;

		if (current.str == 0 && current.intel == 0 && current.agi == 0)
			return null;
		
		return current;
	}

	public void AddCharacter (BaseCharacter c, int position, LineInFormtaion line)
	{
		c.line = line;
		CharacterHero h = new CharacterHero (c);
		_heroes [position] = h;// c as CharacterHero;
	}
}
