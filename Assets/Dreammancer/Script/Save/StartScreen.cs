using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class StartScreen : MonoBehaviour {

		public string FirstLevel;

		public Texture backgroundTexture;

		public float guiPlacementY1;
		public float guiPlacementY2;
		public float guiPlacementY3;

		public float guiPlacementX1;
		public float guiPlacementX2;
		public float guiPlacementX3;
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
//		void Update () {
//
//			if (!Input.GetMouseButtonDown (0))
//				return;
//
//			Application.LoadLevel (FirstLevel);
//		
//		}

		void OnGUI(){

			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);

			if (GUI.Button (new Rect (Screen.width * guiPlacementX1, Screen.height * guiPlacementY1, Screen.width * .5f, Screen.height * .1f), "Play Game")) {
				Application.LoadLevel (FirstLevel);
			}
			if (GUI.Button (new Rect (Screen.width * guiPlacementX2, Screen.height * guiPlacementY2, Screen.width * .5f, Screen.height * .1f), "Delete Data")) {
				PlayerPrefs.DeleteAll();
				//Application.LoadLevel (FirstLevel);
			}

			if (GUI.Button (new Rect (Screen.width * guiPlacementX3, Screen.height * guiPlacementY3, Screen.width * .5f, Screen.height * .1f), "Quit")) {
				Application.Quit();
			}
		}
	}
}