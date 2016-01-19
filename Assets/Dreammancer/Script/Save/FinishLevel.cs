using UnityEngine;
using System.Collections;


namespace Dreammancer{
	public class FinishLevel : MonoBehaviour {

		public string LevelName;
		public int levelIndex; 
		//bool flag = false;

		// Use this for initialization
		void Start () {
//			PlayerPrefs.SetInt("currentlevel",levelIndex);
//			PlayerPrefs.SetInt("lockedlevel",levelIndex+1);
			//Debug.Log(".....");
//			Debug.Log (PlayerPrefs.GetInt ("currentlevel"));
//			Debug.Log (PlayerPrefs.GetInt ("lockedlevel"));
			//Debug.Log(".....");
		
		}
		
		// Update is called once per frame
		void Update () {
		}

		public void OnTriggerEnter2D(Collider2D other){

			Time.timeScale = 0;
			Debug.Log("ok!!!");

			if (other.GetComponent<DreammancerCharacter> () == null) {

				Debug.Log("something");
				return;
			}
			LevelManager.Instance.GotoNextLevel (LevelName);
			PlayerPrefs.SetInt("currentlevel",levelIndex);
			Debug.Log (PlayerPrefs.GetInt ("currentlevel"));
			PlayerPrefs.SetInt("lockedlevel",levelIndex+1);
			Debug.Log (PlayerPrefs.GetInt ("lockedlevel"));
			//PlayerPrefs.SetInt ("levelUnlock", 2);
			//UnlockLevels(); 
		}
//		public void OnTriggerEnter2D(Collider2D other){
//			Debug.Log(other.gameObject);
//			if(other.gameObject.CompareTag("Player")){
//				//Debug.Break();
//				Debug.Log("Hate!!");
//				UnlockLevels();   //unlock next level funxtion 
//			}
//		}
		
//		public void  UnlockLevels (){
//			//loop through the levels of a particular world
//			for(int i = 1; i < PlayerPrefs.GetInt("lockedlevel"); i++){
//				//levelIndex = (j+1);
//				//if((PlayerPrefs.GetInt("level"+worldIndex.ToString() +":" +levelIndex.ToString()))==1){
//				GameObject.Find("LockedLevel"+(i+1)).active = false;
//				Debug.Log ("Unlocked");
//			}
//		}

	}
}