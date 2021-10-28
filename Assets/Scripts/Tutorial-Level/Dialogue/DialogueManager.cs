using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("fix this" + gameObject.name);
        }
        else
        {
            instance = this;
        }
    }

    public GameObject DialogueBox;

    public Text dialogueName;
    public Text dialogueText;
    public Image dialoguePortrait;
    public float delay = 0.001f;
    private bool isCurrentlyTyping;
    private string completeText;

    public Queue<DialogueBase.info> dialogueinfo = new Queue<DialogueBase.info>();

    private void Start()
    {
        dialogueinfo = new Queue<DialogueBase.info>();
    }

    public void EnqueueDialogue(DialogueBase db)
    {
        DialogueBox.SetActive(true);
        dialogueinfo.Clear();

        foreach (DialogueBase.info info in db.Dialogueinfo)
        {
            dialogueinfo.Enqueue(info);
        }
        DequeueDialogue();
    }

    public void DequeueDialogue()
    {
        //add in code that detects if we here no more dialogue and return
        if (dialogueinfo.Count== 0)
        {
            EndofDialogue();
            return;
        }
        if(isCurrentlyTyping == true)
        {
            CompleteText();
            StopAllCoroutines();
            isCurrentlyTyping = false;
            return;
        }
        DialogueBase.info info = dialogueinfo.Dequeue();
        completeText = info.Mytext;
        dialogueName.text = info.Myname;
        dialogueText.text = info.Mytext;
        dialoguePortrait.sprite = info.portrait;
        dialogueText.text = "";

        StartCoroutine(TypeText(info));
    }

    IEnumerator TypeText(DialogueBase.info info)
    {
        isCurrentlyTyping = true;
       
        foreach(char c in info.Mytext.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
            dialogueText.text += c;
            
        }
        isCurrentlyTyping = false;
    }

    private void CompleteText()
    {
        dialogueText.text = completeText;
    }
    public void EndofDialogue()
    {
        DialogueBox.SetActive(false);
    }
    private void Update()
    {
        //if (DialogueBox.activeInHierarchy)
        //{
        //    PlayerMovement movement = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerMovement>();
        //    movement.enabled = false;
        //}
        //else
        //{
        //    PlayerMovement movement = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerMovement>();
        //    movement.enabled = true;
        //}
    }
}
