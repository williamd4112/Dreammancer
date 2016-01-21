using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Timer : MonoBehaviour {

    private Text m_Text;
   
	// Use this for initialization
	void Start () {
        m_Text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        float t = Time.timeSinceLevelLoad;
        int min = (int)(t / 60);
        int sec = (int)(t / 60 / 60);
        string timeStr = string.Format("{0}",t);
        m_Text.text = timeStr;
    }
}
