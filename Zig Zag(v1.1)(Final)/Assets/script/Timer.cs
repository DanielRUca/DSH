using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer = 0;
    public Text textoTimer;



    void Update()
    {
        timer -= Time.deltaTime;
        textoTimer.text = "Tiempo: " + timer.ToString("f0");

    if(timer<=0)
    {
            
            if (SceneManager.GetActiveScene().name == "nivel1")
            {
                SceneManager.LoadScene("EscenaNivel1");
            }else if(SceneManager.GetActiveScene().name == "nivel2")
            {
            SceneManager.LoadScene("EscenaNivel2");
            }else if(SceneManager.GetActiveScene().name == "nivel3")
            {
            SceneManager.LoadScene("EscenaNivel3");
            }
        
    }

    }


}
