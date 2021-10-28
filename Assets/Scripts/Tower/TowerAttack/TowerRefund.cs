using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRefund : MonoBehaviour
{
    Inventory inventory;

    public Item[] refundedItems;
    public int[] itemAmounts;

    Outline outline;

    public bool isSelected = false;
    bool hasRefunded = false;

    void Start()
    {
        inventory = Inventory.instance;
        outline = GetComponent<Outline>();
    }

    private void Update()
    {
        if (isSelected)
            outline.enabled = true;
        else
            outline.enabled = false;

        if (isSelected && Input.GetKeyDown("r") && !hasRefunded)
            Refund();
    }

    void Refund()
    {
        Debug.Log("refunding tower");
        hasRefunded = true;
        FindObjectOfType<AudioManager>().Play("Refund");

        for (int i = 0; i < refundedItems.Length; i++)
        {
            for(int j = 0; j < itemAmounts[i]; j++)
            {
                inventory.Add(refundedItems[i]);
            }
        }
        Destroy(gameObject);
    }
}
