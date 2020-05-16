using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 position;

	public Vector2 maxPos;
	public Vector2 minPos;

	//determines how far apart the camera and player are the whole time
	void Start()
	{

	}

	//brings the camera to the player ,with a distance of offset
	void LateUpdate()
	{
		position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

		//bonding the camera
		position.x = Mathf.Clamp(position.x, minPos.x, maxPos.x);
		position.y = Mathf.Clamp(position.y, minPos.y, maxPos.y);

		transform.position = position;
	}
}