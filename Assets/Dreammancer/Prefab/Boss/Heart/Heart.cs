using UnityEngine;
using System.Collections;


namespace Dreammancer{
	public class Heart : MonoBehaviour {

		private Animator m_animator;
		private SpriteRenderer m_sr;
		private Color tempColor;
		private Animator b_animator;
		private Animator c_animator;
		private bool isTri;


		// Use this for initialization
		void Start () {
			m_animator = this.GetComponent<Animator> ();
			m_sr = this.GetComponent<SpriteRenderer> ();
			b_animator = this.transform.parent.GetComponent<Animator> ();
			c_animator = Camera.main.GetComponent<Animator> ();
			isTri = false;
		}
		
		// Update is called once per frame
		void Update () {
			//tempColor = ColorUtil.clampColor (this.GetComponent<SpriteRenderer> ().color,0,1);
			tempColor = ColorUtil.floatTo255 (m_sr.color);
			tempColor = ColorUtil.quantinize (tempColor, 127);
			tempColor.r = Mathf.FloorToInt (tempColor.r);
			tempColor.g = Mathf.FloorToInt (tempColor.g);
			tempColor.b = Mathf.FloorToInt (tempColor.b);
			//Debug.Log (tempColor);

			//Debug.Log (tempColor);
			if((ColorUtil.colorCompareRGB(tempColor,Color.black)) && (!isTri) && 
			   m_animator.GetCurrentAnimatorStateInfo(0).shortNameHash == Animator.StringToHash("HeartIdle")){
				int i = 0;
				Debug.Log ("times:" + i);
				m_animator.SetBool("Explo",true);
				b_animator.SetBool("Hurt",true);
				c_animator.SetBool("Hurt",true);
			}
		}

		void HeartDes(){
			this.transform.parent.GetComponent<ShootHeart> ().heartExi = false;
			this.transform.parent.GetComponent<ShootHeart> ().startBuild = true;
			m_animator.SetBool ("Explo", false);
			b_animator.SetBool ("Hurt", false);
			c_animator.SetBool ("Hurt", false);
			isTri = false;
			Destroy (this.gameObject);
		}

		void HeartEx(){
			this.transform.parent.gameObject.GetComponent<BossSound> ().PlayHurt ();
		}

		void HeartApp(){
			m_animator.SetTrigger ("Appeared");
		}
	}
}
