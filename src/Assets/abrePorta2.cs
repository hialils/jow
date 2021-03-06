using UnityEngine;
using System.Collections;

public class abrePorta2 : MonoBehaviour {
	
	public GameObject porta;
	public float tremedor = 0;
	public GameObject MainCamera;
	private bool fechado = true;
	private bool movimento = false;
	private float subir = 0.001f;
	
	// Use this for initialization
	void Start () {
	
		MainCamera = GameObject.Find("Main Camera");
		porta = GameObject.Find("Porta2");
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(tremedor>0){
			MainCamera.transform.position = new Vector3(
				1.9f+Mathf.Sin(Random.Range(-1f,-1.2f)*Time.time),
				43.5201f+Mathf.Sin(Random.Range(-1f,-1.2f)*Time.time),
				-57.18781f);
			tremedor--;
		}
		
		if(movimento){
			Vector3 cima = new Vector3(0,subir,0);
			porta.transform.Translate(cima);
			subir += 0.01f;
			if(porta.transform.position.y > 34.04847f){
				movimento = false;
			}
		}
	
	}
	
	void OnTriggerEnter(Collider c){
		
		if(fechado){
			
			tremedor  = 50;
			porta.GetComponent<AudioSource>().Play();
			movimento = true;
			fechado= false;
		}
		
		
	}
	
	
}
