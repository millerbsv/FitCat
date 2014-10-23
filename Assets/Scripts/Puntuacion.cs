using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {
	public int puntuacion = 0;
	public TextMesh marcador;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "IncrementarPuntos");
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeHaMuerto");
		ActulizarMarcador ();	
	}

	void PersonajeHaMuerto(Notification notificacion){
		if (puntuacion > EstadoDelJuego.estadoJuego.puntuacionMaxima) {
				Debug.Log ("Puntuacion maxima superada, Maxima " + EstadoDelJuego.estadoJuego.puntuacionMaxima + " actual " + puntuacion);
				EstadoDelJuego.estadoJuego.puntuacionMaxima = puntuacion;
				EstadoDelJuego.estadoJuego.Guardar ();
				
		} else {
			Debug.Log("Puntuacion maxima no superada, Maxima "+EstadoDelJuego.estadoJuego.puntuacionMaxima+" actual "+puntuacion);
		}
	}

	void IncrementarPuntos(Notification notificacion){
		int puntosAIncrementar = (int)notificacion.data;
		puntuacion += puntosAIncrementar;
		ActulizarMarcador ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ActulizarMarcador(){
		marcador.text = puntuacion.ToString ();
	}
}
