using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Dreammancer
{
	//需要EventTrigger脚本的支援
	[RequireComponent(typeof(UnityEngine.EventSystems.EventTrigger))]
	public class EventHandler : MonoBehaviour
	{
		
		// Use this for initialization
		void Start()
		{
			
			Button btn = this.GetComponent<Button>();
			UnityEngine.EventSystems.EventTrigger trigger = btn.gameObject.GetComponent<UnityEngine.EventSystems.EventTrigger>();
			EventTrigger.Entry entry = new EventTrigger.Entry();
			//鼠标点击事件
			entry.eventID = EventTriggerType.PointerClick;
			//鼠标滑出事件
			//entry.eventID = EventTriggerType.PointerExit;
			//鼠标进入事件
			//entry.eventID = EventTriggerType.PointerEnter;
			entry.callback = new EventTrigger.TriggerEvent();
			entry.callback.AddListener(OnMouseEnter);
			
			trigger.triggers.Add(entry);
		}

		// Update is called once per frame
		void Update () {
			
		}
		
		private void OnMouseEnter(BaseEventData pointData)
		{
			Debug.Log("Button Enter");
			
		}
		
	}
}