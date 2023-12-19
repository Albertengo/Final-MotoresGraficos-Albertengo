using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivar : MonoBehaviour
{
    //solo para desactivar un objeto especifico
    void Start()
    {
        gameObject.SetActive(false);
    }
}
