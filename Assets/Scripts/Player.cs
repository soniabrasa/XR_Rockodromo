using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : MonoBehaviour
{
    // Chatacter controller do XR Origin (player en 1º persoa)
    CharacterController charController;

    // XR Controller (action-based) dos controladores fillos de XR Origin
    ActionBasedController playingHand, secondaryHand;

    // Script dos controladores que retorna un Vector3 GetVelocity()
    Speedometer playingHandSpeedometer;

    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (playingHand != null)
        {
            // O Player móvese cara arriba co Interactor do controller dereito
            charController.Move(-1 * playingHandSpeedometer.GetVelocity() * Time.deltaTime);
        }
    }

    // Recibe un interactor y un bool OnselectEntered | OnSelectExited;
    public void SetPlayingHand(MonoBehaviour interactor, bool grab)
    {
        // Evento de agarre (grab) 
        // Calquer interactor grab que agarre
        // ese DirectInteractor, esta man, pasa a ser a principal (playingHand)
        // De ser o outro controller interactor (a outra man)
        // intercámbianse, a principal pasa a ser a secondaria
        if (grab)
        {
            secondaryHand = playingHand;

            // XR Controller (Action-based) declarados sen asignar (en uso)
            playingHand = interactor.GetComponent<ActionBasedController>();
            playingHandSpeedometer = interactor.GetComponent<Speedometer>();
        }

        // Evento de desagarrar (!grab)
        else
        {
            // NON existe unha secondaryHand
            // De non existir, pónse todo a null, porque todas des-agarraron
            // Caemos 
            if (secondaryHand == null)
            {
                // Non hai ningunha man principal
                playingHand = null;
                // Non hai Velocímetro
                playingHandSpeedometer = null;
            }

            else if (secondaryHand.name == interactor.name)
            {

                // SI existe unha secondaryHand
                // NON é o interactor que desatou o !grab (non é a man que des-agarrou)
                // Simplemente desestímase
                secondaryHand = null;
            }

            // SI existe unha secondaryHand
            // SI é o interactor que desatou o !grab (a man que des-agarrou)
            // Ésta pasa a ser a principal, a que ten agora o peso das físicas
            else
            {
                playingHand = secondaryHand;
                playingHandSpeedometer = playingHand.GetComponent<Speedometer>();
                secondaryHand = null;
            }
        }
    }
}
