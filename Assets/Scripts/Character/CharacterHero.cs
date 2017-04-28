using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterHero : BaseCharacter
{
	[SerializeField]protected int _maxLevel;
	[SerializeField]protected int _experience;
	[SerializeField]protected int _experienceLevelUp;

	[SerializeField]protected HeroType _heroType;

	[SerializeField]private Equipment[] equipments;

	private int apPoint;

	public int experience{ get { return _experience; } }

	public int maxLevel{ get { return _maxLevel; } }

	public int experienceLevelUp{ get { return _experienceLevelUp; } }

	public HeroType heroType{ get { return _heroType; } }

	public CharacterHero ()
	{
		equipments = new Equipment[7];
		speed = 100;
		_experienceLevelUp = 2;
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

		icon = b.icon;
		_health = b.health;
		equipments = new Equipment[7];
		avatar = b.avatar;
		line = b.line;
		baseTeam = b.baseTeam;
		posisionInTeam = b.posisionInTeam;
	}

	public CharacterHero (CharacterHero h)
	{
		name = h.name;
		str = h.str;
		agi = h.agi;
		intel = h.intel;
		atk = h.atk;
		matk = h.matk;
		def = h.def;
		mdef = h.mdef;
		acc = h.acc;
		eva = h.eva;
		speed = h.speed;

		icon = h.icon;
		_health = h.health;
		_maxLevel = h.maxLevel;
		_experience = h.experience;
		_experienceLevelUp = h.experienceLevelUp;
		_heroType = h.heroType;
		equipments = new Equipment[7];
		avatar = h.avatar;
		line = h.line;
		baseTeam = h.baseTeam;
		posisionInTeam = h.posisionInTeam;
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

	public void SetItem (Equipment newEquipment)
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
