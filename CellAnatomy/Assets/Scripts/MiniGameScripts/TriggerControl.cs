using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControl : MonoBehaviour
{
    [Header("TIPO DE CÉLULA y CATEGORÍA ID")]
    [Tooltip("Animal, Vegetal o Procariota")]
    public string tipo;
    [Tooltip("Animal = 0 ; Vegetal = 1; Procariota = 2")]
    public int categoriaID = 0;

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
        miniController.DesactivarSocketOrigen(other.GetComponent<MiniOrganuloID>().socketID);

        if(other.transform.tag == tipo && contadorOrganulos < cantidadTotalOrganulos)
        {
            contadorOrganulos += 1;
        }

        if(contadorOrganulos == cantidadTotalOrganulos)
        {
            miniController.categoriaConseguida[categoriaID] = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        miniController.ActivarSocketOrigen(other.GetComponent<MiniOrganuloID>().socketID);

        if (other.transform.tag == tipo && (contadorOrganulos < cantidadTotalOrganulos && contadorOrganulos > 0))
        {
            contadorOrganulos -= 1;
        }

        if (contadorOrganulos != cantidadTotalOrganulos)
        {
            miniController.categoriaConseguida[categoriaID] = false;
        }

    }

}
