using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{

    [SerializeField]
    protected AudioMixer mezcladorAudio;

    public string parametroAjustable;

    [Header("Activar Muestro al Ajustar Slide")]
    public bool muestraDeAudio = false;
    AudioSource m_audioFuente;

    Slider sliderCompo;

    private void Start()
    {
        m_audioFuente = GetComponent<AudioSource>();

        sliderCompo = GetComponent<Slider>();
        if(sliderCompo != null)
        {
            SetVolume(sliderCompo.value);
        }
    }
    public void SetVolume(float sliderTemp)
    {
        print("Slider temp = " + sliderTemp);
        mezcladorAudio.SetFloat(parametroAjustable, Mathf.Log10(sliderTemp) * 20);
        print("Setfloat" + Mathf.Log10(sliderTemp) * 20);
    }
}
