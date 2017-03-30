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
