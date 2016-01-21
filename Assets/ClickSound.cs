using UnityEngine;
using System.Collections;

public class ClickSound : MonoBehaviour {

	[SerializeField]
	private AudioClip clip;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayClip()
	{
		AudioSource.PlayClipAtPoint (clip, transform.position);
	}
}
