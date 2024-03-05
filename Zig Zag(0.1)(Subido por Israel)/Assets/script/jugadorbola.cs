using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugadorbola : MonoBehaviour
{   
    public Camera camara;
    public float velocidad=4.0f;
    public GameObject suelo;
    public GameObject moneda;
    private Vector3 offset;
    private float ValX,ValZ;
    private int n_suelo=0;
    private Vector3 DireccionActual;
    private bool izq=true;   // Start is called before the first frame update
    private AudioSource audioSource;
    void Start()
    {
        offset= camara.transform.position;
        CrearSueloInicial();
        DireccionActual=Vector3.forward;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        camara.transform.position=transform.position + offset;
        if(Input.GetKey(KeyCode.UpArrow))
        {
            DireccionActual=Vector3.forward;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            DireccionActual=Vector3.right;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            DireccionActual=Vector3.left;
        }
        transform.Translate(DireccionActual * velocidad * Time.deltaTime);
    }

    private void OnCollisionExit(Collision other){
        if(other.gameObject.tag=="Suelo" && n_suelo<7){
            StartCoroutine(BorrarSuelo(other.gameObject));
        }
    }
    void OnTriggerEnter(Collider other){        //colisiona con la moneda
        if(other.gameObject.CompareTag("moneda")){
            audioSource.Play();
        }
    }
    void CrearSueloInicial(){
        for(int i=0;i<3;i++){
            ValZ+=6.0f;
            Instantiate(suelo,new Vector3(ValX,0,ValZ),Quaternion.identity);
        }
    }
    IEnumerator BorrarSuelo(GameObject suelo){
        float aleatorio= Random.Range(0.0f,1.0f);
                    if(aleatorio>0.66){
                        if(izq == true ){ 
                            ValX-=6.0f;
                        }
                        else{
                            ValX+=6.0f;
                            izq = false;
                        }
                    }
                    else{
                        ValZ+=6.0f;
                        float aleatorio2= Random.Range(0.0f,1.0f);
                        if(aleatorio2<0.5){
                            izq=false;
                        }
                        else{
                            izq=true;
                        }
                    }
    

        Instantiate(suelo,new Vector3(ValX,0,ValZ),Quaternion.identity);
        Instantiate(moneda,new Vector3(ValX,1,ValZ),Quaternion.identity);  //crea objeto moneda
        n_suelo++;
        yield return new WaitForSeconds(1); // Espera 1 segundo
        suelo.gameObject.GetComponent<Rigidbody>().isKinematic=false;
        suelo.gameObject.GetComponent<Rigidbody>().useGravity=true;
        yield return new WaitForSeconds(2); // Espera 1 segundo
        Destroy(suelo);
        n_suelo--;
    }
}
