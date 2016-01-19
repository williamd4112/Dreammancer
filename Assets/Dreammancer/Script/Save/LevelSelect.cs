using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Dreammancer{
	public class LevelSelect : MonoBehaviour {

		int sw = Screen.width;
		int sh = Screen.height;
		public float guiPlacementY1;
		public float guiPlacementY2;
		public float guiPlacementY3;
		
		public float guiPlacementX1;
		public float guiPlacementX2;
		public float guiPlacementX3;
		//public string Level;

		void OnGUI(){

//			if (PlayerPrefs.GetInt ("levelUnlock", 0) == 0) {
//				if (GUI.Button (new Rect (0, 0, sw * .2f, sh), "Level: 1")) {
//					Application.LoadLevel ("Stage 1_Real 1");
//					//PlayerPrefs.DeleteKey("levelUnlock");
//				}
//				GUI.Box (new Rect (sw * .2f, 0, sw * .2f, sh), "\n\nLocked"+"\n\n\n"+"Level: 2");
//				GUI.Box (new Rect (sw * .2f, 0, sw * .2f, sh), "\n\nLocked"+"\n\n\n"+"Level: 2");
//				GUI.Box (new Rect (sw * .2f, 0, sw * .2f, sh), "\n\nLocked"+"\n\n\n"+"Level: 2");
//				GUI.Box (new Rect (sw * .2f, 0, sw * .2f, sh), "\n\nLocked"+"\n\n\n"+"Level: 2");
//			}
//
//			if (GUI.Button (new Rect (Screen.width * guiPlacementX1, Screen.height * guiPlacementY1, Screen.width * .5f, Screen.height * .1f), "Play Game")) {
//				Application.LoadLevel (FirstLevel);
//			}
//			if (GUI.Button (new Rect (Screen.width * guiPlacementX2, Screen.height * guiPlacementY2, Screen.width * .5f, Screen.height * .1f), "Delete Data")) {
//				PlayerPrefs.DeleteAll();
//				//Application.LoadLevel (FirstLevel);
//			}
//			
//			if (GUI.Button (new Rect (Screen.width * guiPlacementX3, Screen.height * guiPlacementY3, Screen.width * .5f, Screen.height * .1f), "Quit")) {
//				Application.Quit();
//			}

			if (GUI.Button (new Rect (0, 0, sw * .2f, sh), "Teach Level")) {
				Application.LoadLevel("FirstSceneVedio");
				//PlayerPrefs.DeleteKey("levelUnlock");
			}
			//else if()
			if (PlayerPrefs.GetInt ("levelUnlock", 0) == 2) {
				if (GUI.Button (new Rect (sw * .2f, 0, sw * .2f, sh), "Level: 1")) {
					Application.LoadLevel ("Stage 1_DashTesting");
				}
			} 
			else {
				GUI.Box (new Rect (sw * .2f, 0, sw * .2f, sh), "\n\nLocked"+"\n\n\n"+"Level: 1");
				//GUI.Box (new Rect (sw * .2f, 0, sw * .2f, sh), "\n\nLocked"+"\n\n\n"+"Level: 3");
			}

//			if (PlayerPrefs.GetInt ("levelUnlock", 0) == 3) {
//				if (GUI.Button (new Rect (sw * .2f, 0, sw * .2f, sh), "Level: 2")) {
//					Application.LoadLevel ("Stage 1_DashTesting");
//				}
//			} 
//			else {
//				GUI.Box (new Rect (sw * .2f, 0, sw * .2f, sh), "\n\nLocked"+"\n\n\n"+"Level: 3");
//			}

//			if (PlayerPrefs.GetInt ("levelUnlock", 0) >= 2) {
//				if (GUI.Button (new Rect (sw * .25f, 0, sw * .25f, sh), "Boss: 1")) {
//					Application.LoadLevel ("BossFight");
//				}
//			} 
//			else {
//				GUI.Box (new Rect (sw * .25f, 0, sw * .25f, sh), "\n\nLocked"+"\n\n\n"+"Level: 2");
//			}
////			if (PlayerPrefs.GetInt ("levelUnlock", 0) >= 2) {
////				if (GUI.Button (new Rect (sw * .25f, 0, sw * .25f, sh), "Boss: 2")) {
////					Application.LoadLevel ("2ndBossFight");
////				}
////			} 
////			else {
////				GUI.Box (new Rect (sw * .25f, 0, sw * .25f, sh), "\n\nLocked"+"\n\n\n"+"Level: 2");
////			}
			
		}

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}