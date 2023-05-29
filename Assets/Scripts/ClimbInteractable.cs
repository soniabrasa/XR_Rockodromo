using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbInteractable : XRBaseInteractable
{
    public Player player;

    // el Interactor inicia por primera vez la selección de un Interactuable
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        Debug.Log($"{gameObject.name}.ClimbInteractable.OnSelectEntered");

        // Referencia ao interactuador
        MonoBehaviour interactor = (MonoBehaviour)args.interactorObject;

        player.SetPlayingHand(interactor, true);
    }

    //  Interactor finaliza la selección de un Interactuable 
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        Debug.Log($"{gameObject.name}.ClimbInteractable.OnSelectExited");

        MonoBehaviour interactor = (MonoBehaviour)args.interactorObject;

        player.SetPlayingHand(interactor, false);
    }

}
