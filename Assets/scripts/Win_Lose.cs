using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace interfaz
{
    public class Win_Lose : MonoBehaviour
    {
        public GameObject musica;
        void Start()
        {
            gameObject.SetActive(false);
        }

        public void ActiveScreen()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            musica.SetActive(false);
        }
    }
}
