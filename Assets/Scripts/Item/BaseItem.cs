using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : BaseInformation
{
	[SerializeField]protected int _gold;
	[SerializeField]protected int _goldDiffer;
	[SerializeField]protected ItemType _type;
	[SerializeField]protected ClassifyItem _classify;
	[SerializeField] protected string descriptionOfInfo;

	public int gold{ get { return _gold; } set { _gold = value; } }

	public int goldDiffer{ get { return _goldDiffer; } set { _goldDiffer = value; } }

	public ItemType type{ get { return _type; } set { _type = value; } }

	public ClassifyItem classify{ get { return _classify; } set { _classify = value; } }

	public BaseItem ()
	{
		
	}

}
