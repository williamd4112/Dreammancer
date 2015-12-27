using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class BossShoot : MonoBehaviour {

		public GameObject sP1;
		public GameObject sP2;
		public GameObject sP3;
		public GameObject sP4;
		public GameObject board;
		public GameObject bullet;
		public int bulSpeed;
		public int boSpeed;
		private bool isBu;
		private bool buSho;
		private bool isBo;
		private bool boSho;
		private int boSt;
		private int R;
		Vector3 pos;

		// Use this for initialization
		void Start () {
			isBu = false;
			isBo = false;
			boSt = 0;
		}
		
		// Update is called once per frame
		void Update () {
			GameObject m_Bullet;
			float RanNum;
			int Rand;
			GameObject m_Board;
			//Debug.Log ("isBu:" + isBu);
			//Debug.Log ("isBo:" + isBo);
			if (!isBu) {
				StartCoroutine ("shootBu");
				isBu = true;
			} 	
			if (buSho) {
				m_Bullet = Instantiate (bullet, sP2.transform.position, Quaternion.identity) as GameObject;
				m_Bullet.GetComponent<Rigidbody2D> ().velocity += Vector2.left * bulSpeed;
				RanNum = Random.Range(0,3);
				Rand = (int)RanNum;
				if (Rand == 0) {
					m_Bullet.GetComponent<SpriteRenderer> ().color = Color.red;
				} else if (Rand == 1) {
					m_Bullet.GetComponent<SpriteRenderer> ().color = Color.blue;
				} else if (Rand == 2) {
					m_Bullet.GetComponent<SpriteRenderer> ().color = Color.green;
				}
				buSho = false;
			}
			else if (!isBo) {
				StartCoroutine ("shootBo");
				isBo = true;
			} 
			if (boSho) {
				if(boSt == 0){
					RanNum = Random.Range(0, 6);
					R = (int)RanNum;
					boSt = 1;
					if(R == 0){
						pos = new Vector3(sP1.transform.position.x,sP1.transform.position.y,sP1.transform.position.z);
					}
					else if(R == 1){
						pos = new Vector3(sP1.transform.position.x,sP1.transform.position.y,sP1.transform.position.z);
					}
					else if(R == 2){
						pos = new Vector3(sP3.transform.position.x,sP3.transform.position.y,sP3.transform.position.z);
					}
					else if(R == 3){
						pos = new Vector3(sP3.transform.position.x,sP3.transform.position.y,sP3.transform.position.z);
					}
					else if(R == 4){
						pos = new Vector3(sP4.transform.position.x,sP4.transform.position.y,sP4.transform.position.z);
					}
					else if(R == 5){
						pos = new Vector3(sP4.transform.position.x,sP4.transform.position.y,sP4.transform.position.z);
					}
				}
				else if(boSt == 1){
					boSt = 2;
					if(R == 2){
						pos = new Vector3(sP1.transform.position.x,sP1.transform.position.y,sP1.transform.position.z);
					}
					else if(R == 4){
						pos = new Vector3(sP1.transform.position.x,sP1.transform.position.y,sP1.transform.position.z);
					}
					else if(R == 0){
						pos = new Vector3(sP3.transform.position.x,sP3.transform.position.y,sP3.transform.position.z);
					}
					else if(R == 5){
						pos = new Vector3(sP3.transform.position.x,sP3.transform.position.y,sP3.transform.position.z);
					}
					else if(R == 1){
						pos = new Vector3(sP4.transform.position.x,sP4.transform.position.y,sP4.transform.position.z);
					}
					else if(R == 3){
						pos = new Vector3(sP4.transform.position.x,sP4.transform.position.y,sP4.transform.position.z);
					}
				}
				else if(boSt == 2){
					boSt = 0;
					if(R == 3){
						pos = new Vector3(sP1.transform.position.x,sP1.transform.position.y,sP1.transform.position.z);
					}
					else if(R == 5){
						pos = new Vector3(sP1.transform.position.x,sP1.transform.position.y,sP1.transform.position.z);
					}
					else if(R == 1){
						pos = new Vector3(sP3.transform.position.x,sP3.transform.position.y,sP3.transform.position.z);
					}
					else if(R == 4){
						pos = new Vector3(sP3.transform.position.x,sP3.transform.position.y,sP3.transform.position.z);
					}
					else if(R == 0){
						pos = new Vector3(sP4.transform.position.x,sP4.transform.position.y,sP4.transform.position.z);
					}
					else if(R == 2){
						pos = new Vector3(sP4.transform.position.x,sP4.transform.position.y,sP4.transform.position.z);
					}
				}
				m_Board = Instantiate (board, pos, Quaternion.identity) as GameObject;
				m_Board.SetActive(false);
				m_Board.GetComponent<Rigidbody2D>().velocity += Vector2.left * boSpeed;
				RanNum = Random.Range (0, 3);
				Rand = (int)RanNum;
				if (Rand == 0) {
					m_Board.GetComponent<SpriteRenderer> ().color = Color.red;
				} else if (Rand == 1) {
					m_Board.GetComponent<SpriteRenderer> ().color = Color.blue;
				} else if (Rand == 2) {
					m_Board.GetComponent<SpriteRenderer> ().color = Color.green;
				}
				boSho = false;
			}
		}

		IEnumerator shootBu(){
			yield return new WaitForSeconds (0.5f);
			//Debug.Log ("In isBu");
			isBu = false;
			buSho = true;
		}

		IEnumerator shootBo(){
			yield return new WaitForSeconds (1);
			//Debug.Log ("in IsBo");
			isBo = false;
			boSho = true;
		}

	}
}
