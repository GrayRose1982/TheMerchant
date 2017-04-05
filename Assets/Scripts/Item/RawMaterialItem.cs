using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class RawMaterialItem : BaseItem
{
	public int number;

	public RawMaterialItem ()
	{
		type = ItemType.RawMaterial;
	}

	public RawMaterialItem (RawMaterialItem raw)
	{
		index = raw.index;
		name = raw.name;
		description = raw.description;
		level = raw.level;
		sprite = raw.sprite;

		gold = raw.gold;
		goldDiffer = raw.goldDiffer;
		type = ItemType.RawMaterial;
		classify = raw.classify;
		number = raw.number;
	}
}
