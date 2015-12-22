using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class OxControl : MonoBehaviour
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
			walk_chase(crouch);

			//monster.jump ();
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");

            // Pass all parameters to the character control script.

            m_Jump = false;
        }
		private void walk_chase(bool crouch){
			float h = 0;
			if(Mathf.Abs(player.transform.position.x - this.transform.position.x) < 20.0f){
				if (player.transform.position.x < this.transform.position.x) {
					if(dir == 1){
						h = dir * monster.move ("backward");
					}
					else{
						h = dir * monster.move ("forward");
					}
				} else {
					if(dir == 1){
						h = dir * monster.move ("forward");
					}
					else{
						h = dir * monster.move ("backward");
					}
				}
			}

			if (player.transform.position.y > this.transform.position.y + 3 && Mathf.Abs(player.transform.position.x - this.transform.position.x) < 5.0f) {
				m_Character.Move(h, crouch,  monster.jump ());
			} 
			else {
				m_Character.Move(h, crouch,  m_Jump);
			}
		}
    }
}
