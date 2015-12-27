using UnityEngine;
using System.Collections;


namespace Dreammancer{
	public class ScrollScript : MonoBehaviour {


		public float speed = 0;
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			this.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time*speed,0f);
		}
	}
}
