//using UnityEngine;
//using System.Collections;
//
//public class PlayerMovement : MonoBehaviour {
//
//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//}
using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class PlayerMovement : MonoBehaviour {
		
		protected string currentLevel;
		protected int worldIndex;
		protected int levelIndex;
		// Use this for initialization
		void Start () {
			//save the current level name
			//currentLevel = Application.loadedLevelName;
		}
		
		// Update is called once per frame
		void Update () {
			//move the player based on left and right arrow keys
			//transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*10f, 0, 0); //get input
		}
		
		//check if the player hits the Goal object
		public void OnTriggerEnter2D(Collider2D other){
			Debug.Log(other.gameObject);
			if(other.gameObject.CompareTag("Player")){
				//Debug.Break();
				Debug.Log("Hate!!");
				UnlockLevels();   //unlock next level funxtion 
			}
		}
		
		public void  UnlockLevels (){
			//set the playerprefs value of next level to 1 to unlock
			for(int i = 0; i < LockLevel.worlds; i++){
				for(int j = 1; j < LockLevel.levels; j++){               
					if(currentLevel == "Level"+(i+1).ToString() +"." +j.ToString()){
						worldIndex  = (i+1);
						levelIndex  = (j+1);
						PlayerPrefs.SetInt("level"+worldIndex.ToString() +":" +levelIndex.ToString(),1);
					}
				}
			}
			//load the World1 level 
			Debug.Log("Shit!!");
//			Application.LoadLevel("Level"+(i+1).ToString());
		}
	}
}