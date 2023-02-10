using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    [SerializeField]
    protected EasyAudioUtility_SceneManager miEasyAudio;

    GameObject faderObject;

    [Header("ESTO SE ASIGNARÁ SOLO")]
    Animator faderAnimator;

    [Header("RETRASO AL CARGAR")]
    [Tooltip("Este es el tiempo que va a tardar en cargar la escena, permitiendo que el audio se termine de reproducir, y el fade In funcionar")]
    public float retrasoCarga = 0.5f;

    private string escenaAcargar;

    private void Start()
    {
        if(faderAnimator == null)
        {
            CheckForAnimator();
        }
        
       
    }
    public void CargarEscena(string sceneName)
    {
        if (faderAnimator == null)
        {
            faderObject = GameObject.FindGameObjectWithTag("Fader");
            faderAnimator = faderObject.GetComponent<Animator>();
        }
        if(faderAnimator != null)
        {
            faderAnimator.SetTrigger("FadeIn");
        }

        escenaAcargar = sceneName;
        Invoke("CargarEscenaDealay", retrasoCarga);
        
        if(miEasyAudio == null)
        {
            CheckForAudioEsceneManager();
        }
        if(miEasyAudio != null)
        {
            miEasyAudio.onSceneChange(sceneName);
        }
        
    }

    void CargarEscenaDealay()
    {
        SceneManager.LoadScene(escenaAcargar);
        if (faderAnimator != null)
        {
            faderAnimator.SetTrigger("FadeOut");
        }
    }

    void CheckForAnimator()
    {
        faderObject = GameObject.FindGameObjectWithTag("Fader");
        faderAnimator = faderObject.GetComponent<Animator>();
    }

    void CheckForAudioEsceneManager()
    {
        miEasyAudio = FindObjectOfType<EasyAudioUtility_SceneManager>();
    }
    
}
