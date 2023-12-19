using UnityEditor;
using UnityEngine;

namespace Pistola
{
    public class PistolaConf : MonoBehaviour
    {  //este codigo era para que la pistola se mueva y se note un poco de peso al mover/rotar la cámara
        #region Variables
        public float intensidad;
        public float suavizado;
        private Quaternion Rotacion_Inicial;
        #endregion

        #region voids basicos
        void Start()
        {
            Rotacion_Inicial = transform.localRotation;
        }

        // Update is called once per frame
        void Update()
        {
            SwayUpdate();
        }
        #endregion

        #region Code
        void SwayUpdate()
        {
            //controles
            float mouse_x = Input.GetAxis("Mouse X");
            float mouse_y = Input.GetAxis("Mouse Y");

            //rotacion
            Quaternion ajuste_Pistola_X = Quaternion.AngleAxis(intensidad * mouse_x, Vector3.up);
            Quaternion ajuste_Pistola_Y = Quaternion.AngleAxis(intensidad * mouse_y, Vector3.right);
            Quaternion Rotacion_Pistola = Rotacion_Inicial * ajuste_Pistola_X * ajuste_Pistola_Y;

            //rotar hacia el jugador
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Rotacion_Pistola, Time.deltaTime * suavizado);

        }
        #endregion
    }
}
