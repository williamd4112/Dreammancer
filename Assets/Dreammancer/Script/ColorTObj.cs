using UnityEngine;
using System.Collections;

namespace Dreammancer
{
	public class ColorTObj : ColorTrap {

		public GameObject Parent;
		private bool isParentDis;
		private Rigidbody2D rb2;
		SpriteRenderer sr;
		// Use this for initialization
		void Start () {
			rb2 = this.GetComponent<Rigidbody2D> () as Rigidbody2D;
			//sr = this.gameObject.GetComponentInParent<SpriteRenderer> () as SpriteRenderer;
			sr = Parent.GetComponent<SpriteRenderer> () as SpriteRenderer;
		}
		
		// Update is called once per frame
		void Update () {
			Debug.Log (sr.color);
			if (sr.color.r <=0.5 && sr.color.g <= 0.5 && sr.color.b <= 0.5) {
				rb2.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
				rb2.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
				//rb2.freezeRotation = false;
				this.transform.parent = null;
			}
		}

		void OnParentDisappeared(){
			//Rigidbody2D rb2 = GetComponent<Rigidbody2D> () as Rigidbody2D;
			if (sr.color.r == 0 && sr.color.b == 0 && sr.color.g == 0) {
				isParentDis = true;
			}
		}

		public override void InvokeOnTrapEnter(Trappable trappable)
		{
			
		}
		
		public override void InvokeOnTrapExit(Trappable trappable)
		{
			
		}
		
		public override void InvokeOnTrapStay(Trappable trappable)
		{
			
		}
	}
	
}
