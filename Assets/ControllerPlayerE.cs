using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ControllerPlayerE : NetworkBehaviour 
{
	[SerializeField] private float speedPlayer;

	private void Update () 
	{
		if(!isLocalPlayer)
		{
			return;
		}
		var horizontal = Input.GetAxis("Horizontal");
		var vertical = Input.GetAxis("Vertical");

		transform.Translate(0,0,vertical * speedPlayer * Time.deltaTime);
		transform.Rotate(0,horizontal,0);
	}

	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.red;
	}
}
