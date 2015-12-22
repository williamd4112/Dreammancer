using UnityEngine;
using System.Collections;

public class monsterAI : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	const float m_JumpCoolDownTime = .2f;

	public bool isJump = false;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator jumpCoolDown(float t)
	{
		yield return new WaitForSeconds(t);
		isJump = false;
	}

	private void FixedUpdate(){
	
	}

	public float move(string dir){
		float h = 0;
		if (dir == "right") {
			h = Mathf.Lerp(0, 1, Time.time);
		}
		else if(dir == "left"){
			h = Mathf.Lerp(-1, 0, Time.time);
		}		
		return h;
	}
	public float toggleDir(float dir){
		return -1 * dir;
	}

	public bool jump(){
		if (!isJump) {
			isJump = true;
			StartCoroutine(jumpCoolDown(m_JumpCoolDownTime));
			return true;
		}
		return false;
	}
}
