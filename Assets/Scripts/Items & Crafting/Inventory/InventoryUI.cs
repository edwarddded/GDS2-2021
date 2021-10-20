using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    public GameObject buildUI;
    public GameObject tooltip;

    Inventory inventory;
    PlayerMovement playerMovement;

    InventorySlot[] slots;

    void Start()
    {
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();

        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (buildUI.activeSelf == false)
            tooltip.SetActive(false);

        if (playerMovement.isBuilding)
        {
            buildUI.SetActive(false);
            inventoryUI.SetActive(false);
            tooltip.SetActive(false);
        }

        if (!playerMovement.isBuilding)
        {
            if (Input.GetButtonDown("Inventory"))
            {
                FindObjectOfType<AudioManager>().Play("Click");
                inventoryUI.SetActive(!inventoryUI.activeSelf);
                if (inventoryUI.activeSelf == true)
                {
                    buildUI.SetActive(false);
                    tooltip.SetActive(false);
                }

            }
            if (Input.GetButtonDown("Build"))
            {
                FindObjectOfType<AudioManager>().Play("Click");
                buildUI.SetActive(!buildUI.activeSelf);
                if (buildUI.activeSelf == true)
                {
                    inventoryUI.SetActive(false);
                    tooltip.SetActive(false);
                }

            }
        }

    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
