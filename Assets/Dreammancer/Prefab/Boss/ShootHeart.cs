using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class ShootHeart : MonoBehaviour {

		public GameObject HeartPo;
		public bool heartExi;
		public bool makeHeart;
		public GameObject Heart;
		private GameObject m_heart;
		private SpriteRenderer h_sr;
		public bool startBuild;
		private LaserLightEventListener llel;
		// Use this for initialization
		void Start () {
			heartExi = false;
			startBuild = true;
			//m_heart = GameObject.Find ("Heart");
			//m_heart.SetActive (false);
		}
		
		// Update is called once per frame
		void Update () {
			float RanNum;
			int Rand;
			if (!heartExi) {
				if (startBuild) {
					StartCoroutine ("buildHeart");
					//heartExi = true;
					startBuild = false;
				}

				if (makeHeart) {
					m_heart = Instantiate(Heart,HeartPo.transform.position,Quaternion.identity) as GameObject;
					m_heart.transform.localScale = m_heart.transform.localScale * 2;
					m_heart.transform.parent = this.gameObject.transform;
					RanNum = Random.Range (0, 2);
					Rand = (int)RanNum;
					h_sr = m_heart.GetComponent<SpriteRenderer> ();
					llel = m_heart.GetComponent<LaserLightEventListener>();
					if (Rand == 0){
						h_sr.color = Color.red;
						llel.ChangeDamageColor(Color.red);
					}
					else if (Rand == 1){
						h_sr.color = Color.blue;
						llel.ChangeDamageColor(Color.blue);
					}
					//else if (Rand == 2)
						//h_sr.color = Color.blue;
					heartExi = true;
					makeHeart = false;
				}
			}

		}

		IEnumerator buildHeart(){
			yield return new WaitForSeconds (15);
			makeHeart = true;
		}

	}
}
