using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderConstruction : MonoBehaviour
{
    public TowerInfo tower;

    public GameObject constructionEffect;

    Inventory inventory;

    private bool isPlaced;
    private GameObject player;
    private Transform p;
    public float heightOffset = 3;
    private float posX, posY, posZ;

    private void Start()
    {
        inventory = Inventory.instance;
        player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerMovement>().isBuilding = true;
        isPlaced = false;
    }

    private void Update()
    {
        if(!isPlaced)
        {
            // Cancels the placement of the frame
            if (Input.GetMouseButtonDown(1))
            {
                player.GetComponent<PlayerMovement>().isBuilding = false;
                Destroy(gameObject);
            }
            // Starts the construction
            if (Input.GetMouseButtonDown(0))
            {

                //Placeholder cost of a tower, better cost system to be added later
                for (int i = 0; i < tower.itemsRequired.Length; i++)
                {
                    inventory.Remove(tower.itemsRequired[i], tower.itemAmount[i]);
                }

                player.GetComponent<PlayerMovement>().isBuilding = false;
                isPlaced = true;
                Collider c = GetComponent<Collider>();
                c.enabled = true;
                GameObject fx = Instantiate(constructionEffect, this.transform.position, this.transform.rotation);
                fx.transform.parent = this.gameObject.transform;
                Destroy(fx, tower.buildTime - 0.1f);
                Invoke("SpawnBuilding", tower.buildTime);
            }

            // Sets the building frame to be in front of the player
            p = GameObject.FindWithTag("Player").GetComponent<Transform>();
            posX = p.transform.position.x;
            posY = p.transform.position.y;
            posZ = p.transform.position.z;
            transform.rotation = p.transform.rotation;
            transform.position = new Vector3(posX, posY+heightOffset, posZ) + p.transform.forward*4;
        }
    }

    private void SpawnBuilding()
    {
        Instantiate(tower.towerFinished, this.transform.position, this.transform.rotation);
        Destroy(gameObject);
    }
}
