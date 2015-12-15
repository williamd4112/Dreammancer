using UnityEngine;
using System.Collections;

namespace Dreammancer
{
	public class TurretShoot : MonoBehaviour {
		public GameObject Bullet;
		public GameObject shootP;
		public float speed;
		private bool startShoot;
		public int howFast;
		// Use this for initialization
		void Start () {
			startShoot = true;
		}
		
		// Update is called once per frame
		void Update () {
			if (startShoot) {
				StartCoroutine ("shoot");
				startShoot = false;
			}
		}

		IEnumerator shoot(){
			GameObject m_Bullet;
			float RanNum;
			int Rand;
			yield return new WaitForSeconds (2);
			RanNum = Random.Range (0, 2);
			m_Bullet = Instantiate (Bullet, shootP.transform.position + new Vector3 (0,RanNum,0),Quaternion.identity) as GameObject;
			Debug.Log ("istant");
			m_Bullet.GetComponent<Rigidbody2D> ().velocity += Vector2.left * speed;
			RanNum = Random.Range(0,3);
			Rand = (int)RanNum;
			if (Rand == 0) {
				m_Bullet.GetComponent<SpriteRenderer> ().color = Color.red;
			} else if (RanNum == 1) {
				m_Bullet.GetComponent<SpriteRenderer> ().color = Color.blue;
			} else if (Rand == 2) {
				m_Bullet.GetComponent<SpriteRenderer> ().color = Color.green;
			}
			Debug.Log (RanNum);
			//m_Bullet.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * speed);
			startShoot = true;
		}
	}
}
