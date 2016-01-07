using UnityEngine;
using System.Collections;

public class ScrollingFor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 bgTex = this.gameObject.GetComponent<SpriteRenderer>().material.mainTextureOffset;
		this.gameObject.GetComponent<SpriteRenderer>().material.mainTextureOffset = Vector2.Lerp(bgTex, bgTex + new Vector2 (1,0),1 * Time.deltaTime);
	}
}
