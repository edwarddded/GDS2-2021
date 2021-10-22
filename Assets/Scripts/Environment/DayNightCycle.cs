﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayNightCycle : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float time;
    public float FullDayLength;
    public float StartTime = 0.4f;
    private float timeRate;
    public Vector3 noon;

    [Header("Sun")]
    public Light Sun;
    public Gradient sunColor;
    public AnimationCurve sunIntensity;

    [Header("Moon")]
    public Light moon;
    public Gradient moonColor;
    public AnimationCurve moonIntensity;

    [Header("OtherSetting")]
    public AnimationCurve LightingIntensityMultiplier;
    public AnimationCurve ReflectionsIntensityMultipler;

    public bool IsNight;
    public bool IsMorning;

    public GameObject dayTimeLoading;
    public GameObject nightTimeLoading;
    public Slider daySlider;
    public Slider nightSlider;
    public float dayTime;
    public float nightTime;

    public int days;
    public Text texts;

    public bool check;
   
    public void Start()
    {
        PlayerPrefs.SetInt("daysSurvived", 0);

        timeRate = 1.0f / FullDayLength;
        time = StartTime;
        IsNight = false;
        IsMorning = true;
        days = 1;

        check = false;
        
    }

    private void Update()
    {
        DayController();
        
        texts.text = "Days: 0" + days;

        //Check Day/Night
        if (time >= 0.75f || time <= 0.2f)
        {
            if (IsNight == false && IsMorning == true)
            {
                IsNight = true;
                IsMorning = false;
            }
        }
        else
        {
            if (IsNight == true && IsMorning == false)
            {
                IsMorning = true;
                IsNight = false;
                PlayerPrefs.SetInt("daysSurvived", days);
                days++;
            }

        }
        incrementTime();

        if (IsMorning == true)
        {
            dayTimeLoading.SetActive(true);
            nightTimeLoading.SetActive(false);
            daySlider.value = dayTime;
            nightTime = 0f;
            if (time >= 0.2f && time <= 0.75f)
            {
                dayTime = (time - 0.2f) * (1 / 0.55f);
            }
            if (check == false)
            {
                FindObjectOfType<AudioManager>().Play("Day");
                FindObjectOfType<AudioManager>().Stop("Night");
                check = true;
            }
        }
        if (IsNight == true)
        {
            nightTimeLoading.SetActive(true);
            dayTimeLoading.SetActive(false);
            nightSlider.value = nightTime;
            dayTime = 0f;
            if (time >= 0.75f)
            {
                nightTime = (time - 0.75f) * (1 / 0.45f);
            }
            if (time <= 0.2f)
            {
                nightTime = (time + 0.25f) * (1 / 0.45f);
            }
            if(check == true)
            {
                FindObjectOfType<AudioManager>().Play("Night");
                FindObjectOfType<AudioManager>().Stop("Day");
                check = false;
            }
        }
        if (time >= 1.0f)
        {
            time = 0.0f;
        }

        //Light rotation
        Sun.transform.eulerAngles = (time - 0.25f) * noon * 4.0f;
        moon.transform.eulerAngles = (time - 0.75f) * noon * 4.0f;

        //Light Intensity
        Sun.intensity = sunIntensity.Evaluate(time);
        moon.intensity = moonIntensity.Evaluate(time);

        //Change Colors
        Sun.color = sunColor.Evaluate(time);
        moon.color = moonColor.Evaluate(time);

        //Enable / disable the sun
        if (Sun.intensity == 0 && Sun.gameObject.activeInHierarchy)
        {
            Sun.gameObject.SetActive(false);
        }
        else if (Sun.intensity > 0 && !Sun.gameObject.activeInHierarchy)
        {
            Sun.gameObject.SetActive(true);
        }

        //Enable / disable the moon
        if (moon.intensity == 0 && moon.gameObject.activeInHierarchy)
        {
            moon.gameObject.SetActive(false);
        }
        else if (moon.intensity > 0 && !moon.gameObject.activeInHierarchy)
        {
            moon.gameObject.SetActive(true);
        }

        //Light and reflections intensity
        RenderSettings.ambientIntensity = LightingIntensityMultiplier.Evaluate(time);
        RenderSettings.reflectionIntensity = ReflectionsIntensityMultipler.Evaluate(time);
    }
    private void DayController()
    {
        if (days> 5&& days<=10)
        {
            FullDayLength = 60f;
        }
        else if (days>10)
        {
           FullDayLength = 100f;
        }
        else if (days ==14)
        {
            FullDayLength = 120f;
        }
        if (days ==15)
        {
            SceneManager.LoadScene(7);
        }
    }
    private void incrementTime()
    {

        //Increment time
        bool IsPlaying = gameObject.GetComponent<CutsceneDayNightController>().IsCutscenePlaying;
        if (IsPlaying)
        {
            time += 0;
        }
        else
        {
            time += timeRate * Time.deltaTime;
        }

    }
}