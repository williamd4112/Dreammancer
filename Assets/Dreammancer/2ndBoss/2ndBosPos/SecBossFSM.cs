using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public enum Bstate
	{
		Idle,
		Attack1,
		Attack2,
		Attack3,
		Attack4
	} //Attack1: V move, Attack2: Vertical Beam, Attack3: Horizontal Beam(face right), Attack4:Horizontal Beam(face left)

	public class SecBossFSM : MonoBehaviour {
		[SerializeField]
		private Bstate m_BossState;
		[SerializeField]
		private GameObject m_BossBody;
		private Animator Body_Ani;
		[SerializeField]
		private GameObject m_Boss;
		[SerializeField]
		private GameObject m_BossRay;
		[SerializeField]
		private bool onlyOnce;
		[SerializeField]
		private float attackFreq = 1f;
		[SerializeField]
		private float[] attackLength = new float[3]; 
		private float attackSec;
		private bool isIdle = true;
		private bool isVerticalBeam = false;
		private bool isHorizontalBeamR = false;
		private bool isHorizontalBeamL = false;
		private Transform m_Transform;
		private Transform p_Trasnform;
		private Vector3 updatedPos;
		private SecBossSound m_SBS;
		private SpriteRenderer BossSprite;
		private Color BossColor;
		//private float attackLastSec;
		// Use this for initialization
		void Start () {
			m_BossState = Bstate.Idle;
			m_BossBody = GameObject.Find ("2ndBossBodyCtrl");
			Body_Ani = m_BossBody.GetComponent<Animator> ();
			//m_Boss = GameObject.Find ("UFO_Body");
			m_SBS = m_Boss.GetComponent<SecBossSound> ();
			Debug.Log (m_SBS.gameObject.name);
			//m_BossRay = GameObject.Find ("BossRay");
			m_BossRay.SetActive (false);
			m_Transform = this.gameObject.GetComponent<Transform> ();
			p_Trasnform = GameObject.Find ("Player").GetComponent<Transform> ();
			BossSprite = m_Boss.GetComponent<SpriteRenderer> ();
			onlyOnce = true;
		}

		// Update is called once per frame
		void FixedUpdate () {
			BossColor = new Color (BossSprite.color.r, BossSprite.color.g, BossSprite.color.b);
			if(onlyOnce){
				onlyOnce = false;

				if (m_BossState == Bstate.Idle) {
					updatedPos = new Vector2(p_Trasnform.transform.position.x,p_Trasnform.transform.position.y + 2.5f);
					this.gameObject.GetComponent<Transform>().position = updatedPos;
					attackSec = Random.Range (1f, attackFreq);
					StartCoroutine ("chooseAttack");
					isIdle = true;
				}
				else if(m_BossState == Bstate.Attack1){
					Body_Ani.SetBool("Attack1",true);
					StartCoroutine("FinishAttack1");
				}
				else if(m_BossState == Bstate.Attack2){
					isIdle = false;
					//Body_Ani.SetTrigger("Attack2");
					//m_SBS.PlayTransport();
					m_Boss.GetComponent<SpriteRenderer>().color = new Color (BossColor.r,BossColor.g,BossColor.b,0);
					isVerticalBeam = true;
					m_SBS.PlayTransport();
					StartCoroutine("ReadyToShoot");
//					m_BossRay.SetActive(true);
//					m_BossRay.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0f,0f,270f));
//					StartCoroutine("FinishAttack2");
					//StartCoroutine("ShootTheRay");
					//m_SBS.PlayReadyToShoot();
				}
				else if(m_BossState == Bstate.Attack3){
					isIdle = false;
					//Body_Ani.SetTrigger("Attack2");
					m_Boss.GetComponent<SpriteRenderer>().color = new Color (BossColor.r,BossColor.g,BossColor.b,0);
					//m_SBS.PlayTransport();
					isHorizontalBeamR = true;
					m_SBS.PlayTransport();
					StartCoroutine("ReadyToShoot");
//					m_BossRay.SetActive(true);
//					m_BossRay.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0,0,0));
//					StartCoroutine("FinishAttack3");
					//StartCoroutine("ShootTheRay");
					//m_SBS.PlayReadyToShoot();
				}
				else if(m_BossState == Bstate.Attack4){
					isIdle = false;
					//Body_Ani.SetTrigger("Attack2");
					//m_SBS.PlayTransport();
					m_Boss.GetComponent<SpriteRenderer>().color = new Color (BossColor.r,BossColor.g,BossColor.b,0);
					isHorizontalBeamR = true;
					m_SBS.PlayTransport();
					StartCoroutine("ReadyToShoot");
//					m_BossRay.SetActive(true);
//					m_BossRay.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0,0,180f));
//					StartCoroutine("FinishAttack3");
					//StartCoroutine("ShootTheRay");
					//m_SBS.PlayReadyToShoot();
				}
				//Debug.Log("Set Pos:" + updatedPos);
			}
			if (m_BossState == Bstate.Idle || m_BossState == Bstate.Attack1) {
				updatedPos = new Vector2 (Mathf.Lerp (this.transform.position.x, p_Trasnform.position.x, 0.02f), this.transform.position.y);
				this.gameObject.GetComponent<Transform> ().position = updatedPos;
			} else if (m_BossState == Bstate.Attack2) {
				updatedPos = new Vector2 (Mathf.Lerp (this.transform.position.x, p_Trasnform.position.x, 0.02f), this.transform.position.y);
				this.gameObject.GetComponent<Transform> ().position = updatedPos;
			} else if (m_BossState == Bstate.Attack3) {
				updatedPos = new Vector2 (this.transform.position.x, Mathf.Lerp (this.transform.position.y, p_Trasnform.position.y, 0.02f));
				this.gameObject.GetComponent<Transform> ().position = updatedPos;
			} else if (m_BossState == Bstate.Attack4) {
				updatedPos = new Vector2 (this.transform.position.x, Mathf.Lerp (this.transform.position.y, p_Trasnform.position.y, 0.02f));
				this.gameObject.GetComponent<Transform> ().position = updatedPos;
			}
			//Debug.Log ("Follow Pos:" + updatedPos);
		}

		IEnumerator chooseAttack(){
			yield return new WaitForSeconds (attackSec);
			float whichAct;
			whichAct = Random.Range (0, 4);
			Debug.Log ("The Attack Choice is:" + whichAct);
			if (whichAct < 1) {
				m_BossState = Bstate.Attack1;
			} else if (whichAct >= 1 && whichAct < 2) {
				m_BossState = Bstate.Attack2;
			} else if (whichAct >= 2 && whichAct < 3) {
				m_BossState = Bstate.Attack3;
			} else if (whichAct >= 3) {
				m_BossState = Bstate.Attack4;
			}
			onlyOnce = true;
		}

		IEnumerator FinishAttack1(){
			yield return new WaitForSeconds (attackLength [0]);
			Debug.Log ("Attack1 is done");
			Body_Ani.SetBool ("Attack1", false);
			m_BossState = Bstate.Idle;
			onlyOnce = true;
		}

		IEnumerator FinishAttack2(){
			yield return new WaitForSeconds (attackLength [1]);
			m_SBS.Pause ();
			Body_Ani.SetTrigger ("Attack2");
			Debug.Log ("Attack2 is done");
			m_BossState = Bstate.Idle;
			updatedPos = new Vector3(p_Trasnform.transform.position.x,p_Trasnform.transform.position.y + 2f);
			this.gameObject.GetComponent<Transform>().position = updatedPos;
			m_BossRay.SetActive (false);
			isIdle = true;
			isVerticalBeam = false;
			onlyOnce = true;
		}

		IEnumerator FinishAttack3(){
			yield return new WaitForSeconds (attackLength [2]);
			m_SBS.Pause ();
			Debug.Log ("Attack3 or 4 is done");
			Body_Ani.SetTrigger ("Attack2");
			m_BossState = Bstate.Idle;
			updatedPos = new Vector3 (p_Trasnform.transform.position.x, p_Trasnform.transform.position.y + 2f);
			this.gameObject.GetComponent<Transform> ().position = updatedPos;
			m_BossRay.SetActive (false);
			isIdle = true;
			isHorizontalBeamR = false;
			onlyOnce = true;
		}

		IEnumerator ShootTheRay(){
			yield return new WaitForSeconds (1.5f);
			m_SBS.PlayReadyToShoot();
			m_SBS.PlayRay ();
			m_BossRay.SetActive (true);
			if (m_BossState == Bstate.Attack2) {
				m_BossRay.GetComponent<Transform> ().rotation = Quaternion.Euler (new Vector3 (0f, 0f, 270f));
				StartCoroutine ("FinishAttack2");
			} else if (m_BossState == Bstate.Attack3) {
				m_BossRay.GetComponent<Transform> ().rotation = Quaternion.Euler (new Vector3 (0, 0, 0));
				StartCoroutine ("FinishAttack3");
			} else if (m_BossState == Bstate.Attack4) {
				m_BossRay.GetComponent<Transform> ().rotation = Quaternion.Euler (new Vector3 (0, 0, 180f));
				StartCoroutine ("FinishAttack3");
			}
		}

		IEnumerator ReadyToShoot(){
			yield return new WaitForSeconds(1f);
			if (m_BossState == Bstate.Attack2) {
				updatedPos = new Vector2 (p_Trasnform.transform.position.x, p_Trasnform.transform.position.y + 1.5f);
				this.gameObject.GetComponent<Transform> ().position = updatedPos;
			} else if (m_BossState == Bstate.Attack3) {
				updatedPos = new Vector2 (p_Trasnform.position.x - 2f, p_Trasnform.position.y);
				this.gameObject.GetComponent<Transform> ().position = updatedPos;
			} else if (m_BossState == Bstate.Attack4) {
				updatedPos = new Vector2 (p_Trasnform.position.x + 2f, p_Trasnform.position.y);
				this.gameObject.GetComponent<Transform> ().position = updatedPos;
			}
			m_Boss.GetComponent<SpriteRenderer> ().color = new Color (m_Boss.GetComponent<SpriteRenderer> ().color.r, m_Boss.GetComponent<SpriteRenderer> ().color.g, m_Boss.GetComponent<SpriteRenderer> ().color.b, 1);
			StartCoroutine ("ShootTheRay");
		}


	}
}
