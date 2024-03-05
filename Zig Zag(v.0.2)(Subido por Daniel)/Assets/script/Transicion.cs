using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transicion : MonoBehaviour
{


    public static IEnumerator EsperaEntreEscenas1()
    {
        yield return new WaitForSeconds(2);
        
        SceneManager.LoadScene("nivel2");
    }

    public static IEnumerator EsperaEntreEscenas2()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("nivel3");
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "EscenaNivel2")
        {
            StartCoroutine(Transicion.EsperaEntreEscenas1());
        }

        if (SceneManager.GetActiveScene().name == "EscenaNivel3")
        {
            StartCoroutine(Transicion.EsperaEntreEscenas2());
        }
         

    }

}
