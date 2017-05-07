using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TarvenShowHeroUI : MonoBehaviour
{
	public static Action timeCountDown;

	void Start ()
	{
		
	}

	void Update ()
	{
		if (timeCountDown != null)
			timeCountDown.Invoke ();
	}

	void ChangeUI ()
	{
		
	}
}
