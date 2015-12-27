using UnityEngine;
using System.Collections;


namespace Dreammancer{
	public class Parallaxing : MonoBehaviour {

		public Transform[] backgrounds; //the list of all the back- and foregounds to be parallax
		private float[] parallaxScales;
		public float smoothing = 1f; // how smooth the parallax
		private Transform cam;
		private Vector3 previousCamPos; //The position of the camera of the previous frame
	
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
				float parallex = (previousCamPos.x - cam.position.x) * 1;
				//float parallex = (previousCamPos.x - cam.position.x) * 0.01f;
				float backgroundsTargetPosX = backgrounds[i].position.x + parallex;

				Vector3 backgroundsTargetPos = new Vector3 (backgroundsTargetPosX,backgrounds[i].position.y,backgrounds[i].position.z);

				//fade between current position and the target position using lerp
				backgrounds[i].position = Vector3.Lerp(backgrounds[i].position,backgroundsTargetPos,smoothing * Time.deltaTime);

				//Vector2 backgroundsTargetPos = new Vector2 (Time.time*10,0f);

				//Debug.Log ("backspeed:"+backgroundsTargetPos);
				//Debug.Log (backgrounds[i].gameObject.GetComponent<Renderer>().material.mainTexture.name);
				//backgrounds[i].gameObject.GetComponent<Renderer>().material.mainTextureOffset = backgrounds[i].gameObject.GetComponent<Renderer>().material.mainTextureOffset + new Vector2 (parallex,0f);
			}

			previousCamPos = cam.position;
		}
	}
}
