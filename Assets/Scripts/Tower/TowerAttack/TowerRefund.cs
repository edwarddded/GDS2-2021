using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRefund : MonoBehaviour
{
    Inventory inventory;
    public Item[] refundedItems;
    public int[] itemAmounts;

    bool refunded = false;

    void Start()
    {
        inventory = Inventory.instance;
    }

    void Refund()
    {
        refunded = true;

        for(int i = 0; i < refundedItems.Length; i++)
        {
            for(int j = 0; j < itemAmounts[i]; j++)
            {
                inventory.Add(refundedItems[i]);
            }
        }
    }
}
