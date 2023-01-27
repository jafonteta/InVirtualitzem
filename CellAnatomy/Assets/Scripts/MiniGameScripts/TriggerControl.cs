using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControl : MonoBehaviour
{
    [Header("TIPO DE CÉLULA")]
    public string tipo;
    
    [Space(10)]

    [Tooltip("La cantidad de orgánulos que se deben colocar en este trigger en la partida")]
    public int cantidadTotalOrganulos = 0;

    public int contadorOrganulos = 0;

    MiniGameControl miniController;

    // Start is called before the first frame update
    void Start()
    {
        miniController = FindObjectOfType<MiniGameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == tipo && contadorOrganulos < cantidadTotalOrganulos)
        {
            contadorOrganulos += 1;
        }

        if(contadorOrganulos == cantidadTotalOrganulos)
        {
            miniController.categoriaConseguida[0] = true;
        }
    }

}
