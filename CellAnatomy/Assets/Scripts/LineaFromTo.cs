using System.Collections;
using UnityEngine;

public class LineaFromTo : MonoBehaviour
{
    [Space]
    [Header("PERSONALIZA EL OBJETO A SEÑALIZAR ")]
    public Transform organuloLink;

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
    [Header("Regula el clipStar para que el inicio de la linea nazca cerca de la superficie ")]
    [Range(0.0f, 100.0f)]
    [SerializeField]
    protected float clipStart = 0;
    [Range(0.0f, 100.0f)]
    [SerializeField]
    protected float clipEnd = 75;
  


    void Start()
    {
        
        puntos[0] = organuloLink;
        puntos[1] = this.gameObject.transform;
        //this.transform.position = new Vector3(organuloLink.position.x, this.transform.position.y, organuloLink.position.z);
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
        //this.gameObject.SetActive(false);
    }

    void Update()
    {


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

    }
}
