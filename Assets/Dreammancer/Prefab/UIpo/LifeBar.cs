using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class LifeBar : MonoBehaviour {


		GameObject RT;
		GameObject LB;
		Camera m_Cam;
		private Vector3 RTpos;
		private Vector3 LBpos;
		public _2dxFX_EnergyBar Progress;
		public float health;
		private Health m_heal;
		// Use this for initialization
		void Start () {
			RT = GameObject.Find ("RightTop");
			LB = GameObject.Find ("LeftBot");
			m_heal = GameObject.Find ("Player").GetComponent<Health>();
			Progress = this.gameObject.GetComponent<_2dxFX_EnergyBar> ();
			//Debug.Log (RT);
			//Debug.Log (LB);

		}
		
		// Update is called once per frame
		void Update () {

			RTpos = Camera.main.ScreenToWorldPoint (RT.GetComponent<RectTransform> ().position);
			LBpos = Camera.main.ScreenToWorldPoint (LB.GetComponent<RectTransform> ().position) + Vector3.right* 0.5f;
			this.transform.position = new Vector3 (LBpos.x, RTpos.y, this.transform.position.z);
			health = (float)m_heal.HealthPoint/100;
			Progress.BarProgress = health;
			//this.g
		}
	}
}
