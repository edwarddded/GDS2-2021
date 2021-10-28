using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    public GameObject map;
    public GameObject build;
    public GameObject inventory;


  public void showMap()
    {
        if (map != null)
        {

            bool isActive = map.activeSelf;
            map.SetActive(!isActive);
        }
    }
    public void showBuild()
    {
        if (build != null)
        {
            transform.localPosition = new Vector2(0, -Screen.height);
            transform.LeanMoveLocalX(-254, 0.5f).setEaseOutExpo().delay = 0.1f;
            bool isActive = build.activeSelf;
            build.SetActive(!isActive);
        }
    }
    public void showInventory()
    {
        if (inventory != null)
        {
            bool isActive = inventory.activeSelf;
            inventory.SetActive(!isActive);
        }
    }



}
