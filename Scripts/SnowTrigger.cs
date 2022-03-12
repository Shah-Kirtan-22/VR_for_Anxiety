using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowTrigger : MonoBehaviour
{
    public float updateInterval = 0.5F;
    private double lastInterval;
    private int frames = 0;
    private float fps;
    public ParticleSystem psy;
    public bool moduleEnabled;

    void Start()
    {
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
        psy = GetComponent<ParticleSystem>();
    }

    void OnGUI()
    {
        GUILayout.Label("" + fps.ToString("f2"));
    }

    void Update()
    {
        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            fps = (float)(timeNow);
            frames = 0;
            lastInterval = timeNow;
        }

        if (timeNow > 0 && timeNow < 10)
        {
            var emission = psy.emission;
            emission.enabled = true;

        }

        if (timeNow > 10 && timeNow < 24)
        {
            var emission = psy.emission;
            emission.enabled = false;

        }

        if (timeNow > 25 && timeNow < 55)
        {
            var emission = psy.emission;
            emission.enabled = true;
        }

        if (timeNow > 55 && timeNow < 100)
        {
            var emission = psy.emission;
            emission.enabled = false;
        }

        if (timeNow > 100 && timeNow < 130)
        {
            var emission = psy.emission;
            emission.enabled = true;
        }

        if (timeNow > 130 && timeNow < 180)
        {
            var emission = psy.emission;
            emission.enabled = false;
        }

        if (timeNow > 180 && timeNow < 240)
        {
            var emission = psy.emission;
            emission.enabled = true;
        }
    }
}
