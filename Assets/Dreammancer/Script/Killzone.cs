using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Collider2D))]
    public class Killzone : MonoBehaviour
    {

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
                Destroy(other.gameObject);
        }
    }
}
