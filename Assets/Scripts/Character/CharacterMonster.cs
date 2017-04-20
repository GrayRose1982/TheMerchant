using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterMonster : BaseCharacter
{
	public int expEarnWhenKill = 10;

	//TODO: item drop when kill;
	public int itemDrop;

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
		avatar = b.avatar;
		baseTeam = b.baseTeam;
		posisionInTeam = b.posisionInTeam;
	}

	public CharacterMonster (CharacterMonster m)
	{
		name = m.name;
		str = m.str;
		agi = m.agi;
		intel = m.intel;
		atk = m.atk;
		matk = m.matk;
		def = m.def;
		mdef = m.mdef;
		acc = m.acc;
		eva = m.eva;
		speed = m.speed;

		expEarnWhenKill = m.expEarnWhenKill;
		itemDrop = m.itemDrop;
		avatar = m.avatar;
		line = m.line;
		baseTeam = m.baseTeam;
		posisionInTeam = m.posisionInTeam;
	}
}
