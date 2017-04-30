using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MonsterBattle : MonoBehaviour
{
	[SerializeField] CharacterMonster _mons;

	public Image icon;

	public CharacterMonster mons {
		get { return _mons; }
		set {
			_mons.takeDamageAction -= TakeDamage;
			_mons.takeDamageAction -= UIDamageTaken;
			_mons = value;

			if (value == null) {
				gameObject.SetActive (false);
				return;
			}

			_mons.takeDamageAction += TakeDamage;
			_mons.takeDamageAction += UIDamageTaken;

			icon.sprite = _mons.icon;
		}
	}

	public void TakeDamage ()
	{
		if (_mons.health < 0)
			icon.sprite = Ultility.u.noneSprite;
	}

	public void UIDamageTaken ()
	{
		StartCoroutine (ChangeUI (.2f));
	}

	IEnumerator ChangeUI (float time)
	{
		icon.CrossFadeColor (Color.red, time, false, false);
		yield return new WaitForSeconds (time);
		icon.CrossFadeColor (Color.white, time, false, false);
	}

	public void btn_SelectCharacterDefence ()
	{
		if (_mons != null && _mons.health > 0 && _mons.name != null && _mons.name.CompareTo ("") != 0)
			BattleController.c.SelectDefenceCharacter (_mons);
	}
}
