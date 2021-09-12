using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildButton : MonoBehaviour
{
    Inventory inventory;

    public GameObject tooltip;
    public TowerInfo tower;
    public Image icon;
    public Text text;

    private void Start()
    {
        inventory = Inventory.instance;

        if (tower != null)
        {
            icon.sprite = tower.icon;
            text.text = tower.name;
        }
    }

    public void StartConstruction()
    {
        if(tower != null)
        {
            for (int i = 0; i < tower.itemsRequired.Length; i++)
            {
                if (!hasResource(tower.itemsRequired[i], tower.itemAmount[i]))
                {
                    Debug.Log("Insufficient resources to build this!");
                    return;
                }
            }
            Debug.Log("Instantiating Tower Frame");
            Instantiate(tower.towerFrame);
        }

    }

    private bool hasResource(Item item, int amount)
    {
        foreach(Item i in inventory.items)
        {
            if (i.name == item.name && i.amount >= amount)
            {
                Debug.Log("You have enough "+ item.name + " to build this!");
                return true;
            }

        }

        Debug.Log("You don't have enough " + item.name + " to build this.");
        return false;
    }

    public void ShowTooltip()
    {
        if(tower!= null)
        {
            tooltip.GetComponent<BuildTooltip>().UpdateTooltip(tower);
            tooltip.SetActive(true);
        }
    }

    public void HideTooltip()
    {
        if(tower!= null)
        {
            tooltip.SetActive(false);
        }
    }
}
