using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CuentaAtras : MonoBehaviour
{
    private Button boton;
    public Image imagen;
    public Sprite[] numeros;
    // Start is called before the first frame update
    void Start()
    {
            boton=GameObject.FindAnyObjectByType<Button>(); //encuentra el primer objeto boton
            //boton=GameObject.FindWithTag("botonSalir").GetComponent<Button>();
            boton.onClick.AddListener(Empezar);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    void Empezar(){
            imagen.gameObject.SetActive(true);
            boton.gameObject.SetActive(false);

            StartCoroutine(cuentaAtras());
    }
    IEnumerator cuentaAtras()
    {
        for (int i=0; i<numeros.Length;i++ )
        {
            imagen.sprite=numeros[i];
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene("Nivel1");
    }
}
