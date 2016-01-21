using UnityEngine;
using System.Collections;
using ProgressBar;

namespace Dreammancer
{
	public class LoadLevelScript : MonoBehaviour {

		public static string ToLoadLevel = "Level1";

		private ProgressBarBehaviour m_ProgressBar;
		private AsyncOperation m_LoadOp;

		// Use this for initialization
		void Start () {
			m_ProgressBar = GetComponent<ProgressBarBehaviour> ();

			m_LoadOp = Application.LoadLevelAsync (ToLoadLevel);
		}
		
		// Update is called once per frame
		void Update () {
			m_ProgressBar.Value = m_LoadOp.progress * 1000;
		}
	}

}