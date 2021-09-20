﻿
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public int amount = 1;
    public int maxStack = 1;
    public string desc = "Item Description";

}
