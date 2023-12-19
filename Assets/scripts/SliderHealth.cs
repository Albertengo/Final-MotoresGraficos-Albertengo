using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace interfaz
{
    public class SliderHealth : MonoBehaviour
    {
        public Slider slider;

        #region code
        private void Start()
        {
            slider = GetComponent<Slider>();
        }

        //Para que el máximo del slider sea la cantidad de vida del pj
        public void SetMaxHealth(float vidaMax)
        {
            slider.maxValue = vidaMax;
            slider.value = vidaMax;
        }
        //Para ir actualizando la vida en el slider desde otros scripts
        public void SetHealth(float vida)
        {
            slider.value = vida;
        }
        //configura la vida desde el inicio del juego en otros scripts
        public void startHealthBar(float vida)
        {
            SetMaxHealth(vida);
            SetHealth(vida);
        }
        //desactiva el slider
        public void Desactivar()
        {
            gameObject.SetActive(false);
        }
        //activa el slider
        public void Activar()
        {
            gameObject.SetActive(true);
        }
        #endregion
    }
}
