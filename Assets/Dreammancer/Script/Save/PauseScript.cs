using UnityEngine;
using UnityEngine.UI;
using System.Collections;


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
		
		}
		
		// Update is called once per frame
		void Update () {

			if (Input.GetKeyDown (KeyCode.Escape)) {
				paused = !paused;

			}
			if(paused){
				PauseMenu.SetActive(true);
				Time.timeScale = 0;
			}
			else if(!paused){
				PauseMenu.SetActive(false);
				Time.timeScale = 1;
			}
		}
		public void Resume(){
			paused = false;
		}
		public void MainMenu(){
			Application.LoadLevel ("StartScene");
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

	}
}