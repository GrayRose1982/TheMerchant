using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConsumptionItem : BaseItem
{
	public int numberHealing;
	public int numberPoison;

	public int number;

	public ConsumptionItem ()
	{
		
	}

	public ConsumptionItem (ConsumptionItem c)
	{
		index = c.index;
		name = c.name;
		description = c.description;
		level = c.level;
		icon = c.icon;

		gold = c.gold;
		goldDiffer = c.goldDiffer;
		type = ItemType.Consumption;
		classify = c.classify;
		number = c.number;

		numberHealing = c.numberHealing;
		numberPoison = c.numberPoison;
	}
}
