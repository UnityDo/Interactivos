using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaInteractivo : MonoBehaviour {

	[SerializeField] private Transform camara;
	[SerializeField] private LayerMask ExclusionLayers;           // Layer excluidos del raycast por defecto ninguno
	[SerializeField] float distancia_rayo;
	[SerializeField] float duracion_rayo;
	public Interactivo objeto_interactivo;
	public GameObject objeto_hit;
	Interactivo interactivoActual;
	Interactivo interactivoUltimo;
	// Use this for initialization
	void Start () {
		

	}

	
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay(camara.position, camara.forward * distancia_rayo, Color.blue, duracion_rayo);
		Ray ray = new Ray(camara.position, camara.forward);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, distancia_rayo, ~ExclusionLayers)) {
			//VRInteractiveItem interactible = hit.collider.GetComponent<VRInteractiveItem>();

			objeto_interactivo= hit.collider.GetComponent<Interactivo>();

			interactivoActual = objeto_interactivo;



			objeto_hit = hit.collider.gameObject;
			if (objeto_interactivo&& objeto_interactivo != interactivoUltimo) {
				objeto_interactivo.Over();
			}
			if (objeto_interactivo != interactivoUltimo)
			{
				DesactivaInteractivo();
			}

			interactivoUltimo = objeto_interactivo;
			if (objeto_interactivo?.tipo == 1)
			{
				//print("tipo puerta");
			}
		} else {

			DesactivaInteractivo();
			interactivoActual = null;
		
			
		}

		

	}
	void DesactivaInteractivo()
	{
		if (interactivoUltimo == null)
			return;

		interactivoUltimo.Out();
		interactivoUltimo = null;
	}
}
