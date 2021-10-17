using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MainCanvas;
    public GameObject Playercamera;
    public GameObject player, Cutscene1;
    public PlayerMovement movement;
    public void SkipGame()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemys)
        {
            enemy.SetActive(true);
        }
        movement.enabled = true;
        MainCanvas.SetActive(true);
        Playercamera.SetActive(true);
        player.SetActive(true);
        Cutscene1.SetActive(false);
    }
}
