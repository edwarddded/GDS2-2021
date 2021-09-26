using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BackgroundControl : MonoBehaviour
{
    // Start is called before the first frame update
    private float tempTime;
    void Start()
    {
        tempTime = 0;

        //get material renderer component
        this.GetComponent<Image>().color = new Color
        (this.GetComponent<Image>().color.r,
                this.GetComponent<Image>().color.g,
                this.GetComponent<Image>().color.b,
                this.GetComponent<Image>().color.a
                );

    }

    // Update is called once per frame
    void Update()
    {
        if (tempTime <1)
        {
            tempTime = tempTime + Time.deltaTime;
        }
        if (this.GetComponent<Image>().color.a <= 1)
        {
            this.GetComponent<Image>().color = new Color
                (this.GetComponent<Image>().color.r,
                    this.GetComponent<Image>().color.g,
                    this.GetComponent<Image>().color.b,

                    gameObject.GetComponent<Image>().color.a - tempTime / 30 * Time.deltaTime
                    );
        }
        Destroy(this.gameObject, 40.0f);
    }
}
