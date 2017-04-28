using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterBattle : MonoBehaviour
{
	[SerializeField] CharacterMonster _mons;

	public Image icon;

	public CharacterMonster mons {
		get { return _mons; }
		set {
			_mons = value;
			icon.sprite = _mons.avatar;
		}
	}

    public void btn_SelectCharacterDefence()
    {
        BattleController.c.SelectDefenceCharacter(_mons);
    }
}
