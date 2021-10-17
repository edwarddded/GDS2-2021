using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


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
            CinemachineFreeLook CFL = GameObject.Find("Third Person Camera").GetComponent<CinemachineFreeLook>();
            CFL.m_XAxis.m_MaxSpeed = 0f;
            Cursor.lockState = CursorLockMode.None;

        }
        else
        {
            CinemachineFreeLook CFL = GameObject.Find("Third Person Camera").GetComponent<CinemachineFreeLook>();
            CFL.m_XAxis.m_MaxSpeed = 120f;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
