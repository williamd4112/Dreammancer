using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Dreammancer{
	public class LevelSelect : MonoBehaviour {

		int sw = Screen.width;
		int sh = Screen.height;
		//public string Level;

		void OnGUI(){

			if (GUI.Button (new Rect (0, 0, sw * .25f, sh), "Level: 1")) {
				Application.LoadLevel("Stage 1_Real 1");
				//PlayerPrefs.DeleteKey("levelUnlock");

			}
			//else if()
			if (PlayerPrefs.GetInt ("levelUnlock", 0) >= 2) {
				if (GUI.Button (new Rect (sw * .25f, 0, sw * .25f, sh), "Level: 2")) {
					Application.LoadLevel ("Stage 1_DashTesting");
				}
			} 
			else {
				GUI.Box (new Rect (sw * .25f, 0, sw * .25f, sh), "\n\nLocked"+"\n\n\n"+"Level: 2");
			}
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