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
 
        SceneManager.LoadScene(sceneName);
        
        if(miEasyAudio == null)
        {
            CheckForAudioEsceneManager();
        }
        if(miEasyAudio != null)
        {
            miEasyAudio.onSceneChange(sceneName);
        }
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
