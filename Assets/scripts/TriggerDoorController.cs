using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator Puerta = null;

    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Tag colisionada: " + other.gameObject.tag);
        if (other.gameObject.CompareTag("Player")) //si jugador es lo que entra en el trigger,
        {
            if (openTrigger) //(si open trigger es activado) abrir puerta con animación
            {
                Puerta.Play("DoorOpen", 0, 0.0f);
                Puerta.SetBool("open", true);
                gameObject.SetActive(false);
                //Debug.Log("Door is open");
            }
            else if (closeTrigger) // (si close trigger es activado) cerrar puerta con animación
            {
                Puerta.Play("DoorClose", 0, 0.0f);
                gameObject.SetActive(false);
                Puerta.SetBool("close", true);
                //Debug.Log("Door is closed");
            }
        }
    }
}
