using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        Item copyItem = Instantiate(item);

        for(int i = 0; i < items.Count; i++)
        {
            if (item.name == items[i].name)
            {
                Debug.Log("current value: " + items[i].amount.ToString());
                copyItem.amount = items[i].amount + 1;
                items[i] = copyItem;
                Debug.Log("new value: " + items[i].amount.ToString());
                if (onItemChangedCallback != null)
                    onItemChangedCallback.Invoke();
                return true;
            }
        }

        Debug.Log("Milestone");
        if(items.Count >= space)
        {
            return false;
        }

        items.Add(item);

        if(onItemChangedCallback != null)
        onItemChangedCallback.Invoke();
        Debug.Log("New item added");
        return true;
    }

    public void Remove(Item item, int amount)
    {
        Item copyItem = Instantiate(item);
        for (int i = 0; i < items.Count; i++)
        {
            if (item.name == items[i].name)
            {
                Debug.Log("current value: " + items[i].amount.ToString());
                copyItem.amount = items[i].amount - amount;
                items[i] = copyItem;
                Debug.Log("new value: " + items[i].amount.ToString());
            }
        }

        if (copyItem.amount <= 0)
        items.Remove(copyItem);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public bool hasResource(Item item, int amount)
    {
        foreach (Item i in items)
        {
            if (i.name == item.name && i.amount >= amount)
            {
                Debug.Log("You have enough " + item.name + " to build this!");
                return true;
            }

        }

        Debug.Log("You don't have enough " + item.name + " to build this.");
        return false;
    }

    public bool doNothing()
    {
        return true;
    }
}
