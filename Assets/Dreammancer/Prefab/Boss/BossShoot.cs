using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Dreammancer{
	public class BossShoot : MonoBehaviour {

		public GameObject sP1;
		public GameObject sP2;
		public GameObject sP3;
		public GameObject sP4;
		public GameObject board;
		public GameObject bullet;
		public float bulSpeed;
		public float boSpeed;
		private bool isBu;
		private bool buSho;
		private bool isBo;
		private bool boSho;
		private int boSt;
		private int R;
		Vector3 pos;
		public int boCount;
		public int buCount;
		//public List<GameObject> buList;
		public Queue buList;
		public Queue boList;
		public float transparent;
		private float m_Co;

		// Use this for initialization
		void Start () {
			isBu = false;
			isBo = false;
			boSt = 0;
			boCount = 0;
			buCount = 0;
			buList = new Queue ();
			boList = new Queue ();
			m_Co = 50f / 255f;
			//Debug.Log (m_Co);
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
				if(buCount <= 30){
					m_Bullet = Instantiate (bullet, sP2.transform.position, Quaternion.identity) as GameObject;
					//m_Bullet.transform.parent = this.transform;
					buCount++;
					m_Bullet.GetComponent<Rigidbody2D> ().velocity += Vector2.left * bulSpeed;
					RanNum = Random.Range(0,2);
					Rand = (int)RanNum;

					if (Rand == 0) {
						m_Bullet.GetComponent<SpriteRenderer> ().color = new Color(1,m_Co,m_Co,transparent);
					} else if (Rand == 2) {
						m_Bullet.GetComponent<SpriteRenderer> ().color = new Color(m_Co,1,m_Co,transparent);
					} else if (Rand == 1) {
						m_Bullet.GetComponent<SpriteRenderer> ().color = new Color(m_Co,m_Co,1,transparent);
					}
					//m_Bullet.GetComponent<SpriteRenderer>().color.a = 0.8f;
					//Debug.Log("Bullet Color:" + m_Bullet.GetComponent<SpriteRenderer>().color);
				}
				else{
					if(buList.Count!=0){
						m_Bullet = buList.Dequeue() as GameObject;
						m_Bullet.SetActive(true);
						m_Bullet.transform.position = new Vector3(sP2.transform.position.x,sP2.transform.position.y,sP2.transform.position.z);
						m_Bullet.GetComponent<Rigidbody2D> ().velocity += Vector2.left * bulSpeed;
						RanNum = Random.Range(0,2);
						Rand = (int)RanNum;
						if (Rand == 0) {
							m_Bullet.GetComponent<SpriteRenderer> ().color = new Color(1,m_Co,m_Co,transparent);
						} else if (Rand == 2) {
							m_Bullet.GetComponent<SpriteRenderer> ().color = new Color(m_Co,1,m_Co,transparent);
						} else if (Rand == 1) {
							m_Bullet.GetComponent<SpriteRenderer> ().color = new Color(m_Co,m_Co,1,transparent);
						}
					}
				}
				buSho = false;
			}
			else if (!isBo) {
				StartCoroutine ("shootBo");
				isBo = true;
			} 
			if (boSho) {
				if (boSt == 0) {
					RanNum = Random.Range (0, 6);
					R = (int)RanNum;
					boSt = 1;
					if (R == 0) {
						pos = new Vector3 (sP1.transform.position.x, sP1.transform.position.y, sP1.transform.position.z);
					} else if (R == 1) {
						pos = new Vector3 (sP1.transform.position.x, sP1.transform.position.y, sP1.transform.position.z);
					} else if (R == 2) {
						pos = new Vector3 (sP3.transform.position.x, sP3.transform.position.y, sP3.transform.position.z);
					} else if (R == 3) {
						pos = new Vector3 (sP3.transform.position.x, sP3.transform.position.y, sP3.transform.position.z);
					} else if (R == 4) {
						pos = new Vector3 (sP4.transform.position.x, sP4.transform.position.y, sP4.transform.position.z);
					} else if (R == 5) {
						pos = new Vector3 (sP4.transform.position.x, sP4.transform.position.y, sP4.transform.position.z);
					}
				} else if (boSt == 1) {
					boSt = 2;
					if (R == 2) {
						pos = new Vector3 (sP1.transform.position.x, sP1.transform.position.y, sP1.transform.position.z);
					} else if (R == 4) {
						pos = new Vector3 (sP1.transform.position.x, sP1.transform.position.y, sP1.transform.position.z);
					} else if (R == 0) {
						pos = new Vector3 (sP3.transform.position.x, sP3.transform.position.y, sP3.transform.position.z);
					} else if (R == 5) {
						pos = new Vector3 (sP3.transform.position.x, sP3.transform.position.y, sP3.transform.position.z);
					} else if (R == 1) {
						pos = new Vector3 (sP4.transform.position.x, sP4.transform.position.y, sP4.transform.position.z);
					} else if (R == 3) {
						pos = new Vector3 (sP4.transform.position.x, sP4.transform.position.y, sP4.transform.position.z);
					}
				} else if (boSt == 2) {
					boSt = 0;
					if (R == 3) {
						pos = new Vector3 (sP1.transform.position.x, sP1.transform.position.y, sP1.transform.position.z);
					} else if (R == 5) {
						pos = new Vector3 (sP1.transform.position.x, sP1.transform.position.y, sP1.transform.position.z);
					} else if (R == 1) {
						pos = new Vector3 (sP3.transform.position.x, sP3.transform.position.y, sP3.transform.position.z);
					} else if (R == 4) {
						pos = new Vector3 (sP3.transform.position.x, sP3.transform.position.y, sP3.transform.position.z);
					} else if (R == 0) {
						pos = new Vector3 (sP4.transform.position.x, sP4.transform.position.y, sP4.transform.position.z);
					} else if (R == 2) {
						pos = new Vector3 (sP4.transform.position.x, sP4.transform.position.y, sP4.transform.position.z);
					}
				}
				if (boCount <= 30) {
					m_Board = Instantiate (board, pos, Quaternion.identity) as GameObject;
					//m_Board.transform.parent = this.transform;
					boCount ++;
					//m_Board.SetActive(false);
					m_Board.GetComponent<Rigidbody2D> ().velocity += Vector2.left * boSpeed;
					RanNum = Random.Range (0, 2);
					Rand = (int)RanNum;
					if (Rand == 0) {
						m_Board.GetComponent<SpriteRenderer> ().color = new Color(1,m_Co,m_Co,transparent);
					} else if (Rand == 2) {
						m_Board.GetComponent<SpriteRenderer> ().color = new Color(m_Co,1,m_Co,transparent);
					} else if (Rand == 1) {
						m_Board.GetComponent<SpriteRenderer> ().color = new Color(m_Co,m_Co,1,transparent);
					}
				} else {
					if (boList.Count != 0) {
						m_Board = boList.Dequeue () as GameObject;
						m_Board.SetActive (true);
						m_Board.transform.position = pos;
						m_Board.GetComponent<Rigidbody2D> ().velocity += Vector2.left * boSpeed;
						RanNum = Random.Range (0, 2);
						Rand = (int)RanNum;
						if (Rand == 0) {
							m_Board.GetComponent<SpriteRenderer> ().color = new Color(1,m_Co,m_Co,transparent);
						} else if (Rand == 2) {
							m_Board.GetComponent<SpriteRenderer> ().color = new Color(m_Co,1,m_Co,transparent);
						} else if (Rand == 1) {
							m_Board.GetComponent<SpriteRenderer> ().color = new Color(m_Co,m_Co,1,transparent);
						}
					}
				}
				boSho = false;
			}
		}

		IEnumerator shootBu(){
			yield return new WaitForSeconds (2f);
			//Debug.Log ("In isBu");
			isBu = false;
			buSho = true;
		}

		IEnumerator shootBo(){
			yield return new WaitForSeconds (2f);
			//Debug.Log ("in IsBo");
			isBo = false;
			boSho = true;
		}

	}
}
