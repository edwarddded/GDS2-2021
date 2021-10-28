using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class DialogueBase : ScriptableObject
{   
    [System.Serializable]
    public class info
    {
        public string Myname;
        public Sprite portrait;
        [TextArea(4, 8)]
        public string Mytext;
    }

    [Header("Insert Dialogue information blow")]
    public  info[] Dialogueinfo;
}
