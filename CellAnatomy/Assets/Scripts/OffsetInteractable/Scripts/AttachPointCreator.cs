using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachPointCreator : MonoBehaviour
{
    private void Awake()
    {
        CreateAttach();
    }

    private void CreateAttach()
    {
        if(TryGetComponent(out XRGrabInteractable interactable))
        {
            GameObject attachObject = new GameObject("Attach");

            attachObject.transform.SetParent(transform);
            attachObject.transform.localPosition = Vector3.zero;
            attachObject.transform.localRotation = Quaternion.identity;

            interactable.attachTransform = attachObject.transform;
        } 
    }
}
