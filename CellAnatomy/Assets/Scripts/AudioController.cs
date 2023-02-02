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

    [Header("Ajustar solo para el Toggle VoiceOnOff")]
    public Toggle mToggleOnOff;
    float tempFlotanteParametroAjustable;

    private void OnEnable()
    {
        if(sliderCompo == null)
        {
            sliderCompo = GetComponent<Slider>();
        }
        if (sliderCompo != null)
        {
            SetSliderValue();
        }

    }

    private void Start()
    {
        m_audioFuente = GetComponent<AudioSource>();

        sliderCompo = GetComponent<Slider>();
        if(sliderCompo != null)
        {
            SetSliderValue();
        }
    }
    public void SetVolume(float sliderTemp)
    {
        //mezcladorAudio.SetFloat(parametroAjustable, Mathf.Log10(sliderTemp) * 20);

        // esto habría que revisarlo
        if (mToggleOnOff == null || (mToggleOnOff != null && mToggleOnOff.isOn == true))
        {
            mezcladorAudio.SetFloat(parametroAjustable, sliderTemp);
        }
 
    }

    public void SetSliderValue()
    {
        mezcladorAudio.GetFloat(parametroAjustable, out tempFlotanteParametroAjustable);
        sliderCompo.value = tempFlotanteParametroAjustable;
        Debug.Log("Valor del volumen del mezclador" + tempFlotanteParametroAjustable);
    }
    public void SetVolumeVoiceOnOff()
    {
        if(mToggleOnOff != null)
        {
            switch (mToggleOnOff.isOn)
            {
                case true:
                    mezcladorAudio.SetFloat(parametroAjustable, tempFlotanteParametroAjustable);
                    break;
                case false:
                    mezcladorAudio.GetFloat(parametroAjustable, out tempFlotanteParametroAjustable);
                    mezcladorAudio.SetFloat(parametroAjustable, -80);
                    break; 
                default:
            }
        }
    }
}
