using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	//determines how far apart the camera and player are the whole time
	void Start()
	{
		offset = transform.position - player.transform.position;
	}

	//brings the camera to the player ,with a distance of offset
	void LateUpdate()
	{
		transform.position = player.transform.position + offset;
	}
}