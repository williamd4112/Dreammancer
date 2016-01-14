using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class BodyGetSound : MonoBehaviour {
		[SerializeField]
		private SecBossSound m_SBS;
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		public void PlayTransport(){
			m_SBS.PlayTransport ();
		}
	}
}
