using UnityEngine;
using System.Collections;

namespace Dreammancer
{

	public class teleport : MonoBehaviour
	{
		          // Whether or not the player is grounded.

		private BoxCollider2D m_collider;
		private Animator m_Anim;
		//private Rigidbody2D m_Rigidbody;
		//private bool m_FacingRight = true;
		
		void Awake()
		{
			m_Anim = GetComponent<Animator>();
			//m_GroundCheck = transform.Find("GroundCheck");
		}
		// Use this for initialization
		void Start()
		{
			m_collider = GetComponent<BoxCollider2D>();
		}
		
		// Update is called once per frame
		void Update()
		{
			
		}
		
		private void FixedUpdate()
		{
			//m_Grounded = false;
			
			// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
			// This can be done using layers instead but Sample Assets will not overwrite your project settings.
			//Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
			//for (int i = 0; i < colliders.Length; i++)
			//{
			//	if (colliders[i].gameObject != gameObject)
			//	{
			//		m_Grounded = true;
			//	}
			//}
			
			//m_Anim.SetBool("Ground", m_Grounded);
		}
		


		
		void OnTriggerEnter2D(Collider2D collider){
			m_Anim.SetBool("Trigger", true);
		}

		void OnTriggerExit2D(Collider2D collider){
			m_Anim.SetBool("Trigger", false);

		}
	}
}
