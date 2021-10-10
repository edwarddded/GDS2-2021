using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuButton : MonoBehaviour
{

    public void open()
    {
        transform.LeanMoveLocalY(0, 0.5f).setEaseOutQuart();
        Debug.Log("menu button pressed");
    }
    public void close()
    {
        transform.LeanMoveLocalY(440, 0.5f).setEaseOutQuart();
        Debug.Log("menu button closed");
    }
}
