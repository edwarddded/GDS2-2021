using UnityEngine;
using System.Collections;

public class TextMovement : MonoBehaviour
{
    public float speed;
    void Update()
    {
        if (speed != 0)
        {
            float x = transform.localPosition.x + speed * Time.deltaTime;
            transform.localPosition = new Vector3(x, 0, 1);
        }
    }
}
