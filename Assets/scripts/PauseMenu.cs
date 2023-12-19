using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace interfaz
{
    public class PauseMenu : MonoBehaviour
    {
        #region variables
        public GameObject MenuPausa;
        public bool isPaused;
        public SliderHealth slider;
        public GameObject Objetivos;
        public GameObject musica;
        #endregion

        #region voids basicos
        // Update is called once per frame
        void Update()
        {
            MenuDePausa();
        }
        #endregion

        #region code
        //la lógica del menu de pausa
        void MenuDePausa()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused) //mientras el juego esté pausado, lo único que hará el escape será resumir el juego.
                {
                    ResumeGame();
                    slider.Activar();
                }
                else //mientras el juego esté activo, lo único que hará el escape será pausarlo.
                {
                    PauseGame();
                    slider.Desactivar();
                }
            }
        }
        void PauseGame()
        {
           MenuPausa.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
            Cursor.lockState = CursorLockMode.None;
            musica.SetActive(false);
        }
        public void ResumeGame() //desactiva el menú de pausa y el de objetivos si es que está activo.
        {
            MenuPausa.SetActive(false);
            if (Objetivos != null)
            {
                Objetivos.SetActive(false);
            }
            Time.timeScale = 1f;
            isPaused = false;
            Cursor.lockState = CursorLockMode.Locked;
            musica.SetActive(true);
        }

        public void objectives() //activa la pantalla de objetivos.
        { 
            Objetivos.SetActive(true);
        }
        #endregion
    }
}
