using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Collider2D))]
    public class RelocateCatcher : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            Relocate relocateObj = collider.gameObject.GetComponent<Relocate>();
            if (relocateObj != null)
            {
                relocateObj.OnUnavailable();
            }
        }
    }
}
