using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialPopup : MonoBehaviour
{
    public Item item;
    public Text nameText;
    public Text Desc;
    public Image Image;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(item.name);
        nameText.text = item.name;
        Desc.text = item.desc;
        Image.sprite = item.icon;
        
    }


}
