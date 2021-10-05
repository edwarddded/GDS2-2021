using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSetup : MonoBehaviour
{
    public GameObject BuildMenu;
    public GameObject Inventory;
    public GameObject Map;
    public GameObject Pasuemenu;
    public GameObject Dialogue;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (BuildMenu.gameObject.activeInHierarchy||Inventory.gameObject.activeInHierarchy||Map.gameObject.activeInHierarchy|| Pasuemenu.gameObject.activeInHierarchy|| Dialogue.gameObject.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
