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

	[SerializeField]private Equipment[] equipments;

	public CharacterHero ()
	{
		equipments = new Equipment[7];
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

		equipments = new Equipment[7];

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

	private void SetItem (Equipment newEquipment)
	{
		int slot = (int)newEquipment.equipmentType;
		if (ChangeItem (equipments [slot], newEquipment))
			equipments [slot] = newEquipment;
	}

	private bool ChangeItem (Equipment oldEquipment, Equipment newEquipment)
	{
		if (oldEquipment.equipmentType != newEquipment.equipmentType)
			return false;

		str -= oldEquipment.strIncrease - newEquipment.strIncrease;
		agi -= oldEquipment.agiIncrease - newEquipment.agiIncrease;
		intel -= oldEquipment.intelIncrease - newEquipment.intelIncrease;
		atk -= oldEquipment.atkIncrease - newEquipment.atkIncrease;
		matk -= oldEquipment.matkIncrease - newEquipment.matkIncrease;
		def -= oldEquipment.defIncrease - newEquipment.defIncrease;
		mdef -= oldEquipment.mdefIncrease - newEquipment.mdefIncrease;
		acc -= oldEquipment.accIncrease - newEquipment.accIncrease;
		eva -= oldEquipment.evaIncrease - newEquipment.evaIncrease;
		speed -= oldEquipment.speedIncrease - newEquipment.speedIncrease;

		return true;
	}
}
