using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class SceneSegment : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                foreach(Transform t in GetComponentsInChildren<Transform>())
                {
                    t.gameObject.SetActiveRecursively(true);
                }
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                foreach (Transform t in GetComponentsInChildren<Transform>())
                {
                    t.gameObject.SetActiveRecursively(false);
                }
            }
        }
    }
}
