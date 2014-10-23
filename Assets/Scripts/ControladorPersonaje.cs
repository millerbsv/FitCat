using UnityEngine;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour {

	public float fuerzaSalto = 100f;

	public bool enSuelo = true;
	public Transform comprobadorSuelo;
	private float comprobadorRadio = 0.07f;
	public LayerMask mascaraSuelo;
	private bool dobleSalto = false;
	private Animator animator;
	private bool corriendo = false;
	public float velocidad = 1f;

	void Awake(){
		animator = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate(){
		if(corriendo) {
			rigidbody2D.velocity = new Vector2(velocidad, rigidbody2D.velocity.y);
		}
//		animator.SetFloat ("VelX", rigidbody2D.velocity.x);
		enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
		//animator.SetBool ("isGroended", enSuelo);
		if(enSuelo) {
			dobleSalto = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log("doblesalto aa "+dobleSalto);
			if(corriendo){
				Debug.Log ("doblesalto q= "+dobleSalto);
				Debug.Log ("en suelo q= "+enSuelo);
				if (enSuelo || !dobleSalto){
					Debug.Log ("salto = "+fuerzaSalto);
					audio.Play();
					rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, fuerzaSalto);
					rigidbody2D.AddForce(new Vector2(0,fuerzaSalto));
					if(!dobleSalto && !enSuelo){
						dobleSalto = true;
						Debug.Log ("doblesalto = "+dobleSalto);
						Debug.Log ("en suelo = "+enSuelo);

					}
				}
			}
			else{
				corriendo = true;
				//NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeEmpiezaACorrer");
			}
		}

	}
}
