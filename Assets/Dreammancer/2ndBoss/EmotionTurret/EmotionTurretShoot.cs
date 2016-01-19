using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class EmotionTurretShoot : MonoBehaviour {

		[SerializeField]
		private GameObject AngerUp;
		[SerializeField]
		private GameObject SadUp;
		[SerializeField]
		private GameObject shootP;
		[SerializeField]
		private float Force;

		private bool startShoot;
		[SerializeField]
		private int EmotionNum = 10;
		public Queue AnQueue;
		public Queue SaQueue;
		[SerializeField]
		private int AnNum;
		[SerializeField]
		private int SaNum;
        [SerializeField]
        private AudioClip shootSound;

        private GameObject player;
		// Use this for initialization
		void Start () {
            player = GameObject.Find("Player");
			GameObject An;
			GameObject Sa;
			AnQueue = new Queue ();
			SaQueue = new Queue ();
			startShoot = true;
			for (int i = 0; i<EmotionNum; i++) {
				An = Instantiate (AngerUp, Vector2.zero, Quaternion.identity) as GameObject;
				//An.transform.parent = this.gameObject.transform;
				An.GetComponent <EmotionBullet>().m_EmotionTurret = this.gameObject;
				AnQueue.Enqueue (An);
				An.SetActive (false);

				Sa = Instantiate (SadUp, Vector2.zero, Quaternion.identity) as GameObject;
				//Sa.transform.parent = this.gameObject.transform;
				Sa.GetComponent <EmotionBullet>().m_EmotionTurret = this.gameObject;
				SaQueue.Enqueue (Sa);
				Sa.SetActive (false);

				Debug.Log(AnQueue.Count);

			}
		}
		
		// Update is called once per frame
		void Update () {
			//Debug.Log(AnQueue.Count);
			AnNum = AnQueue.Count;
			SaNum = SaQueue.Count;
            if (startShoot) {
				FireBullet();
//				GameObject temp;
//				Vector2 shootPos = new Vector2 (shootP.transform.position.x, shootP.transform.position.y);
//				temp = AnQueue.Dequeue () as GameObject;
//				temp.SetActive (true);
//				temp.transform.position = shootPos;
//				//temp.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * Force);
//				temp.GetComponent<Rigidbody2D> ().velocity =  Vector2.left * Force;

				StartCoroutine (shoot());
				startShoot = false;
			}

		}
		
		void FireBullet()
		{
			float RanNum;
			GameObject temp = null;
			Vector2 shootPos = new Vector2 (shootP.transform.position.x, shootP.transform.position.y);
			RanNum = Random.Range (0, 2);
			if (RanNum < 1) {
				if (AnQueue.Count != 0) {
					temp = AnQueue.Dequeue () as GameObject;
					temp.SetActive (true);
					temp.transform.position = shootPos;
					temp.GetComponent<Rigidbody2D> ().AddForce (this.transform.right * -1 * Force);
					//temp.GetComponent<Rigidbody2D> ().velocity =  Vector2.left * Force;
				} else {
					temp = SaQueue.Dequeue () as GameObject;
					temp.SetActive (true);
					temp.transform.position = shootPos;
					temp.GetComponent<Rigidbody2D> ().AddForce (this.transform.right * -1 * Force);
					//temp.GetComponent<Rigidbody2D> ().velocity =  Vector2.left * Force;
				}
			}
			else if(RanNum>=1){
				if (SaQueue.Count != 0) {
					temp = SaQueue.Dequeue () as GameObject;
					temp.SetActive (true);
					temp.transform.position = shootPos;
					temp.GetComponent<Rigidbody2D> ().AddForce (this.transform.right * -1 * Force);
					//temp.GetComponent<Rigidbody2D> ().velocity =  Vector2.left * Force;
				} else {
					temp = AnQueue.Dequeue () as GameObject;
					temp.SetActive (true);
					temp.transform.position = shootPos;
					temp.GetComponent<Rigidbody2D> ().AddForce (this.transform.right * -1 * Force);
					//temp.GetComponent<Rigidbody2D> ().velocity =  Vector2.left * Force;
				}
			}
            AudioSource.PlayClipAtPoint(shootSound, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z));
		}
		
		IEnumerator shoot(){
			yield return new WaitForSeconds (5);
			startShoot = true;
		}
	}
}
