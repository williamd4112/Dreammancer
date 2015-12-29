using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class DeathRay : MonoBehaviour {

		public GameObject DeathR;
		public GameObject RayPoint;
		public int rotateSp = 50;
		public int lightRad = 100;
		public int lightCo = 60;
		private bool isRay;
		private bool shootR;
		private bool isFirst;
		private bool isRe;
		//public GameObject m_DeathR;
		private Animator m_animator;
		// Use this for initialization
		void Start () {
			isRay = false;
			shootR = false;
			//isFirst = true;
			isRe = false;
			m_animator = this.GetComponent<Animator> ();
			DeathR.SetActive (false);
		}
		
		// Update is called once per frame
		void Update () {
			float RanNum;
			int Rand;
			Light2D[] sr;
			if (!isRay && (!this.GetComponent<BossState>().isDead)) {
				StartCoroutine ("GenDeath");
				isRay = true;
			}
			if (shootR) {
				StartCoroutine ("RayCount");
				//Debug.Log("First Time");
				/*if(isFirst){
					m_DeathR = Instantiate (DeathR, RayPoint.transform.position, Quaternion.identity) as GameObject;
					m_DeathR.transform.parent = this.gameObject.transform;
					isFirst = false;
					sr = GetComponentsInChildren<Light2D>();
					foreach(Light2D temp in sr){
						temp.LightConeAngle = lightCo;
						temp.LightRadius = lightRad;
						temp.gameObject.GetComponent<Rotate_VLS>().speed = rotateSp;
					}
				}
				else{*/
				DeathR.SetActive(true);
				//}
				//m_DeathR.SetActive (true);
				RanNum = Random.Range(0,3);
				Rand = (int)RanNum;
				sr = GetComponentsInChildren<Light2D>();
				foreach(Light2D tep in sr){
					if(Rand == 0){
						tep.LightColor = Color.red;
					} else if(Rand == 1){
						tep.LightColor = Color.green;
					} else if(Rand == 2){
						tep.LightColor = Color.blue;
					}
				}
				m_animator.SetBool("Attack",true);
				this.GetComponent<BossSound>().PlayRay();
				//m_animator.SetBool ("Idle",false);
				shootR = false;
			}
			if (isRe) {
				m_animator.SetBool("Attack",false);
				DeathR.SetActive(false);
				isRay = false;
				isRe = false;
			}
		}

		IEnumerator GenDeath(){
			yield return new WaitForSeconds (10);
			shootR = true;
		}

		IEnumerator RayCount(){
			yield return new WaitForSeconds (5);
			isRe = true;
		}
	}
}
