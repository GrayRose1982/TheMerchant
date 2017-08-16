using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public WorkType workType;
	private int heroWork;
	[SerializeField] GameObject cvsQuest;
	[SerializeField] GameObject cvsCraft;
	[SerializeField] GameObject cvsDungeon;

	public void btn_SetWork (int workType)
	{
		this.workType = (WorkType)workType;
	}

	public void btn_Work ()
	{
		GameObject cvsWork = null;
		switch (workType) {
		case WorkType.Craft:
			cvsWork = cvsCraft;
			break;
		case WorkType.Quest:
			cvsWork = cvsQuest;
			break;
		case WorkType.Selling:
			cvsWork = cvsDungeon;
			break;
		case WorkType.Dungeon:
			cvsWork = cvsDungeon;
			break;
		default:
			break;
		}

		if (cvsWork != null)
			TurnOnWorkCanvas (cvsWork);
	}

	private void TurnOnWorkCanvas (GameObject cvs)
	{
		cvsQuest.SetActive (true);
	}
}
