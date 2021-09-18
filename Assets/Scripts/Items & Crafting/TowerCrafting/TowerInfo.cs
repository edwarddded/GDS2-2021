using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "Crafting/Tower")]
public class TowerInfo : ScriptableObject
{
    new public string name = "New Tower";
    public Sprite icon = null;
    public GameObject towerFrame;
    public GameObject towerFinished;
    public float buildTime;
    public Item[] itemsRequired;
    public int[] itemAmount;
    public string desc = "Tower Description";
}
