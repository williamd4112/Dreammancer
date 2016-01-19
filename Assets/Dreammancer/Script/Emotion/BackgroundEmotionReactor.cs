using UnityEngine;
using System.Collections;

namespace Dreammancer
{
	public class BackgroundEmotionReactor : MonoBehaviour {

		// Use this for initialization
		void Start () {

			SceneManager.RegisterEmotionEvent (OnEmotionChange);
		}
		
		// Update is called once per frame
		void Update () {

		}

		void OnEmotionChange(SceneState state, int emotionVal, int emotionDiff)
		{
			Color color = GetComponent<Renderer>().material.color; 
			switch(state)
			{
			case SceneState.NEGATIVE:
				color = Color.blue;
				color.a = 1.0f;
				break;
			case SceneState.NORMAL:
				color = Color.white;
				color.a = 1.0f;
				break;
			case SceneState.POSITIVE:
				color = Color.red;
				color.a = 1.0f;
				break;
			default:
				break;
			}
            GetComponent<Renderer>().material.color = color;
		}
	}
}
