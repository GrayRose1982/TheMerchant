using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemTest : MonoBehaviour
{
	public RawMaterialItem raw;
	public Equipment e;

	void Start ()
	{
		StartCoroutine (addOne ());
	}

	IEnumerator addOne ()
	{
		while (!LoadMaterials.data.isLoadDone)
			yield return new WaitForSeconds (1f);
		RawMaterialItem item = new RawMaterialItem (LoadMaterials.data.baseRawMaterial [1], 3);
		Inventory.i.AddNewItem (item);
	}
}
