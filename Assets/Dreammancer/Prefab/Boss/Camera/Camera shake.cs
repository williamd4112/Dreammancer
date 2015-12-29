using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class Camerashake : MonoBehaviour {



		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void shakeAndBake(){
			float shakeAmt = 1f; // the degrees to shake the camera
			float shakePeriodTime = 0.42f; // The period of each shake
			float dropOffTime = 1.6f; // How long it takes the shaking to settle down to nothing
			LTDescr shakeTween = LeanTween.rotateAroundLocal( gameObject, Vector3.forward, shakeAmt, shakePeriodTime)
				.setEase( LeanTweenType.easeShake ) // this is a special ease that is good for shaking
					.setLoopClamp()
					.setRepeat(-1);
			
			// Slow the camera shake down to zero
			LeanTween.value(gameObject, shakeAmt, 0f, dropOffTime).setOnUpdate( 
			                                                                   (float val)=>{
				shakeTween.setTo(Vector3.right*val);
			}
			).setEase(LeanTweenType.easeOutQuad);
		}
	}
}
