using UnityEngine;
using System.Collections;

public class KeepPlayinh : MonoBehaviour {

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start () {
        if (!(Application.loadedLevelName.Equals("Opening")||!Application.loadedLevelName.Equals("Level_Select3")))
        {
            Destroy(this.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
