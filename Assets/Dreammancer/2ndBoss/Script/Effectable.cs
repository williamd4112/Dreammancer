using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class Effectable : MonoBehaviour {

		public int motion = 0;


		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void AngerChange(int amount){
			motion += amount;
		}

		public void SadChange(int amount){
			motion -= amount;
		}
	}
}
