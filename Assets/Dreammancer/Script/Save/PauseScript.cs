using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace Dreammancer{
	public class PauseScript : MonoBehaviour {

		GameObject PauseMenu;

		bool paused;
		bool muted;
		[SerializeField]
		Text mutetext;

		// Use this for initialization
		void Start () {

			paused = false;
			PauseMenu = GameObject.Find("PauseMenu");
			SetActive_r (false);
		
		}
		
		// Update is called once per frame
		void Update () {

			if (CrossPlatformInputManager.GetButtonDown("Pause") || Input.GetKeyDown (KeyCode.Escape)) {
				paused = !paused;

			}

			if(paused){
				SetActive_r(true);
				//PauseMenu.SetActive(true);
				Time.timeScale = 0;
			}
			else if(!paused){
				SetActive_r(false);
				Time.timeScale = 1;
			}
		}
		public void Resume(){
			paused = false;
		}
		public void MainMenu(){
			Application.LoadLevel ("Level_Select3");
		}
		public void Save(){
			PlayerPrefs.SetInt ("currentscenesave", Application.loadedLevel);
		}
		public void Load(){
			Application.LoadLevel (PlayerPrefs.GetInt ("currentscenesave"));
		}
		public void Quit(){
			Application.Quit ();
		}

		void SetActive_r(bool b)
		{
			foreach (Image obj in PauseMenu.GetComponentsInChildren<Image>()) {
				obj.GetComponentInChildren<Text>().enabled = b;
				obj.enabled = b;
			}
		}

	}
}