using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DesactivarRayoOnSelect : MonoBehaviour
{
    public XRInteractorLineVisual miLinea;

    // Start is called before the first frame update
    void Start()
    {
        if(miLinea == null)
        {
            miLinea = this.GetComponent<XRInteractorLineVisual>();
        }
    }

    public void DesactivaRayoOnSelect()
    {
        miLinea.enabled = false;
    }

    public void ActivarRayOnSelect()
    {
        miLinea.enabled = true;
    }

}
