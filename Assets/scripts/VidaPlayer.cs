using interfaz;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class VidaPlayer : MonoBehaviour
    {
        #region variables
        public float SaludMax = 15; //variable fija
        public float Salud;
        public SliderHealth healthbar;
        public Win_Lose screenL;
        #endregion

        #region funciones basicas
        void Start()
        {
            Salud = SaludMax;
            healthbar.startHealthBar(Salud);
            Debug.Log("Nivel de vida: " + Salud);
        }

        #endregion

        #region code

        //Funcion collision para que cuando colisiones con enemigo, tome da�o.
        public void OnCollisionEnter(Collision collision) //OnCollisionStay2D funciona pero baja muy rapido la vida
        {
            if (collision.gameObject.CompareTag("Enemy"))
                Da�o(2);
        }

        public void Da�o(float da�oRecibido) //funcion con la mecanica de tomar da�o.
        {
            Salud -= da�oRecibido;
            healthbar.SetHealth(Salud);
            Debug.Log("Recibi da�o de: " + da�oRecibido);
            if (Salud <= 0)
            {
                //Debug.Log("Moriste.");
                screenL.ActiveScreen();
                healthbar.Desactivar();
            }
        }
        #endregion
    }
}
