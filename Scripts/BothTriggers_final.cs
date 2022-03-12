using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BothTriggers_final : MonoBehaviour
{

    [Range(1, 10)]
    public float updateInterval = 0.5F;
    private double lastInterval;
    private int frames = 0;
    private float fps;
    public ParticleSystem effect1;
    public bool moduleEnabled;
    //public AudioSource audio1, audio2, audio3, audio4;
    public AudioSource audio;
    public AudioClip clip1, clip2, clip3, clip4;
    public bool effectTrigger1, effectTrigger2;
    //public float FadeTime;
    //public var effectname2 = "snowup";
    

    void Start()
    {
        ReadCSVfile();
        StartCoroutine(ReadCSVfile());
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
        
        effect1 = GetComponent<ParticleSystem>();

        audio = GetComponent<AudioSource>();
        /*
        audio1 = GetComponent<AudioSource>();
        audio2 = GetComponent<AudioSource>();
        audio3 = GetComponent<AudioSource>();
        audio4 = GetComponent<AudioSource>();
        */
        if (effect1 == null)
        {
            Debug.Log("Asla");
        }
    }

    void Update()
    {
        var effectEmission1 = effect1.emission;
        ++frames;
        float timeNow = Time.realtimeSinceStartup;

        if (effectTrigger1 && effect1.name == "flower")
        {
            // Debug.Log("Effect Trigger");
            //var effectEmission1 = effect1.emission;
            effectEmission1.enabled = true;
            Debug.Log("Flower enabled");
        }
        else if (!effectTrigger1 && effect1.name == "flower")
        {
            //var effectEmission1 = effect1.emission;
            effectEmission1.enabled = false;
            //Debug.Log("Snow Disabled");
        }

        if (effectTrigger2 && effect1.name == "snow2")
        {
            //Debug.Log("Entering Flower");
            //var effectEmission2 = effect2.emission;
            effectEmission1.enabled = true;
            if (effectEmission1.enabled)
            {
                Debug.Log("Snow enabled");
            }
            else
            {
                //Debug.Log("Effect2 not enabled");
            }
            
        }
        else if (!effectTrigger2 && effect1.name == "snow2")
        {
            //Debug.Log("Exiting Flower");
            //var effectEmission2 = effect2.emission;
            effectEmission1.enabled = false;
        }
    }

 

    IEnumerator ReadCSVfile()
    {
        StreamReader strReader = new StreamReader("C:\\Users\\team3\\Import1\\Assets\\Resources\\demo22.csv");
        bool endOfFile = false;
        int count = 0, sum = 0, average = 0;
        int currentHeartRate;
        int previous_HR = 0;
        //int add_trigger_time = 0;
        int interval = 5;
        int HeartRateAvg = 0;

        while (!endOfFile)
        {
            string data_String = strReader.ReadLine();
            if (data_String == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_String.Split(';');
            for (int o = 0; o < data_values.Length; o++)
            {
                //Debug.Log(data_values[2].ToString());
                yield return new WaitForSeconds(1);
            }

            currentHeartRate = int.Parse(data_values[2]);
            Debug.Log("Current HR:");
            Debug.Log(currentHeartRate);
            sum = sum + currentHeartRate;
            Debug.Log("Progressive Sum");
            Debug.Log(sum);
            count = count + 1;

            if (count % interval == 0)
            {
                Debug.Log("SUM");
                Debug.Log(sum);
                Debug.Log("COUNT");
                Debug.Log(count);
                average = sum / interval;
                HeartRateAvg = average / 10;
                HeartRateAvg = HeartRateAvg * 10;

                trigger(HeartRateAvg, previous_HR);
                previous_HR = HeartRateAvg;
                sum = 0;
                //Debug.Log(sum);

            }
            //Debug.Log(data_values[2].ToString());
            //Debug.Log(count);
            yield return new WaitForSeconds(1);


        }
    }
    void trigger(int HeartRateAvg, int previous_HR)
    {
        int caseSwitch = HeartRateAvg;

        switch (caseSwitch)
        {
            case 70:
                Debug.Log("Case1");

                {

                    if (previous_HR == 80)
                    {
                        //stop audio 3 and effecs 01
                        //Add transition out for audio 3
                        if (effect1.name == "flower")
                        {
                            effectTrigger1 = false;

                        }
                        //clip3.Stop();
                        audio.clip = clip3;
                        audio.Stop();
                        //audio3.Stop();
                    }
                    else if (previous_HR == 90)
                    {
                        //stop audio 4 and effecs 2
                        //Add transition out for audio 4
                        if (effect1.name == "snow2")
                        {
                            effectTrigger2 = false;

                        }
                        //   effectTrigger2 = false;
                        //clip4.Stop();
                        audio.clip = clip4;
                        audio.Stop();
                        //audio4.Stop();

                    }
                    else if (previous_HR == 70)
                    {
                        //continue audio 2
                        //audio2.PlayOneShot(clip2, 1.25f);

                    }
                    else
                    {
                        // stop audio 1
                        audio.clip = clip1;
                        audio.Stop();
                        //clip1.Stop();
                    }

                    if (previous_HR != HeartRateAvg)
                    {
                        // start audio 2
                        audio.clip = clip2;
                        audio.Play();
                        //clip2.Play();
                    }

                }
                break;

            case 80:
                Debug.Log("Case2");

                {

                    if (previous_HR == 70)
                    {
                        //stop audio 2
                        audio.clip = clip2;
                        audio.Stop();
                        //clip2.Stop();

                    }
                    else if (previous_HR == 90)
                    {
                        //stop audio 4 and effects 2
                        if (effect1.name == "snow2")
                        {
                            effectTrigger2 = false;

                        }
                        //effectTrigger2 = false;
                        audio.clip = clip4;
                        audio.Stop();
                        //clip4.Stop();
                    }
                    else if (previous_HR == 80)
                    {
                        //continue audio 3
                        //audio3.PlayOneShot(clip3, 0.75f);
                    }
                    else
                    {
                        // stop audio 1
                        audio.clip = clip1;
                        audio.Stop();
                        //clip1.Stop();
                    }

                    if (previous_HR != HeartRateAvg)
                    {
                        // start audio 3
                        //audio3 = GetComponent<AudioSource>();
                        audio.clip = clip3;
                        audio.Play();
                        //clip3.Play();
                    }
                    //First Effect is enabled here
                    if (effect1.name == "flower")
                    {
                        effectTrigger1 = true;

                    }
                    //effectTrigger1 = true;

                }
                break;

            case 90:
                Debug.Log("Case3");

                {
                    if (previous_HR == 70)
                    {
                        //stop audio 2
                        audio.clip = clip2;
                        audio.Stop();
                        //clip2.Stop();
                    }
                    else if (previous_HR == 80)
                    {
                        //stop audio 3 and effecs 1
                        //fireflyTrigger = False
                        if (effect1.name == "flower")
                        {
                            effectTrigger1 = false;

                        }
                        //effectTrigger1 = false;
                        audio.clip = clip3;
                        audio.Stop();
                        //clip3.Stop();
                    }
                    else if (previous_HR == 90)
                    {
                        //continue audio 4
                        //audio4.PlayOneShot(clip4, 1.0f);
                    }
                    else
                    {
                        // stop audio 1
                        audio.clip = clip1;
                        audio.Stop();
                        //clip1.Stop();
                    }

                    if (previous_HR != HeartRateAvg)
                    {
                        // start audio 4
                        //audio3 = GetComponent<AudioSource>();
                        audio.clip = clip3;
                        audio.Play();
                        //clip4.Play();
                    }
                    //Enabling second effect
                    if (effect1.name == "snow2")
                    {
                        effectTrigger2 = true;

                    }
                    //effectTrigger2 = true;
                }
                break;

            default:
                Debug.Log("Default case");

                {



                    if (previous_HR == 70)
                    {
                        //stop audio 2
                        audio.clip = clip2;
                        audio.Stop();
                        //clip2.Stop();

                    }
                    else if (previous_HR == 90)
                    {
                        //stop audio 4 and effecs 2
                        //fireflyTrigger = False
                        if (effect1.name == "snow2")
                        {
                            effectTrigger2 = false;

                        }
                        //effectTrigger2 = false;
                        audio.clip = clip4;
                        audio.Stop();
                        //clip4.Stop();
                    }
                    else if (previous_HR == 80)
                    {
                        //stop audio 3 and stop effect trigger 1
                        if (effect1.name == "flower")
                        {
                            effectTrigger1 = false;

                        }
                        // effectTrigger1 = false;
                        audio.clip = clip3;
                        audio.Stop();
                        //clip3.Stop();
                    }
                    else
                    {
                        // continue audio 1

                    }

                    if (previous_HR != HeartRateAvg)
                    {
                        // start audio 1
                        audio.clip = clip1;
                        audio.Play();
                        //clip1.Play();
                    }

                }
                break;
        }
    }
}