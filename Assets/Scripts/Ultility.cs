using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultility: MonoBehaviour
{
	public static Ultility u;
	public static string CharacterHero = "CH";
	public static string CharacterMonster = "CM";
	public static string RawMaterial = "RM";
	public static string Consumption = "CO";
	public static string Equipment = "E";

	public Sprite noneSprite;

	public static Sprite done;
	public static Sprite wait;
	public static Sprite getJob;

	void Start ()
	{
		if (!u)
			u = this;
	}
}
