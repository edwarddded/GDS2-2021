using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BigOnScreenController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh1;
    [SerializeField] private TextMeshProUGUI textMesh2;
    [SerializeField] private GameObject NightApproaches, NightNeedtoDo;
    // Start is called before the first frame update
    void Start()
    {
        textMesh1.canvasRenderer.SetAlpha(0);
        textMesh2.canvasRenderer.SetAlpha(0);
    }

    // Update is called once per frame
    void Update()
    {
        
        float Time = GameObject.Find("DayNightCycle").gameObject.GetComponent<DayNightCycle>().time;
        //bool IsMorning = GameObject.Find("DayNightCycle").gameObject.GetComponent<DayNightCycle>().IsMorning;

        if (Time > 0.65 && Time < 0.66)
        {
            float dayCount = GameObject.Find("DayNightCycle").gameObject.GetComponent<DayNightCycle>().days;
            StartCoroutine(NightCount());
            if (dayCount ==1)
            {
                StartCoroutine(Day1());

            }
            else if (dayCount==3)
            {
                StartCoroutine(Day3());
            }
            else if (dayCount == 6)
            {
                StartCoroutine(Day6());
            }
            else if (dayCount ==9)
            {
                StartCoroutine(Day9());
            }
            else if (dayCount ==12)
            {
                StartCoroutine(Day12());
            }
            else if (dayCount ==14)
            {
                StartCoroutine(Day14());
            }
        }
    }
    IEnumerator NightCount()
    {
        NightApproaches.SetActive(true);
        float dayCount = GameObject.Find("DayNightCycle").gameObject.GetComponent<DayNightCycle>().days;
        textMesh1.text = "NIGHT " + dayCount.ToString();
        textMesh1.CrossFadeAlpha(1, 3, false);
        yield return new WaitForSeconds(5f);
        textMesh1.CrossFadeAlpha(0, 1, false);
        NightApproaches.SetActive(false);

    }
    IEnumerator Day1()
    {
        float dayCount = GameObject.Find("DayNightCycle").gameObject.GetComponent<DayNightCycle>().days;  
        textMesh2.text = "DEFEND YOURSELF UNTIL DAY 15";    
        textMesh2.CrossFadeAlpha(1, 2, false);     
        yield return new WaitForSeconds(5f);       
        textMesh2.CrossFadeAlpha(0, 1, false);
        NightNeedtoDo.SetActive(false);

    }
    IEnumerator Day3()
    {
        float dayCount = GameObject.Find("DayNightCycle").gameObject.GetComponent<DayNightCycle>().days;
        NightNeedtoDo.SetActive(true);       
        textMesh2.CrossFadeAlpha(1, 2, false);       
        textMesh2.text = "A HUGE WAVE OF ROBOTS IS APPROACHING TONIGHT!";
        yield return new WaitForSeconds(5f);
        textMesh1.CrossFadeAlpha(0, 1, false);
        textMesh2.CrossFadeAlpha(0, 1, false);
        NightNeedtoDo.SetActive(false);
    }
    IEnumerator Day6()
    {
        float dayCount = GameObject.Find("DayNightCycle").gameObject.GetComponent<DayNightCycle>().days;
        NightNeedtoDo.SetActive(true);       
        textMesh2.CrossFadeAlpha(1, 2, false);        
        textMesh2.text = "THE ROBOT'S NUMBERS ARE GROWING!";
        yield return new WaitForSeconds(5f);       
        textMesh2.CrossFadeAlpha(0, 1, false);
        NightNeedtoDo.SetActive(false);

    }
    IEnumerator Day9()
    {
        float dayCount = GameObject.Find("DayNightCycle").gameObject.GetComponent<DayNightCycle>().days;
         NightNeedtoDo.SetActive(true);        
        textMesh2.CrossFadeAlpha(1, 2, false);        
        textMesh2.text = "THE MEACHANICAL WHIRRING GROWS LOUDER! SURVIVE TONIGHT!";
        yield return new WaitForSeconds(5f);      
        textMesh2.CrossFadeAlpha(0, 1, false);
         NightNeedtoDo.SetActive(false);

    }
    IEnumerator Day12()
    {
        float dayCount = GameObject.Find("DayNightCycle").gameObject.GetComponent<DayNightCycle>().days;
        NightNeedtoDo.SetActive(true);
        textMesh2.CrossFadeAlpha(1, 2, false);        
        textMesh2.text = "THEY ARE COMING FOR YOU!";
        yield return new WaitForSeconds(5f);        
        textMesh2.CrossFadeAlpha(0, 1, false);
        NightNeedtoDo.SetActive(false);
    }
    IEnumerator Day14()
    {
        float dayCount = GameObject.Find("DayNightCycle").gameObject.GetComponent<DayNightCycle>().days;
        NightNeedtoDo.SetActive(true);       
        textMesh2.CrossFadeAlpha(1, 2, false);
        textMesh2.text = "LAST NIGHT! A HUGE WAVE OF ROBOTS IS APPROACHING!";
        yield return new WaitForSeconds(5f);       
        textMesh2.CrossFadeAlpha(0, 1, false);
        NightNeedtoDo.SetActive(false);
    }
}
