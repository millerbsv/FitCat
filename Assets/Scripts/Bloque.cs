using UnityEngine;
using System.Collections;

public class Bloque : MonoBehaviour {

	private bool haColisionadoConElJugador = false;
	public int puntosGanados = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D colision){
		if (!haColisionadoConElJugador) {
			haColisionadoConElJugador = true;
			Debug.Log(colision.contacts[0].collider.gameObject.name);
			if(colision.contacts[0].collider.gameObject.name == "PataInferiorIzquierdaB" || colision.contacts[0].collider.gameObject.name == "PataInferiorDerechaB"){
				NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", puntosGanados);
			}
			
		}

	}
}
