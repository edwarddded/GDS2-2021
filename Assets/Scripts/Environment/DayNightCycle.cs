using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{   
    [Range(0.0f,1.0f)]
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

    public void Start()
    {
        timeRate = 1.0f / FullDayLength;
        time = StartTime;
    }

    private void Update()
    {
        //Increment time
        time += timeRate * Time.deltaTime;

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
        else if (Sun.intensity >0 && !Sun.gameObject.activeInHierarchy)
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
}
