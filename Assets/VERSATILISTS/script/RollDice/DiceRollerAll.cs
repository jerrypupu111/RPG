﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRollerAll : Singleton<DiceRollerAll> {

	[SerializeField]
	Sprite enemySprite;
	[SerializeField]
	DiceSlot[] dices;
	DiceRollResultDelegate diceRollDelegate;
	int[] rollNum =  {5,6,7,8};
	int enemyPos;
	public DiceSlot[] getDices{
		get{
			return dices;
		}
	}
	void Start()
	{
		foreach(var dice in dices)
			DiceFactory.instance.MakeDefaultDice(dice);
	}
	public void Roll(DiceRollResultDelegate d)
	{
		 diceRollDelegate+=d;
		 currentDice = 0;
		 enemyPos = 3;// Random.Range(0,4);
		 dices[enemyPos].willHaveSpecialResult(enemySprite);
		 for(int i=0;i<4;i++)
		 {
			 dices[i].Roll(rollNum[i],rollDoneCallBack);
		 }
	}
	ActionDiceType[] result = {0,0,0};
	int currentDice = 0;
	public void rollDoneCallBack(ActionDiceType value)
	{
		result[currentDice] = value; 
	}

	
}

public delegate void DiceTypeResultDelegate(ActionDiceType type);
public delegate void DiceRollResultDelegate(ActionDiceType[] values);