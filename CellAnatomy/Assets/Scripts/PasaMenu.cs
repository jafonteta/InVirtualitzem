using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasaMenu : MonoBehaviour
{
    [SerializeField]
    protected EasyAudioUtility_SceneManager miEasyAudio;

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
        SceneManager.LoadScene(nombreEscenaMenu);
        miEasyAudio.onSceneChange(nombreEscenaMenu);
    }

   
}
