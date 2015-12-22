using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace Dreammancer
{
    [RequireComponent(typeof(PlayerCharacter))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerCharacter m_Character;
        private bool m_Jump;

        private void Awake()
        {
            m_Character = GetComponent<PlayerCharacter>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            float h = CrossPlatformInputManager.GetAxis("Horizontal");

            // Pass all parameters to the character control script.
            m_Character.Move(h, m_Jump);
            m_Jump = false;
        }
    }

}