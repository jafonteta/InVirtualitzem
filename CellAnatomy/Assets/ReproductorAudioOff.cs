using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproductorAudioOff : MonoBehaviour
{

    public AudioSource m_AudioOff;
    // Start is called before the first frame update
    void Start()
    {
        if(m_AudioOff == null)
        {
            m_AudioOff = GameObject.FindGameObjectWithTag("AudioSourceOff").GetComponent<AudioSource>();
        }
    }

    public void ReproduceAudioOff()
    {
        if(m_AudioOff != null)
        {
            if(m_AudioOff.isPlaying == false)
            {
                m_AudioOff.Play();
            }
        }
    }

}
