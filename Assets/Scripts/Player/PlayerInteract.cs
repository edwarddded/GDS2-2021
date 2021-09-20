using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    GameObject selectedTower;
    GameObject closestTower;
    GameObject[] towers;

    public float interactRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestTowerWithinRange();
    }

    public void FindClosestTowerWithinRange()
    {
        towers = GameObject.FindGameObjectsWithTag("Tower");
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach(GameObject t in towers)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if(dist < minDist)
            {
                tMin = t.transform;
                minDist = dist;
                closestTower = t;
            }
        }

        if (minDist > interactRange)
            closestTower = null;

        UpdateSelectedTower(closestTower);
    }

    private void UpdateSelectedTower(GameObject t)
    {
        if(selectedTower != null && selectedTower != t)
        {
            selectedTower.GetComponent<TowerRefund>().isSelected = false;
        }


        if(t != null)
        {
            t.GetComponent<TowerRefund>().isSelected = true;
            selectedTower = t;
        }
    }
}
