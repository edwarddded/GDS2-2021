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


    // Update is called once per frame
    void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, null, out localPoint);
        transform.localPosition = localPoint + new Vector2(-200f,100f);
    }

    public void UpdateTooltip(TowerInfo tower)
    {
        nameTxt.text = tower.name;
        descTxt.text = tower.desc;
        icon.sprite = tower.icon;
        for(int i = 0; i < resources.Length; i++)
        {
            if (i > tower.itemsRequired.Length-1)
                resources[i].text = "";
            else
            resources[i].text = tower.itemsRequired[i].name + " x " + tower.itemAmount[i].ToString();
        }
    }
}
