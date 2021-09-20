using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    GameObject selectedTower;
    GameObject closestTower;
    GameObject[] towers;

    GameObject selectedItem;
    GameObject closestItem;
    GameObject[] items;

    public float towerInteractRange;
    public float itemInteractRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestItemWithinRange();
        FindClosestTowerWithinRange();
    }

    private void FindClosestItemWithinRange()
    {
        items = GameObject.FindGameObjectsWithTag("Item");
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject i in items)
        {
            float dist = Vector3.Distance(i.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = i.transform;
                minDist = dist;
                closestItem = i;
            }
        }

        if (minDist > itemInteractRange)
            closestItem = null;

        UpdateSelectedItem(closestItem);
    }

    private void FindClosestTowerWithinRange()
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

        if (minDist > towerInteractRange)
            closestTower = null;

        UpdateSelectedTower(closestTower);
    }

    private void UpdateSelectedItem(GameObject i)
    {
        if (selectedItem != null && selectedItem != i)
        {
            selectedItem.GetComponent<ItemPickup>().isSelected = false;
        }

        if (i != null)
        {
            i.GetComponent<ItemPickup>().isSelected = true;
            selectedItem = i;
        }
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
