﻿using UnityEngine;
using System.Collections;

public class EquipRenderer : MonoBehaviour {
	SpriteRenderer spr;
	Animator anim;
	AnimatorOverrideController overrideController;
	public AnimationClip[] clips;
	public EquipType type;
	// Use this for initialization
	void Awake()
	{
		spr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		overrideController = new AnimatorOverrideController();
		overrideController.runtimeAnimatorController = anim.runtimeAnimatorController;
		
		//changeEquip(clips);
	}
	public void restart()
	{
		//anim.Stop();
		anim.StartPlayback();
		print("restart");
	}
	public void wearEquip(Sprite sp)
	{
		if(sp==null)
		return;
		spr.sprite = sp;
	}
	public void wearEquip(AnimationClip[] clips)
	{
		if(clips==null)
			return;
			
		for(int i=0;i<overrideController.clips.Length;i++)
		{
			print(overrideController.clips[i].originalClip.name);

			switch(overrideController.clips[i].originalClip.name)
			{
				case "idle":
					
					overrideController[overrideController.clips[i].originalClip.name] = clips[0];
				break;
				case "melee":
					overrideController[overrideController.clips[i].originalClip.name] = clips[1];
				break;
				case "magic":
					overrideController[overrideController.clips[i].originalClip.name] = clips[2];
				break;
			}
//			overrideController[overrideController.clips[i].originalClip.name] = clips[i];
		}
		anim.runtimeAnimatorController = overrideController;
		
		//overrideController["attack"] = clips[1];
	}

	
}
