using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MiniGameControl : MonoBehaviour
{
    [Header("CONTROL DE ACIERTOS")]
    public bool[] categoriaConseguida;
    // Start is called before the first frame update
    [Space(10)]

    [Header("CONTROL DE ORGÁNULOS POR CATEGORIA")]
    [Tooltip("Estos son los TriggerControl de la escena, asignar públicamente")]
    public TriggerControl[] controladoresTriggers = new TriggerControl[3];
    public int[] cantidadOrganulosCategoria = new int[3];

    [Space(10)]

    [Header("SOCKETS y ORGÁNULOS")]
    [Tooltip("Estos son los Sockets que hay en el juego")]
    public GameObject[] sockets;
    [Tooltip("Estos son los prefabs de orgánulos")]
    public GameObject[] organulos;
    [Tooltip("Estos son orgánulos que están en juego en la partida")]
    public List<GameObject> organulosAsignados;

    // Para el sorteo de números
    public List<int> numerosSorteoOrganulos;
    int numAleatorio;

    



    void Start()
    {
        numerosSorteoOrganulos = new List<int>(sockets.Length);
        AsignarOrganulosToSockects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AsignarOrganulosToSockects()
    {
        Debug.Log("Llamado Asignar organulos sockets");

        // Sorteamos números aleatorios y creamos una lista de ellos, que nos servirán para asignar orgánulos aleatorios en los sockets.
        // Nos aseguramos que ese número aleatorio no haya salido antes, para no colocar objetos del array repetidos
        // Para poder repetir el juego limpiamos la lista de numerosSorteoOrganulos antes de volver a rellenar;
        numerosSorteoOrganulos.Clear();
        for (int i = 0; i < sockets.Length; i++)
        {
            numAleatorio = Random.Range(0, organulos.Length);

            while (numerosSorteoOrganulos.Contains(numAleatorio))
            {
                numAleatorio = Random.Range(0, organulos.Length);
            }

            numerosSorteoOrganulos.Add(numAleatorio);
            
                Debug.Log(numerosSorteoOrganulos[i]);
        }

        //Antes de empezar, vamos a resetear a 0 el contador de objetos por categoría
        ResetContadorObjetosCategoria();
        // Por cada uno de los sockets haremos
        for (int a = 0; a < sockets.Length; a++)
        {
            // Asignamos un orgánulo al azar al socket. Lo instanciamos y lo asignamos hijo del socket
            GameObject organulo = Instantiate(organulos[numerosSorteoOrganulos[a]] , sockets[a].transform.position , organulos[numerosSorteoOrganulos[a]].transform.rotation);

            //Vamos a contabilizar a qué categoría pertenece
            ContabilizarCategoria(organulo.transform.tag);

            // Añadimos el objeto a una lista de Objetos en juego "organulosAsignados"
            organulosAsignados.Add(organulo);
            
            // Al objeto, a su componente MiniOrganuloID le asignamos el ID de la pasada o socket actual
            organulo.GetComponent<MiniOrganuloID>().socketID = a;
            
            // Al objeto, a su componente XR Grab interactable le asignamos la interaction layer mask de la pasada o socket actual
            organulo.GetComponent<XRGrabInteractable>().interactionLayers = InteractionLayerMask.GetMask(a.ToString());

            // Al socket, a su componente XR Socket interactor, le asignamos a la "interaction layer Mask la id del socket o pasada de bucle"
            // Esto no es necesario si lo tenemos asignado al socket en la escena desde el principio.
            sockets[a].GetComponent<XRSocketInteractor>().interactionLayers = InteractionLayerMask.GetMask(a.ToString());

            //Al socket, a su componente XR Socket interactor, le asignamos a "Starting Selected interactable" el XR base interactable del objeto asignado
            sockets[a].GetComponent<XRSocketInteractor>().startingSelectedInteractable = organulo.GetComponent<XRGrabInteractable>();

        }

        // Pasar el conteo de objetos contabilizados por categoría al trigger correspondiente
        for(int j = 0; j < controladoresTriggers.Length; j++)
        {
            controladoresTriggers[j].cantidadTotalOrganulos = cantidadOrganulosCategoria[j];
        }

    }

    void ResetContadorObjetosCategoria()
    {
        for(int i = 0; i < cantidadOrganulosCategoria.Length; i++)
        {
            cantidadOrganulosCategoria[i] = 0;
        }
    }

    void ContabilizarCategoria(string tagObjeto)
    {
            switch (tagObjeto)
            {
                case "Animal":
                cantidadOrganulosCategoria[0] += 1; 
                    break;
                case "Vegetal":
                cantidadOrganulosCategoria[1] += 1;
                break;
                case "Procariota":
                cantidadOrganulosCategoria[2] += 1;
                break;
                default:
                    print("Poooos");
                    break;
            }
        
    }

}
