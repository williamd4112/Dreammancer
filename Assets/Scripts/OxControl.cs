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
		private float dir;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
			monster = GetComponent<monsterAI> ();
			dir = 1.0f;
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
			//float h = 0;
			float h = dir * monster.move ("right");
			
			//monster.jump ();
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");
			Debug.Log (h);
            // Pass all parameters to the character control script.

			m_Character.Move(h, crouch,  monster.jump());
            m_Jump = false;
        }
    }
}
