using UnityEngine.XR.Interaction.Toolkit;

public class OffsetInteractableOriginal : XRGrabInteractable
{
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);
        MatchAttachPoint(args.interactor);
    }

    private void MatchAttachPoint(XRBaseInteractor interactor)
    {
        bool isDirect = interactor is XRDirectInteractor;
        attachTransform.position = isDirect ? interactor.attachTransform.position : transform.position;
        attachTransform.rotation = isDirect ? interactor.attachTransform.rotation : transform.rotation;
    }
}









