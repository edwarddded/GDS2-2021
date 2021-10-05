using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTirgger : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject Playercamera;
    public GameObject player, Cutscene1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BoxCollider collider = gameObject.GetComponent<BoxCollider>();
            collider.enabled = false;
            StartCoroutine(Activesecne());
        }
    }

    IEnumerator Activesecne()
    {
        MainCanvas.SetActive(false);
        Playercamera.SetActive(false);
        player.SetActive(false);
        Cutscene1.SetActive(true);
        yield return new WaitForSeconds(45f);
        MainCanvas.SetActive(true);
        Playercamera.SetActive(true);
        player.SetActive(true);
        Cutscene1.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
