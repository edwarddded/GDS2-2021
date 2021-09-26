using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    Item item;
    public Image icon;
    public TextMeshProUGUI text;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        if(item.maxStack > 0)
        {
            text.text = item.amount.ToString();
            text.enabled = true;
        }
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        text.text = "0";
        text.enabled = false;
    }
}
