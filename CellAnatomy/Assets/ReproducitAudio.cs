using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproducitAudio : MonoBehaviour
{

    AudioSource miAudio;
    // Start is called before the first frame update
    void Start()
    {
        miAudio = GetComponent<AudioSource>();
    }


    public void ReproduceClipAudio()
    {
        //AudioClip miClip = miAudio
        miAudio.Play();
    }
}
