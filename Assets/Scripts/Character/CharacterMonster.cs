using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterMonster : BaseCharacter
{
	public int expEarnWhenKill;

	//TODO: item drop when kill;

	public CharacterMonster ()
	{
	}

	public CharacterMonster (BaseCharacter b)
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
}
