using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // Whenever you make a new pickup, create an item first to assign to this variable
    // This variable contains data used in the inventory system
    public Item item;

    //bool used by item interaction script
    //allows item to be picked up if in range
    public bool isSelected;

    public GameObject player;
    public Outline outline;

    public GameObject uiObject;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        outline = GetComponent<Outline>();
        outline.enabled = false;
        isSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            outline.enabled = true;
            uiObject.SetActive(true);
        }
        else
        {
            outline.enabled = false;
            uiObject.SetActive(false);
        }

        if (Input.GetKeyDown("e") && isSelected)
        {
            //Object is only destroyed if it is successfully added to the inventory
            if (Inventory.instance.Add(item))
            {
                Debug.Log(this + "been picked up");
                Destroy(this.gameObject);
            }
            
        }
    }

}
