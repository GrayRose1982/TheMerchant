using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HeroType
{
	None,
	Knight,
	Assassin,
	Mage,
	Priest
}

public enum ItemType
{
	None = 0,
	RawMaterial = 1,
	Equipment = 2,
	Consumption = 3,
	Scroll = 4
}

public enum EquipmentType
{
	None = 0,
	Weapon = 1,
	Armor = 2,
	Head = 3,
	Gloves = 4,
	Boots = 5,
	Jewelry = 6
}

public enum LineInFormtaion
{
	None = 0,
	Front = 1,
	Back = 2
}

public enum ClassifyItem
{
	common = 0,
	uncommon = 1,
	rare = 2,
	epic = 3,
	legend = 4
}

public enum SkillType
{
	Active,
	Passive
}

public enum SkillPassive
{
	
}

public enum SkillEffect
{
	None,
	BuffAttack = 1,
	BuffMagicAttack = 2,
	BuffDefence = 3,
	BuffMagicDefence = 4,
	DealTrueDamage = 97,
	DealPhysicDamage = 98,
	DealMagicDamage = 99,
}

public enum WorkType
{
	None = 0,
	Craft = 1,
	Quest = 2,
	Selling = 3,
	Dungeon = 4,
}