using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
	public static CanvasManager ins;

	public enum TypeCanvasManager
	{
		First,
		Second,
		Third,
		Fouth,
		Fifth,
	}

	public Action<GameObject> first;
	public Action<GameObject> second;
	public Action<GameObject> third;
	public Action<GameObject> forth;
	public Action<GameObject> fifth;

	void Start ()
	{
		ins = this;
	}

	void GetAllCanvas ()
	{
		
	}
}
