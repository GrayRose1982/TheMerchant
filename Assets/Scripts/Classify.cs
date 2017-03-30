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
	Sword = 1,
	Staff = 2,
	Armor = 3,
	Head = 4,
	Gloves = 5,
	Boots = 6,
	Jewelry = 7
}

public enum ClassifyItem
{
	common = 0,
	uncommon = 1,
	rare = 2,
	epic = 3,
	legend = 4
}