using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	public GameObject player;
	[SerializeField]  public Vector3 ˝ameraOffset;

	// Start is called before the first frame update
	void Start()
	{
		˝ameraOffset = transform.position;
	}

	void LateUpdate()
	{
		//Offset camera behind the player by starting offset
		transform.position = player.transform.position + ˝ameraOffset; //new Vector3(0, 6, -9); 
	}
}
