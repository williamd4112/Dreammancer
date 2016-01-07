using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class DeadArea : MonoBehaviour {

    [SerializeField]
    private GameObject m_ToDestroy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            m_ToDestroy.SetActive(false);
            Destroy(gameObject);
        }
           
    }
}
