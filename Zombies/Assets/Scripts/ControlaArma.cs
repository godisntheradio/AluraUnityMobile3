using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour {

    public GameObject Bala;
    public GameObject CanoDaArma;
    public AudioClip SomDoTiro;
	[SerializeField]
	private ObjectPool Pool;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            //Instantiate(Bala, CanoDaArma.transform.position, CanoDaArma.transform.rotation);
			GameObject gameObj = Pool.GetObjectFromPool();
			if (gameObj == null)
				return;
			gameObj.transform.position = CanoDaArma.transform.position;
			gameObj.transform.rotation = CanoDaArma.transform.rotation;
			gameObj.SetActive(true);
			ControlaAudio.instancia.PlayOneShot(SomDoTiro);
        }
	}
}
