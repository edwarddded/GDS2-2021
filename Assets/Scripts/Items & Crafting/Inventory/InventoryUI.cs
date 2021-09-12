﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    public GameObject buildUI;

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
        if (playerMovement.isBuilding)
        {
            buildUI.SetActive(false);
            inventoryUI.SetActive(false);
        }

        if (!playerMovement.isBuilding)
        {
            if (Input.GetButtonDown("Inventory"))
            {
                inventoryUI.SetActive(!inventoryUI.activeSelf);
                if (inventoryUI.activeSelf == true)
                    buildUI.SetActive(false);
            }
            if (Input.GetButtonDown("Build"))
            {
                buildUI.SetActive(!buildUI.activeSelf);
                if (buildUI.activeSelf == true)
                    inventoryUI.SetActive(false);
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