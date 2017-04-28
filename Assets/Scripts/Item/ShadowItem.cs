using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShadowItem
{
	public string idItem;
	public string name;

	public Sprite icon;

	public ItemType type;
	public ClassifyItem classify;

	public string description;
	public string information;

	public int number;
	public int price;

	public ShadowItem ()
	{
	}

    public ShadowItem(ShadowItem s)
    {
        idItem = s.idItem;
        name = s.name;

        type = s.type;
        classify = s.classify;
        icon = s.icon;

        description = s.description;
        information = s.information;
        number = s.number;
        price = s.price;
    }
	public ShadowItem (ConsumptionItem con)
	{
		idItem = con.index;
		name = con.name;

		type = con.type;
		classify = con.classify;
		icon = con.icon;

		description = con.description;
		information = con.information;
		number = con.number;
		price = con.gold;
	}

	public ShadowItem (RawMaterialItem raw)
	{
		idItem = raw.index;
		name = raw.name;

		type = raw.type;
		classify = raw.classify;
		icon = raw.icon;

		description = raw.description;
		information = raw.description;
		number = raw.number;
		price = raw.gold;
	}

	public ShadowItem (ScrollItem scroll)
	{

	}

	public ShadowItem (Equipment equipment)
	{

	}
}
