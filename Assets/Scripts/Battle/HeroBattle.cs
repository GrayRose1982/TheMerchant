using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroBattle : MonoBehaviour
{
	[SerializeField] CharacterHero _hero;
	public Image icon;

	public CharacterHero hero {
		get { return _hero; }
		set {
			_hero = value; 
			icon.sprite = _hero.icon;
		}
	}
}
