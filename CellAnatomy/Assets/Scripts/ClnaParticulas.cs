using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClnaParticulas : MonoBehaviour
{
    public GameObject prefabParticulas;



    public void clonamiento()
    {
        Instantiate(prefabParticulas, prefabParticulas.transform.position, Quaternion.identity);
    }

}
