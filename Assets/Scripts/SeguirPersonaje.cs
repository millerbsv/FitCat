using UnityEngine;
using System.Collections;

public class SeguirPersonaje : MonoBehaviour {

	public float separacion = 7f;
	public Transform personaje;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (personaje.position.x+separacion, transform.position.y, transform.position.z); 	
	}
}
