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
                FireBullet();
				StartCoroutine (shoot());
				startShoot = false;
			}
		}

        void FireBullet()
        {
            float RanNum;
            int Rand;
            RanNum = Random.Range(0, 2);
            GameObject bullet = Instantiate(Bullet, shootP.transform.position + new Vector3(0, RanNum, 0), Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody2D>().velocity += Vector2.left * speed;
            RanNum = Random.Range(0, 3);
            Rand = (int)RanNum;

            if (Rand == 0)
            {
                bullet.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if (RanNum == 1)
            {
                bullet.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            else if (Rand == 2)
            {
                bullet.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }

		IEnumerator shoot(){
			yield return new WaitForSeconds (2);
			startShoot = true;
		}
	}
}
