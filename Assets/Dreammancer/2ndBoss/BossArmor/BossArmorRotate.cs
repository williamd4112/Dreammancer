using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class BossArmorRotate : MonoBehaviour {

		private Transform m_Trans;
		[SerializeField]
		private int RotateSpeed = 60;
		// Use this for initialization
		void Start () {
			m_Trans = this.GetComponent<Transform> ();
		}
		
		// Update is called once per frame
		void Update () {
			m_Trans.RotateAround (m_Trans.position, Vector3.forward, RotateSpeed * Time.deltaTime);
		}
	}
}