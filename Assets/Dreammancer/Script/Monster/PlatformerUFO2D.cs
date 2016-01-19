using UnityEngine;
using System.Collections;

namespace Dreammancer
{

	public class PlatformerUFO2D : MonoBehaviour
	{

		[SerializeField]
		private float m_Speed = 3.0f;

		private Animator m_Anim;
		private bool m_FacingRight = true;
		
		void Awake()
		{
			m_Anim = GetComponent<Animator>();

		}

		public void drift(float x, Transform target)
		{
			
			m_Anim.SetFloat("Speed", Mathf.Abs(x));
			// If the input is moving the player right and the player is facing left...
			if (x > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (x < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip(); 
			}


			//transform.Translate(Vector3.right * m_Speed + Vector3.up * m_Speed);
			transform.position = Vector3.Lerp (transform.position, target.position, m_Speed * Time.deltaTime);
			
			
		}
		
		private void Flip()
		{
			// Switch the way the player is labelled as facing.
			m_FacingRight = !m_FacingRight;
			
			// Multiply the player's x local scale by -1.
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}
