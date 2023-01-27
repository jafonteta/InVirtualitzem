using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSetup : MonoBehaviour
{

    [SerializeField]
    protected RectTransform rectViculado;
    public float margen = 100;
    RectTransform miTransform;
    Rect miRect;
    // Start is called before the first frame update
    void Start()
    {
        miTransform = this.gameObject.GetComponent<RectTransform>();
        miRect = miTransform.rect;
    }

    // Update is called once per frame
    void Update()
    {
        miTransform.localScale = rectViculado.localScale;
        miTransform.anchoredPosition3D = rectViculado.anchoredPosition3D;
        miTransform.sizeDelta = new Vector2(rectViculado.sizeDelta.x + margen , rectViculado.sizeDelta.y + margen);
    }
}
