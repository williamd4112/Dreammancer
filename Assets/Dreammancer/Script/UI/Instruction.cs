﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Dreammancer
{
	public class Instruction : MonoBehaviour {

		[SerializeField]
		private string m_Message;
		[SerializeField]
		private Text m_Text;

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		void OnTriggerEnter2D(Collider2D other){
			if (other.gameObject.tag == "Player") {
				m_Text.text = m_Message;
				Debug.Log("Fuck");
			}
			
		}
	}
}