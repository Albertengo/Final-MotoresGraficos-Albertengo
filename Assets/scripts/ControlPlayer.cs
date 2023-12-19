using interfaz;
using UnityEngine;

namespace Player
{
    public class ControlPlayer : MonoBehaviour
    {
        //script attached to the player
        #region variables
        [Header("Movimiento")]
        public float rapidezDesplazamiento = 10.0f;
        public float modificadorSprint;
        [SerializeField] Rigidbody rb;
        Vector3 direccion;
        public Transform Orientation;

        [Header("GroundCheck")]
        public float PlayerHeight;
        public LayerMask WhatIsGround;
        public float GroundDrag;
        bool grounded;

        [Header("UI")]
        public SliderHealth slider;
        public Win_Lose screenW;
        #endregion

        #region voids basicos
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true; //para que player no se caiga.
        }
        private void Update()
        {
            //chequea que esté en el piso.
            grounded = Physics.Raycast(transform.position, Vector3.down, (float)(PlayerHeight * 0.5 + 0.2), WhatIsGround);

            if (grounded)
                rb.drag = GroundDrag;
            else 
                rb.drag = 0;
        }

        void FixedUpdate()
        {
            movimiento();
            speedControl();
        }
        #endregion

        #region code
        void movimiento()
        {
            float speedsprint = rapidezDesplazamiento; //para poder modificar la rapidez dentro del código sin alterar la default.

            //movimiento normal.
            float movimientoAdelanteAtras = Input.GetAxis("Vertical");
            float movimientoCostados = Input.GetAxis("Horizontal");
            direccion = Orientation.forward * movimientoAdelanteAtras + Orientation.right * movimientoCostados; //obtiene informacion de la direccion mediante el transform usado


            //lógica para el sprint
            bool correr = Input.GetKey(KeyCode.LeftShift); //mientras se presione shift, bool será true.
            bool esta_corriendo = correr && movimientoAdelanteAtras > 0; // mientras correr sea true y se esté caminando en eje z, bool será true.
            if (esta_corriendo) speedsprint *= modificadorSprint; //mientras bool sera true, la velocidad será modificada.
            
            //desplaza el rigidbody hacia la direccion que se esté mirando con la velocidad configurada
            rb.AddForce(direccion.normalized * speedsprint * 10f, ForceMode.Force); // *10f para hacerlo un poco más rápido
        }

        //para controlar que no se pase la velocidad.
        void speedControl()
        {
            Vector3 flatVelocity = new Vector3 (rb.velocity.x, 0f, rb.velocity.z); //calcula la velocidad alcanzada

            if (flatVelocity.magnitude > rapidezDesplazamiento) //si esa velocidad se llega a pasar de la default,
            {
                Vector3 LimitedVel = flatVelocity.normalized * rapidezDesplazamiento; //calcula la max velocidad que se puede alcanzar
                rb.velocity = new Vector3 (LimitedVel.x, rb.velocity.y, LimitedVel.z); //y la aplica
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Meta")) //si entra en el trigger de la meta, gana.
            {
                screenW.ActiveScreen();
                slider.Desactivar();
            }
        }
        #endregion

    }
}
