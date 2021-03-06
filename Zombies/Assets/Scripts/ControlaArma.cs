﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour {

    public GameObject Bala;
    public GameObject CanoDaArma;
	public RandomSound Audio;
	[SerializeField]
	private ObjectPool Pool;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		foreach (Touch touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began)
				Fire();
		}
	}
	void Fire()
	{
		GameObject gameObj = Pool.GetObjectFromPool();
		if (gameObj == null)
			return;
		gameObj.transform.position = CanoDaArma.transform.position;
		gameObj.transform.rotation = CanoDaArma.transform.rotation;
		gameObj.SetActive(true);
		Audio.Play();
	}
}
