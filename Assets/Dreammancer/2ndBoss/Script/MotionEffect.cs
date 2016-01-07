using UnityEngine;
using System.Collections;

namespace Dreammancer
{
	public enum EffectType
	{
		Red,
		Blue
	}

	[RequireComponent(typeof(Collider2D))]
	public class MotionEffect : MonoBehaviour {

		[SerializeField]
		private EffectType m_Type;
		public EffectType Type
		{
			get { return m_Type; }
		}
		[SerializeField]
		private AudioClip m_OnCollectedSound;
		[SerializeField]
		private GameObject m_OnCollectedAnimation;

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		void PlaySound()
		{
			AudioSource.PlayClipAtPoint(m_OnCollectedSound, transform.position);
		}
		
		void PlayAnimation()
		{
			if (m_OnCollectedAnimation != null)
				GameObject.Instantiate(m_OnCollectedAnimation, transform.position, transform.rotation);
		}
		void OnTriggerEnter2D(Collider2D collider)
		{
			PlaySound();
			PlayAnimation();
			//if(collider.gameObject.GetComponent<Effectable>()!=null)

			Destroy(gameObject);
		}
	}
}
