﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class EquipSlot : ItemSlot {
	public EquipType equipType;
	public Image previeImage;
	public Equip _bindEquip;
	public Sprite slotSprite;
	
	protected override void setItem(Item item)
	{
		base.setItem(item);
		_bindEquip = item as Equip;
		if(item==null)
		{
			itemImage.sprite = slotSprite;
			previeImage.sprite = SpriteManager.instance.emptySprite;
		}
		else if(_bindEquip.equipType!= equipType)
		{
			Debug.LogError("slot and equip time are not the same");
		}
		else
		{
			previeImage.sprite = _bindEquip.bindGraphic.equipSprite;
		}	
		
	}

	
	protected override void Awake()
	{
		base.Awake();
		slotType = ItemSlotType.Equip;
	}
	
	public override void OnPointerClick(PointerEventData eventData)
	{
		ItemUIManager.instance.itemTouched(this);
		//ItemUIManager.instance.showItem(false);
	}
	public override void OnPointerEnter(PointerEventData eventData)
    {
		//if(ItemUIManager.instance.selectedItem.)
		
        ItemUIManager.instance.OnPointerEnter(this);
    }
}