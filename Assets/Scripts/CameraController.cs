using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float smooth = 0.3f;
    public float height;
    public float zOffset;
    public float xoffest;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 pos = new Vector3();
        pos.x = player.position.x + xoffest;
        pos.z = player.position.z - zOffset;
        pos.y = player.position.y + height;
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
    }

    //[SerializeField] private float mouseSensitivity;
    //private Transform parent;

    //private void Start()
    //{
    //    parent = transform.parent;
    //    Cursor.lockState = CursorLockMode.Locked;
    //}

    //private void Update()
    //{
    //    Rotate();
    //}
    //private void Rotate()
    //{
    //    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

    //    parent.Rotate(Vector3.up, mouseX);

    //}
}
