using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterHero : BaseCharacter
{
	[SerializeField]protected int _maxLevel;
	[SerializeField]protected int _experience;
	[SerializeField]protected int _experienceLevelUp;

	[SerializeField]protected HeroType _heroTyoe;

	public CharacterHero ()
	{
	
	}

	public CharacterHero (BaseCharacter b)
	{
		name = b.name;
		str = b.str;
		agi = b.agi;
		intel = b.intel;
		atk = b.atk;
		matk = b.matk;
		def = b.def;
		mdef = b.mdef;
		acc = b.acc;
		eva = b.eva;
		speed = b.speed;

		line = b.line;
		baseTeam = b.baseTeam;
		posisionInTeam = b.posisionInTeam;
	}


	public void AddExp (int expAdd)
	{
		_experience += expAdd;

		if (_experience >= _experienceLevelUp)
			LevelUp ();
	}

	public void LevelUp ()
	{
		_experience = 0;

		level++;		
	}
}
