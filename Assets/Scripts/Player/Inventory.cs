using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private int scrap;
    public Text scrapTxt;

    private void Start()
    {
        ResetInventory();
        UpdateText();
    }

    public void AddScrap(int s)
    {
        scrap += s;
        UpdateText();
    }

    public void RemoveScrap(int s)
    {
        scrap -= s;
        UpdateText();
    }

    public int GetScrap()
    {
        return scrap;
    }

    private void UpdateText()
    {
        scrapTxt.text = scrap.ToString();
    }
    
    private void ResetInventory()
    {
        scrap = 0;
    }
}
