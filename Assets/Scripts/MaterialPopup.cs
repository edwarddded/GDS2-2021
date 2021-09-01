using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialPopup : MonoBehaviour
{
    public Materialinfo Popup;
    public Text nameText;
    public Text Desc;
    public Image Image;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Popup.name);
        nameText.text = Popup.MaterialName;
        Desc.text = Popup.description;
        Image.sprite = Popup.image;
        
    }


}
