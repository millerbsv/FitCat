using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class EstadoDelJuego : MonoBehaviour {

	public int puntuacionMaxima = 0;
	public static EstadoDelJuego estadoJuego;
	private String rutaArchivo;

	void Awake(){
		rutaArchivo = Application.persistentDataPath +"/datos.db";
		if (estadoJuego == null) {
				estadoJuego = this;
		} else if (estadoJuego != this) {
				DontDestroyOnLoad (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		Cargar ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Cargar(){
		if (File.Exists (rutaArchivo)) {
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream file = File.Open (rutaArchivo, FileMode.Open);
				DatosAGuardar datos = (DatosAGuardar)bf.Deserialize (file);
				file.Close ();
				puntuacionMaxima = datos.read ();
		} else {
			puntuacionMaxima = 0;
		}
	}
	public void Guardar(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create(rutaArchivo);
		DatosAGuardar datos = new DatosAGuardar (puntuacionMaxima);
		bf.Serialize (file, datos);
		file.Close();

	}
}

[Serializable]
class DatosAGuardar{
	public int puntuacionMaxima;

	public DatosAGuardar(int puntuacionMaxima){
		this.puntuacionMaxima = puntuacionMaxima;
	}
	public int read(){
		return this.puntuacionMaxima;
	}
}
