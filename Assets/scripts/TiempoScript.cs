using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace interfaz
{
    public class TiempoScript : MonoBehaviour
    {
        public TextMeshProUGUI TiempoTexto;

        void Start()
        {
            TiempoTexto = GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            TiempoTexto.text = "Quedan " + ControlJuego.tiempoRestante + "s.";
        }
    }
}