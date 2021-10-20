using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardStick : MonoBehaviour
{
    [SerializeField] private GameObject[] Towers;
    // Start is called before the first frame update
    void Start()
    {
        UpdateTower();
    }
    private void UpdateTower()
    {
        Towers = GameObject.FindGameObjectsWithTag("Tower");

        foreach (var tower in Towers)
        {
            tower.GetComponent<TowerAI>().currentHealth = 8;
            tower.GetComponent<TowerAI>().MaxHelath = 8;
            tower.GetComponent<TowerAI>().shotCoolDown = 0.3f;
            tower.GetComponent<TowerAI>().lookSpeed = 0.7f;
        }
       
    }
    // Update is called once per frame

}
