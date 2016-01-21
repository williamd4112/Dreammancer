using UnityEngine;
using System.Collections;

public class KeepPlayinh : MonoBehaviour {

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
