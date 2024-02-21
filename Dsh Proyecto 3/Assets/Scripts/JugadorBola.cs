using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugadorbola : MonoBehaviour
{
    public Camera camara;
    public GameObject suelo;

    private Vector3 offSet;
    private float ValX,ValZ;
    private Vector3 DireccionActual;
    public float velocidad = 2;
    // Start is called before the first frame update
    void Start()
    {
        offSet = camara.transform.position;
        CrearSueloInicial();
        DireccionActual = Vector3.forward;
    }

    void CrearSueloInicial()
    {
    for(int i=0;i<3;i++)
    {
    ValZ+=6.0f;
    Instantiate(suelo,new Vector3(ValX,0,ValZ),Quaternion.identity);
    }
    }

    // Update is called once per frame
    void Update()
    {
        camara.transform.position = transform.position + offSet;
        if(Input.GetKeyUp(KeyCode.Space))
        {
            CambiarDireccion();
        }

        transform.Translate(DireccionActual* velocidad * Time.deltaTime);
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Suelo")
        {
            StartCoroutine(BorrarSuelo(other.gameObject));
        }
    }

    IEnumerator BorrarSuelo(GameObject suelo)
    {
        float aleatorio = Random.Range(0.0f,1.0f);
        if(aleatorio>0.5)
        {
            ValX+=6.0f;
        }else
        {
            ValZ+=6.0f;
        }
        
        Instantiate(suelo,new Vector3(ValX,0,ValZ),Quaternion.identity);
        yield return new WaitForSeconds(1);
        suelo.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        suelo.gameObject.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(1);
        Destroy(suelo);
    }

    void CambiarDireccion()
    {
        if(DireccionActual == Vector3.forward)
        {
            DireccionActual = Vector3.right;

        }else
        {
        DireccionActual = Vector3.forward;
        }
    }
}
