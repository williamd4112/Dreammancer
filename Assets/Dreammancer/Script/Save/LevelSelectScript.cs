using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class LevelSelectScript : MonoBehaviour {
		
		//private int worldIndex;   
		public int levelIndex;   
		
		void  Start (){
			//loop thorugh all the worlds
//			for(int i = 1; i <= LockLevel.worlds; i++){
//				if(Application.loadedLevelName == "World"+i){
//					worldIndex = i;
//					CheckLockedLevels(); 
//				}
//			}
		}

		void Update(){
			CheckLockedLevels(); 
		}
		
		//Level to load on button click. Will be used for Level button click event 
		public void Selectlevel(int levelIndex){
			if (levelIndex == 1) {
				Application.LoadLevel ("FirstSceneVedio");
			}
			else {
				Application.LoadLevel ("Level" + levelIndex); //load the level
			}
		}
		
		//uncomment the below code if you have a main menu scene to navigate to it on clicking escape when in World1 scene
		/*public void  Update (){
	  if (Input.GetKeyDown(KeyCode.Escape) ){
	   Application.LoadLevel("MainMenu");
	  }   
	 }*/
		
		//function to check for the levels locked
		void  CheckLockedLevels (){
			//loop through the levels of a particular world
			for(int i = 1; i <= PlayerPrefs.GetInt("lockedlevel"); i++){
				//levelIndex = (j+1);
				//int varInt = 1; 
				//string varString = Convert.ToString(varInt); 
				string varString1 = PlayerPrefs.GetInt("lockedlevel").ToString();
				Debug.Log(varString1);
				//if((PlayerPrefs.GetInt("level"+worldIndex.ToString() +":" +levelIndex.ToString()))==1){
				GameObject.Find("LockedLevel"+varString1).active = false;
					Debug.Log ("Unlocked");
			}
		}
	}
}