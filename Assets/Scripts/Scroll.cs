using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public float velocidad = 1f;
	public bool IniciarEnMovimiento = false;
	private bool enMovimiento = false;
	private float tiempoInicio = 0f;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeEmpiezaACorrer");
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeHaMuerto");
		if (IniciarEnMovimiento) {
			PersonajeEmpiezaACorrer();
		}
	
	}

	void PersonajeHaMuerto(){
		enMovimiento = false;
	}

	void PersonajeEmpiezaACorrer(){
		enMovimiento = true;
		tiempoInicio = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (enMovimiento) {
				renderer.material.mainTextureOffset = new Vector2 (((Time.time - tiempoInicio) * velocidad) % 1, 0);
		}
	}
}
