using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildTooltip : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI descTxt;
    public TextMeshProUGUI[] resources;
    public TextMeshProUGUI buildWarningTxt;
    bool canBuild;

    Inventory inventory;

    private void Awake()
    {
        inventory = Inventory.instance;
    }

    void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, null, out localPoint);
        transform.localPosition = localPoint + new Vector2(-200f,100f);
    }

    public void UpdateTooltip(TowerInfo tower)
    {
        canBuild = true;
        nameTxt.text = tower.name;
        descTxt.text = tower.desc;
        icon.sprite = tower.icon;
        for (int i = 0; i < resources.Length; i++)
        {
            if (i > tower.itemsRequired.Length - 1)
                resources[i].text = "";
            else
            {
                resources[i].text = tower.itemsRequired[i].name + " x " + tower.itemAmount[i].ToString();
                if (!inventory.hasResource(tower.itemsRequired[i], tower.itemAmount[i]))
                {
                    resources[i].color = Color.red;
                    canBuild = false;
                }
                else
                {
                    resources[i].color = Color.green;

                }
            }
        }

        if (canBuild)
        {
            buildWarningTxt.text = "Ready to Build";
            buildWarningTxt.color = Color.green;
        }
        else
        {
            buildWarningTxt.text = "Insufficient Resources";
            buildWarningTxt.color = Color.red;
        }
    }
}
