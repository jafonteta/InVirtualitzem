using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasaMenuInvocacion : MonoBehaviour
{
    [SerializeField]
    protected EasyAudioUtility_SceneManager miEasyAudio;

    [SerializeField]
    protected Animator miAnimation;

    public string nombreEscenaMenu = "Escena_02_Menu";
    // Start is called before the first frame update
    void Start()
    {
        miEasyAudio = FindObjectOfType<EasyAudioUtility_SceneManager>();
        Invoke("PasarEscena", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PasarEscena()
    {
        miAnimation.SetTrigger("FadeIn");
        SceneManager.LoadScene(nombreEscenaMenu);
        miEasyAudio.onSceneChange(nombreEscenaMenu);
        miAnimation.SetTrigger("FadeOut");
    }

   
}
