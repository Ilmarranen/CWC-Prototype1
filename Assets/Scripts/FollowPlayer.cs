using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	public GameObject player;
	public Vector3 ñameraOffset;

	// Start is called before the first frame update
	void Start()
	{
		ñameraOffset = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
  
	}

	void LateUpdate()
	{
		//Offset camera behind the player by starting offset
		transform.position = player.transform.position + ñameraOffset; //new Vector3(0, 6, -9); 
	}
}
