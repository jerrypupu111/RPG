﻿using UnityEngine;
using System.Collections.Generic;

public class ItemManager : Singleton<ItemManager> {

	Dictionary<string,ItemGraphicAsset> itemGraphicDict;
	Dictionary<string,Item> itemDict;
	public List<ItemGraphicAsset> itemGraphicTemplates;
	public List<Item> itemTemplates;
	//public List<Item> 
	void Awake()
	{
		itemGraphicDict = new Dictionary<string,ItemGraphicAsset>();
		itemDict = new Dictionary<string,Item>();
		foreach(var itemGraphic in itemGraphicTemplates)
		{
			itemGraphicDict.Add(itemGraphic.name,itemGraphic);
		}
		foreach(var item in itemTemplates)
		{
			itemDict.Add(item.name,item);
		}
	}
	public Item getItem(ItemData data)
	{
		Item item = Instantiate(itemDict[data.id]);
		item.bindData = data;
		item.asset = itemGraphicDict[data.imageID];
		return item;
	} 
}
