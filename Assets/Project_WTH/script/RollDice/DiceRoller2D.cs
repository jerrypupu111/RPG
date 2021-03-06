﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG;
public class DiceRoller2D : Singleton<DiceRoller2D> {

	// Use this for initialization
	public Sprite[] diceSprites;
	public Image[] diceImages;
	int [] diceValues;

	public AnimatableCanvas panel;
	void Awake()
	{
		diceValues = new int[diceImages.Length];
		//panel = GetComponentInChildren<AnimatableCanvas>();
	}
	public void Roll(DiceRollDelegate d)
	{
		 panel.gameObject.SetActive(true);
		 diceRollDelegate+=d;
		 StartCoroutine("randomDice");
		 
	}

	IEnumerator randomDice()
	{
		for(int k=0;k<10;k++)
		{
			for(int i=0;i<diceImages.Length;i++)
			{
				RollDice(i);
			}
//			print("dice roll");
			yield return new WaitForSeconds(0.1f);
		}
		yield return new WaitForSeconds(0.5f);
		Result();
		
	}
	void Result()
	{
		//SkillCombatUIManager.instance.lockAllSkillBtn();
//		int sum = 0;
		//isDiceReady = true;
		
		//for(int i=0;i<diceImages.Length;i++)
		//{
		//	sum+=diceValues[i]+1;
		//}
		if(diceRollDelegate != null)
			diceRollDelegate(diceValues);

		panel.gameObject.SetActive(false);
		diceRollDelegate = null;
	}
	
	int RollDice(int index)
	{
		int r = Random.Range(0,3);
		diceImages[index].sprite = diceSprites[r];
		diceValues[index] = r; 
		
		return r;
	}
	DiceRollDelegate diceRollDelegate;
}

public delegate void DiceRollDelegate(int[] values);