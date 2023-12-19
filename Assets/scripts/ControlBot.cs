using interfaz;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace enemigos
{
    public class ControlBot : MonoBehaviour
    {
        #region variables
        [Header("Especificaciones")]
        public int hp;
        public NavMeshAgent enemy;
        public Transform player;
        public static int Kills;
        [SerializeField] Rigidbody rb;

        [Header("Animaciones")]
        public Animator animator;
        #endregion

        #region void b�sicos
        private void Awake()
        {
            player = GameObject.Find("Player").transform;
            enemy = GetComponent<NavMeshAgent>();
        }
        private void Start()
        {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true; //para que no se caiga.
        }
        private void Update()  //persecuci�n al jugador
        {
            enemy.SetDestination(player.position);
            transform.LookAt(player);
            animaciones();
        }
        #endregion

        #region code
        void animaciones()
        {
            animator.SetBool("caminando", true);
        }
        public void recibirDa�o() //l�gica para recibir da�o
        {
            hp = hp - 25;
            if (hp <= 0)
            {
                animator.SetBool("Muerte", true);
                Destroy(gameObject, 2f);
                Kills++;
                //Debug.Log("Enemigos eliminados: " + Kills);
            }
        }

        private void OnCollisionEnter(Collision collision) //si entra en colision con bala, llamar a l�gica para recibir da�o
        {
            if (collision.gameObject.CompareTag("Bala"))
            {
                recibirDa�o();
            }
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("da�ando a jugador");
                animator.SetBool("Attack", true);
                DesactivarAtaque(5.0f);
            }
        }
        void DesactivarAtaque(float cooldown) //para que luego de un ataque se desactive la animacion y vuelva a la de correr
        {
            new WaitForSeconds(cooldown);
            animator.SetBool("Attack", false);
        }
        #endregion
    }
}
