using UnityEngine;
using System.Collections;


namespace Dreammancer{
	public class EnergyBar : MonoBehaviour {
		GameObject RT;
		GameObject LB;
		Camera m_Cam;
		private Vector3 RTpos;
		private Vector3 LBpos;
		public _2dxFX_EnergyBar Progress;
		private DreammancerCharacter m_DC;
		public float energy;


		// Use this for initialization
		void Start () {
			RT = GameObject.Find ("RightTop");
			LB = GameObject.Find ("LeftBot");
			Progress = this.gameObject.GetComponent<_2dxFX_EnergyBar> ();
			m_DC = GameObject.Find ("Player").GetComponent<DreammancerCharacter> ();
		}
		
		// Update is called once per frame
		void Update () {
			RTpos = Camera.main.ScreenToWorldPoint (RT.GetComponent<RectTransform> ().position);
			//LBpos = Camera.main.ScreenToWorldPoint (LB.GetComponent<RectTransform> ().position);
			this.transform.position = new Vector3 (RTpos.x-0.5f, RTpos.y, this.transform.position.z);
			energy = (float)m_DC.DashEnergy / 100f;
			Progress.BarProgress = energy;
		}
	}
}