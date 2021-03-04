using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta_Interactiva : MonoBehaviour {
	[SerializeField] private Interactivo interactivo; 
	AudioSource sonido;
	public bool abierto=false;
	Animator animator;
	public bool mira_puerta=false;
	public AudioClip abre_sonido;
	public AudioClip cierra_sonido;
	public AudioClip sonido_nofunciona;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		gameObject.AddComponent<AudioSource> ();
		sonido= GetComponent<AudioSource> ();
	}
	private void OnEnable()
	{
		interactivo.OnOver += Encima;
		interactivo.OnOut += Sale;
	}

	private void OnDisable()
	{
		interactivo.OnOver -= Encima;
		interactivo.OnOut -= Sale;
	}
	// Update is called once per frame
	void Update () {
		if (mira_puerta && Input.GetKeyDown (KeyCode.Space)) {
			if (!abierto) {

				animator.SetTrigger ("abre");
				sonido.clip = abre_sonido;


			} else {
				animator.SetTrigger ("cierra");
				sonido.clip = cierra_sonido;

			}
			if (!sonido.isPlaying) {
				sonido.Play ();
			}
			abierto = !abierto;
		}
	}
	public void Encima()
	{
		GameManager.instancia.IconoUsa();
		mira_puerta = true;
	}
	public void Sale()
	{
		GameManager.instancia.IconoNormal();
		mira_puerta = false;
	}
}
