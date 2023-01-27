using UnityEngine;
using System.Collections;

public class AjustaLinea : MonoBehaviour
{
    [Space]
    [Header("PERSONALIZA EL OBJETO A SEÑALIZAR ")]
    [SerializeField]
    protected Transform objetoSenyalizado;

    [Space]
    [Header("Si el objeto tiene el anclaje mal activa el bool ejeDesplazado ")]
    [SerializeField]
    protected bool ejeDesplazado = false;

    [Space]
    [Header("Con el bool activado, este sería el objeto que marca el start de la línea ")]
    [SerializeField]
    protected Transform ejeStartDesplazado;

    [Space]
    [Header("Con el bool activado, este sería el objeto que marca el start de la línea ")]
    [SerializeField]
    protected float offsetEnd = 200;

Transform[] puntos = new Transform[2];
    Vector3 vectorDireccion, vectorStart, vectorEnd;
    [Space]
    [Header("Son los colores de la línea, no los toque si los quieres todos igual ")]
    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    // si hubiera que hacer más de dos puntos, la longitud de puntos debería serla misma que lengthOfLineRenderer
    int lengthOfLineRenderer = 2;

    [Space]
    [Header("El grosor de la línea ")]
    [SerializeField]
    protected float widthMultiplicador = 0.005f;

    [Space]
    [Header("Regula el clipStar para que el inicio de la line nazca cerca de la superficie ")]
    [Range(0.0f, 100.0f)]
    [SerializeField]
    protected float clipStart = 0;
    [Range(0.0f, 100.0f)]
    [SerializeField]
    protected float clipEnd = 75;

    [Space]
    [Header("NO ME TOQUES LAS BOLITAS ")]
    [SerializeField]
    protected GameObject[] trueBolitas = new GameObject[2];
    //GameObject[] trueBolitas = new GameObject[2];
    [Space]
    [Header("Asígna la cámara de la escena ")]
    [SerializeField]
    protected GameObject camaraObject;

    [Space]
    [Header("Activa esto si quieres que ´la cartela mire a cámara ")]
    [SerializeField]
    protected bool miraCamara = true;


    void Start()
    {
        if(camaraObject == null)
        {
            camaraObject = GameObject.FindGameObjectWithTag("MainCamera");
        }
        if(ejeDesplazado == false)
        {
            puntos[0] = objetoSenyalizado;
            ejeStartDesplazado.position = objetoSenyalizado.position;
        }
        else
        {
            puntos[0] = ejeStartDesplazado;
        }
        
        puntos[1] = this.gameObject.transform;
        this.transform.position = new Vector3(objetoSenyalizado.position.x, this.transform.position.y, objetoSenyalizado.position.z);
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = widthMultiplicador;
        lineRenderer.positionCount = lengthOfLineRenderer;
    
        CalcularPositions();

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1000f) },
            new GradientAlphaKey[] { new GradientAlphaKey(0.3f, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lineRenderer.colorGradient = gradient;
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if (miraCamara && camaraObject != null)
        {
            transform.LookAt(camaraObject.transform);
        }

        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        var points = new Vector3[lengthOfLineRenderer];
        //var t = Time.time;

        CalcularPositions();
        points[0] = vectorStart;
        points[1] = vectorEnd;

        lineRenderer.SetPositions(points);
    }

    void CalcularPositions()
    {
        vectorDireccion = puntos[1].position - puntos[0].position;
        vectorStart = puntos[0].position + (vectorDireccion * (clipStart / 100));
        vectorEnd = puntos[0].position + (vectorDireccion * (clipEnd / 100));

        trueBolitas[0].transform.position = vectorStart;
        trueBolitas[1].transform.position = vectorEnd;
    }
}