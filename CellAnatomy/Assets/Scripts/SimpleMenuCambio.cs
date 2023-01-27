using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMenuCambio : MonoBehaviour
{
    public GameObject objetoActivado;
    public GameObject objetoDesactivado;
    // Start is called before the first frame update

    public void CambioMenu()
    {
        objetoActivado.SetActive(true);
        objetoDesactivado.SetActive(false);
    }
}
