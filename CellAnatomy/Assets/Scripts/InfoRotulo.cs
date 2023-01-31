using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoRotulo : MonoBehaviour
{
    public GameObject RotuloAsignado;

    public void Activar()
    {
        RotuloAsignado.SetActive(true);
    }

    public void Desactivar()
    {
        RotuloAsignado.SetActive(false);
    }

}
