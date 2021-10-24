using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomHints : MonoBehaviour
{
    float t = 0;
    public List<string> Texts;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t >= 10)
        {
            t = 0;
            
            var randomhint = Texts[Random.Range(0, Texts.Count)];
            text.text = randomhint;
        }
    }
}
