using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkController : MonoBehaviour
{
	public static WorkController wc;

	public GameObject[] allCanvas;

	public List<int> workFollow;
	public WorkType job;

	void Start ()
	{
		wc = this;
		workFollow = new List<int> ();
	}

	public void btn_SetCanvas (int index)
	{
		for (int i = 0; i < allCanvas.Length; i++)
			allCanvas [i].SetActive (false);

		if (index == 0)
			workFollow.Clear ();
		else
			workFollow.Add (index);
		
		allCanvas [index].SetActive (true);
	}

	public void btn_back ()
	{
		int lastScene;
		int numberScene = workFollow.Count;
		lastScene = numberScene > 1 ? numberScene - 2 : 0;
		btn_SetCanvas (lastScene);

		if (workFollow.Count > 2)
			workFollow.RemoveRange (numberScene - 1, 2);
	}

	public void btn_SetJob (int job)
	{
		this.job = (WorkType)job;
	}

	public void btn_Next ()
	{
		int nextScreen = 0;
		switch (job) {
		case WorkType.Craft:
			nextScreen = 2;
			break;
		case WorkType.Dungeon:
			nextScreen = 4;
			break;
		default:
			break;
		}

		btn_SetCanvas (nextScreen);
	}
}
