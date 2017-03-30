using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : BaseStar
{
	[SerializeField]protected int gold;
	[SerializeField]protected int goldDiffer;
	[SerializeField]protected ItemType type;
	[SerializeField]protected ClassifyItem classify;
}
