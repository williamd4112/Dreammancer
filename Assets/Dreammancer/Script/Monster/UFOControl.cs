using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;

namespace UnityStandardAssets._2D
{
	[RequireComponent(typeof (PlatformerCharacter2D))]
	public class UFOControl : MonoBehaviour
	{
		private PlatformerUFO2D m_Character;
		private monsterAI monster;
		private bool m_Jump;
		private GameObject player;
		[SerializeField] private float dir;
		private Vector2 delta_position;
		private bool isCollided;
		
		
		private void Awake()
		{
			m_Character = GetComponent<PlatformerUFO2D>();
			monster = GetComponent<monsterAI> ();			
			
		}
		private void Start(){
			player = GameObject.Find("Player");
		}
		
		private void Update()
		{
			if (!m_Jump)
			{
				// Read the jump input in Update so button presses aren't missed.
				//m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
				//m_Jump = monster.jump();
				
			}
			//dir = monster.toggleDir (dir);
		}
		
		
		private void FixedUpdate()
		{
			// Read the inputs.
			bool crouch = Input.GetKey(KeyCode.LeftControl);

			fly_chase (crouch);

			//monster.jump ();
			//float h = CrossPlatformInputManager.GetAxis("Horizontal");
			
			// Pass all parameters to the character control script.
			
			m_Jump = false;
			
		}
		
		void OnCollisionEnter2D(Collision2D collision) {
			Debug.Log ("in");
			isCollided = true;			
		}
		void OnCollisionStay2D(Collision2D collision) {
			if (collision.gameObject.name != "Player") {

			}			
		}
		void OnCollisionExit2D(Collision2D coll) {
			isCollided = false;
			Debug.Log ("out");
		}
		
		private void fly_chase(bool crouch){
			float h = 0;
			if (isCollided) {
				h = dir * monster.move ("backward");
			} else {
				if (player.transform.position.x < this.transform.position.x) {

					if(dir == 1){
						dir = monster.toggleDir(dir);

					}					
					h = dir * monster.move ("forward");
					
				} else {

					if(dir == -1){
						dir = monster.toggleDir(dir);
					}					
					h = dir * monster.move ("forward");
				}
			}
			delta_position = new Vector2 (Mathf.Abs (player.transform.position.x - this.transform.position.x), player.transform.position.y - this.transform.position.y);

			m_Character.Move(h, crouch, m_Jump, delta_position);
			
		}

	}
}
