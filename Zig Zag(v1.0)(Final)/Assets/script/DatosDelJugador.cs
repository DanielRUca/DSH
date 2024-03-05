using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DatosDelJugador : MonoBehaviour
{
    public static DatosDelJugador datosDelJugadorInstancia;
    public Text monedas;
    public Text monedasFinal;
    public Text puntuacionNivel;

    public static int numeroMonedas = 0;
    public static int numeromonedasnivel = 0;
    public static int numeromonedasporniveles = 0;
    public static int puntuacion = 0;
    public static int puntuacionFinal = 0;
    

    private void Awake()
    {
        if(datosDelJugadorInstancia == null)
        {
            datosDelJugadorInstancia = this;

        }

        if((SceneManager.GetActiveScene().name == "EscenaNivel1"))
        {
        monedasFinal.text = "Monedas en este nivel: " + numeroMonedas;
        puntuacion = numeroMonedas * 2;
        puntuacionNivel.text = "Puntuacion en este nivel: " + puntuacion;
        numeromonedasnivel= numeroMonedas;
        puntuacionFinal += puntuacion;
        numeromonedasporniveles += numeromonedasnivel;
        }

        if((SceneManager.GetActiveScene().name == "EscenaNivel2"))
        {
        numeromonedasnivel = numeroMonedas - numeromonedasnivel;
        monedasFinal.text = "Monedas en este nivel: " + numeromonedasnivel;
        puntuacion = numeromonedasnivel * 3;
        puntuacionNivel.text = "Puntuacion en este nivel: " + puntuacion;
        puntuacionFinal += puntuacion;
        numeromonedasporniveles += numeromonedasnivel;
        }

        if((SceneManager.GetActiveScene().name == "EscenaNivel3"))
        {
        numeromonedasnivel = numeroMonedas - numeromonedasporniveles;
        monedasFinal.text = "Monedas en este nivel: " + numeromonedasnivel;
        puntuacion = numeromonedasnivel * 4;
        puntuacionFinal += puntuacion;
        puntuacionNivel.text = "Puntuacion en este nivel: " + puntuacion;
        }

        if((SceneManager.GetActiveScene().name == "Final"))
        {
        monedasFinal.text = "Total Monedas Recogidas: " + numeroMonedas;
        puntuacionNivel.text = "Puntuacion Total Final: " + puntuacionFinal;
        }
    }

    public void IncrementarMonedas(int m)
    {
        numeroMonedas+=m;
        monedas.text = "Monedas: " + numeroMonedas;
    }

}
