using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Dreammancer{
	public class Start : MonoBehaviour {

		public void OnClick ()
		{
			Application.LoadLevel ("Level_Select");
			Debug.Log ("OnClick");
		}
	}
}