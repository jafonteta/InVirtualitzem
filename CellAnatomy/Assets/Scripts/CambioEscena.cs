using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    [SerializeField]
    protected EasyAudioUtility_SceneManager miEasyAudio;

    private void Start()
    {
        miEasyAudio = FindObjectOfType<EasyAudioUtility_SceneManager>();
    }
    public void CargarEscena(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        miEasyAudio.onSceneChange(sceneName);
    }

    
}
