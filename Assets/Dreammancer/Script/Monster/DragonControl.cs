using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;

namespace UnityStandardAssets._2D
{
	[RequireComponent(typeof (PlatformerCharacter2D))]
	public class DragonControl : MonoBehaviour
	{
		private PlatformerCharacter2D m_Character;
		private monsterAI monster;
		private bool m_Jump;
		private GameObject player;
		[SerializeField] private float dir;
		
		
		private void Awake()
		{
			m_Character = GetComponent<PlatformerCharacter2D>();
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
			fly(crouch);
			
			//monster.jump ();
			//float h = CrossPlatformInputManager.GetAxis("Horizontal");
			
			// Pass all parameters to the character control script.
			
			m_Jump = false;

		}

		void OnCollisionEnter2D(Collision2D collision) {
			Debug.Log (collision.gameObject);
			dir = monster.toggleDir(dir);

		}

		private void fly(bool crouch){
			float h = 0;
			h = dir * monster.move("forward");
			m_Character.Move(h, crouch,  m_Jump);

		}
	}
}
