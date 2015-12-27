using UnityEngine;
using System.Collections;


namespace Dreammancer{
	public class ParallaxingV2 : MonoBehaviour {
		
		public Transform[] backgrounds; //the list of all the back- and foregounds to be parallax
		private float[] parallaxScales;
		public float smoothing = 1000f; // how smooth the parallax
		private Transform cam;
		private Vector3 previousCamPos; //The position of the camera of the previous frame
		public float speed = 1;
        public float speedy = 1;
		
		// Is called before start
		/*void Awake(){
			cam = Camera.main.transform;
		}*/
		// Use this for initialization
		void Start () {
			cam = Camera.main.transform;
			previousCamPos = cam.position;
			
			parallaxScales = new float[backgrounds.Length];
			
			//Assingning coresponding parallax scales
			for (int i = 0; i < backgrounds.Length; i++) {
				parallaxScales[i] = backgrounds[i].position.z;
			}
		}
		
		// Update is called once per frame
		void Update () {
			
			//for each backgrounds
			for(int i = 0;i < backgrounds.Length ; i++){
				float parallex = (previousCamPos.x - cam.position.x) * -1 *speed;
				float paralley = (previousCamPos.y - cam.position.y) * -1 * speedy;
				//float parallex = (previousCamPos.x - cam.position.x) * 0.01f;
				//float backgroundsTargetPosX = backgrounds[i].position.x + parallex;
				
				//Vector3 backgroundsTargetPos = new Vector3 (backgroundsTargetPosX,backgrounds[i].position.y,backgrounds[i].position.z);
				
				//fade between current position and the target position using lerp
				//backgrounds[i].position = Vector3.Lerp(backgrounds[i].position,backgroundsTargetPos,smoothing * Time.deltaTime);
				
				//Vector2 backgroundsTargetPos = new Vector2 (Time.time*10,0f);
				
				//Debug.Log ("backspeed:"+backgroundsTargetPos);
				//Debug.Log (backgrounds[i].gameObject.GetComponent<Renderer>().material.mainTexture.name);
				Vector2 bgTex = backgrounds[i].gameObject.GetComponent<Renderer>().material.mainTextureOffset;
				backgrounds[i].gameObject.GetComponent<Renderer>().material.mainTextureOffset = Vector2.Lerp(bgTex, bgTex + new Vector2 (parallex,paralley),smoothing * Time.deltaTime);
			}
			
			previousCamPos = cam.position;
		}
	}
}
