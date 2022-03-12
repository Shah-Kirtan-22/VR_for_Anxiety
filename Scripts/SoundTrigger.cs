using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioSource sound;
  
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    void OnCollisiomEnter(Collision collision)
    {
        if (collision.gameObject.tag == "River")
        {
            sound.Play();
        }
    }

}
