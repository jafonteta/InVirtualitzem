using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMenuCambio : MonoBehaviour
{
    public GameObject[] canvas;
    public int idActivar;
    public int idCanvasActual;
    // Start is called before the first frame update

    public void CambioMenu()
    {
        canvas[idActivar].SetActive(true);
        print("Activado canvas " + idActivar);
        /*
        for(int i = 0; i < canvas.Length; i++)
        {
            if(i != idActivar || i != idCanvasActual)
            {
                canvas[i].SetActive(false);
            }
        }
        */
        canvas[idCanvasActual].SetActive(false);
    }
}
