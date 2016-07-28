﻿using UnityEngine;
using System.Collections.Generic;
public enum CharacterAnimation{idle,spell,melee,die,hurt,defense}
public class CharacterRenderer : MonoBehaviour {

	public Character bindCh;
	HealthBar bar;
	
	public Animator anim;

	public EquipRenderer helmetUI;
	public EquipRenderer armorUI;
	public EquipRenderer weaponUI;
	public EquipRenderer shieldUI;
	public Dictionary<EquipType,EquipRenderer> equipUIDicts;
	void Awake()
	{
		bar = GetComponentInChildren<HealthBar>();
		anim = GetComponentInChildren<Animator>();
		
	}
	public void changeEquip(EquipGraphicData equipGraphic)
	{
		EquipType type = equipGraphic.type;
		equipUIDicts[type].changeEquip(equipGraphic.equipAnimations);
		equipUIDicts[type].changeEquip(equipGraphic.equipSprite);
	}
	public void updateRenderer(CharacterStat stat)
	{
		bar.SetNowValue(stat.hp);
	}
	public void PlayCharacterAnimation(CharacterAnimation chAnimation)
	{
		Debug.Log("play skill action");
		if(anim)
			anim.Play(chAnimation.ToString());
		//will call playSkill with animation event;
	}
	//select the characeter
	void OnMouseDown()
	{
		if(!bindCh)
		{


		}
		else
		{
			
			RandomBattleRound.instance.selectedEnemy = bindCh;	
		}
		
		print("click");
	}

	public void HitAnimation()
	{
		print("hit");
		
		LeanTween.alpha(gameObject,0,0.05f).setDelay(0.1f).setRepeat(6).setLoopPingPong();
		iTween.ShakePosition(gameObject,Vector3.one,0.2f);
		//d.loopCount = 4;
		
	}
	SpriteRenderer spr;
	public void setAlpha( float val )
    {
        spr.color = new Color(1f,1f,1f,val);
    }

	public void Die()
	{
		print("die");
		//Destroy(bindCh.gameObject);
		Destroy(gameObject);
	}
	
	public void ShowSkill()
	{
		transform.parent.SendMessage("PlaySkillEffect");
	}
}