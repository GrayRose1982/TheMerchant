using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseInformation
{
	private string _index;

	public string index{ get { return _index; } set { _index = value; } }

	public string name;
	public string description;

	public int level;
	public Sprite icon;
}
