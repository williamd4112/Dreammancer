using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour {


	public GameObject Player;
	private Vector3 temp;
	// Use this for initialization
	void Start () {
		temp = new Vector3 (Player.transform.position.x, this.transform.position.y, this.transform.position.z);
		this.transform.position = temp;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		temp = new Vector3 (Player.transform.position.x, this.transform.position.y, this.transform.position.z);
		this.transform.position = temp;
	}
}
