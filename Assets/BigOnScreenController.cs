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
        float dayCount = GameObject.Find("DayNightCycle").gameObject.GetComponent<DayNightCycle>().days;
        float Time = GameObject.Find("DayNightCycle").gameObject.GetComponent<DayNightCycle>().time;
        //bool IsMorning = GameObject.Find("DayNightCycle").gameObject.GetComponent<DayNightCycle>().IsMorning;
   
        if (Time>0.65&&Time<0.66&& dayCount ==1)
        {
            StartCoroutine(Day1());
        }
        else if (Time > 0.65 && Time < 0.66 && dayCount == 2)
        {
            StartCoroutine(Day2());
        }
        else if (Time > 0.65 && Time < 0.66 && dayCount == 3)
        {
            StartCoroutine(Day3());
        }


    }
    IEnumerator Day1()
    {
        float dayCount = GameObject.Find("DayNightCycle").gameObject.GetComponent<DayNightCycle>().days;
        //NightApproaches.SetActive(true); NightNeedtoDo.SetActive(true);
        //yield return new WaitForSeconds(1f);
        textMesh1.text = "NIGHT " + dayCount.ToString() + "  APPROACHES";
        textMesh2.text = "DEFEND YOURSELF!";
        textMesh1.CrossFadeAlpha(1, 3, false);
        textMesh2.CrossFadeAlpha(1, 2, false);     
        yield return new WaitForSeconds(5f);
        textMesh1.CrossFadeAlpha(0, 1, false);
        textMesh2.CrossFadeAlpha(0, 1, false);
        NightApproaches.SetActive(false); NightNeedtoDo.SetActive(false);

    }
    IEnumerator Day2()
    {
        float dayCount = GameObject.Find("DayNightCycle").gameObject.GetComponent<DayNightCycle>().days;
        NightApproaches.SetActive(true); NightNeedtoDo.SetActive(true);
        textMesh1.CrossFadeAlpha(1, 3, false);
        textMesh2.CrossFadeAlpha(1, 2, false);
        textMesh1.text = "NIGHT " + dayCount.ToString() + "  APPROACHES";
        textMesh2.text = "A HUGE WAVE OF ROBOTS IS APPROACHING!";
        yield return new WaitForSeconds(5f);
        textMesh1.CrossFadeAlpha(0, 1, false);
        textMesh2.CrossFadeAlpha(0, 1, false);
        NightApproaches.SetActive(false); NightNeedtoDo.SetActive(false);

    }
    IEnumerator Day3()
    {
        float dayCount = GameObject.Find("DayNightCycle").gameObject.GetComponent<DayNightCycle>().days;
        NightApproaches.SetActive(true); NightNeedtoDo.SetActive(true);
        textMesh1.CrossFadeAlpha(1, 3, false);
        textMesh2.CrossFadeAlpha(1, 2, false);
        textMesh1.text = "NIGHT " + dayCount.ToString() + "  APPROACHES";
        textMesh2.text = "THE ROBOT'S NUMBERS ARE GROWING!";
        yield return new WaitForSeconds(5f);
        textMesh1.CrossFadeAlpha(0, 1, false);
        textMesh2.CrossFadeAlpha(0, 1, false);
        NightApproaches.SetActive(false); NightNeedtoDo.SetActive(false);

    }
}
