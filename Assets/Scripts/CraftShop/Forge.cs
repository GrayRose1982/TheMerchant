using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

[System.Serializable]
public class Forge
{
	public string idItemCraft;
	public string idIngre1;
	public int numIngre1;
	public string idIngre2;
	public int numIngre2;
	public string idIngre3;
	public int numIngre3;
	public string idIngre4;
	public int numIngre4;
	public bool isUnLock = false;

    public string[] idIngres;
    public int[] numbers;

	public Forge ()
	{
	    idIngres = new string[4];
        numbers = new int[4];
	}
}
