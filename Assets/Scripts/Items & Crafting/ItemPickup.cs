using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // Whenever you make a new pickup, create an item first to assign to this variable
    // This variable contains data used in the inventory system
    public Item item;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        if (Input.GetKeyDown("e") && distance <2)
        {


            //Object is only destroyed if it is successfully added to the inventory
            if (Inventory.instance.Add(item))
            {
                Debug.Log(this + "been picked");
                Destroy(this.gameObject);
            }
        }
    }

}
