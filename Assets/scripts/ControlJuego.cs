using interfaz;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using enemigos;

public class ControlJuego : MonoBehaviour
{
    #region Variables
    [Header("Personajes")]
    public GameObject jugador;
    public GameObject bot;

    [Header("UI")]
    public Win_Lose screenW;
    public Win_Lose screenL;
    public SliderHealth slider;
    public Desactivar crosshair;
    public static float tiempoRestante;

    [Header("Spawner")]
    public int xPos;
    public int zPos;
    public static int CantidadEnemigos;
    #endregion

    #region voids basicos
    void Start()
    {
        ComenzarJuego();
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoRestante == 0) //si el tiempo llega a 0, gameover.
        {
            ComenzarJuego();
            screenL.ActiveScreen();
            slider.Desactivar();
        }
    }
    #endregion

    #region Code
    void ComenzarJuego() //configura la inicializacion del juego. (posición, cronómetro y spawns)
    {
        StartCoroutine(SpawnEnemigos());
        StartCoroutine(Cronometro(60));
        crosshair.gameObject.SetActive(true);
    }
    IEnumerator SpawnEnemigos()
    {
        while (CantidadEnemigos < 8)
        {
            xPos = Random.Range(1, 10); //randomiza posición de enemigos
            zPos = Random.Range(1, 10);
            Instantiate(bot, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(3f);
            CantidadEnemigos += 1;
        }
    }
    public IEnumerator Cronometro(float valorCronometro = 60)
    {
        tiempoRestante = valorCronometro;
        while (tiempoRestante > 0)
        {
            yield return new WaitForSeconds(1.0f);
            tiempoRestante--;
        }
    }
    #endregion
}
