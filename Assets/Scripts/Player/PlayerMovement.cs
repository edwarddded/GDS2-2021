using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody rb;

    Vector3 movement;

    public bool isBuilding;
    public GameObject[] TowerFrames;

    private Inventory inv;

    private void Start()
    {
        inv = GetComponent<Inventory>();
        isBuilding = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Player rotation based on where the mouse is
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if (playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.deltaTime);
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");


        /*******************
         * Tower Building 
         ********************/
        if (Input.GetKeyDown("1"))
        {
            // 10 is just an example cost of a tower, 
            // going to implement a separate script to retrieve tower cost later
            if (!isBuilding && (inv.GetScrap() >= 10))
            {
                isBuilding = true;
                Instantiate(TowerFrames[0]);
            }
        }

    }

    private void FixedUpdate()
    {
        movement.Normalize();
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
