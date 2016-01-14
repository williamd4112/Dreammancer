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
		[SerializeField]
		private int EnergyAmount = 1;
		//private GameObject p_EmotionTurret;

		// Use this for initialization
		void Start () {
			//p_EmotionTurret = this.transform.parent.gameObject;
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
			GameObject obj = null;
			PlaySound();
			PlayAnimation();
			//Debug.Log (collider.gameObject.name);
			//Debug.Log (collider.GetComponent<Effectable> ());
			if(collider.gameObject.GetComponent<Effectable>()!=null||collider.gameObject.GetComponent<SecBossEffectable>()!=null){
				//Debug.Log ("Found it");
				if(m_Type == EffectType.Blue){
					collider.gameObject.GetComponent<Effectable>().SadChange(EnergyAmount);
					//p_EmotionTurret.GetComponent<EmotionTurretShoot>().SaQueue.Enqueue(this.gameObject);
				}
				else if(m_Type == EffectType.Red){
					collider.gameObject.GetComponent<Effectable>().AngerChange(EnergyAmount);;
					//p_EmotionTurret.GetComponent<EmotionTurretShoot>().AnQueue.Enqueue(this.gameObject);
				}
			}
			if(m_Type == EffectType.Blue){
				BlueHandler();
			}
			else if(m_Type == EffectType.Red){
				RedHandler();
			}
			this.gameObject.SetActive (false);
		}

		virtual public void BlueHandler ()
		{

		}
		virtual public void RedHandler()
		{

		}
	}
}
