using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Timer : MonoBehaviour {

    private Text m_Text;

    public static float s_Counter = 0;

	// Use this for initialization
	void Start () {
        m_Text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        float t = Time.timeSinceLevelLoad;
        s_Counter += t - s_Counter;
        string timeStr = string.Format("{0}",t);
        m_Text.text = timeStr;
    }
}
