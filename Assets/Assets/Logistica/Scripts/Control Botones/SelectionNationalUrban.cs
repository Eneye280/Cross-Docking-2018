﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionNationalUrban : MonoBehaviour 
{
	[Tooltip("Gameobject[0] = enable cajas nacionales / Gameobject[1] = cajas urbanas")]
	public GameObject[] enableDesable;
	private void Start () 
	{
		enableDesable[0].SetActive(false);
		enableDesable[1].SetActive(false);
	}

	private void Update()
	{
		ControllerInput();
	}
	
	private void ControllerInput() 
	{
		#region Nacional
		if(Input.GetKey(KeyCode.A))
		{
			enableDesable[0].SetActive(true);
		}
		#endregion
		#region Urbano
		else if(Input.GetKey(KeyCode.D))
		{
			enableDesable[1].SetActive(true);
		}
		#endregion
	}
}
