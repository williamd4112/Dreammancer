using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class MovingLaser : MonoBehaviour
    {
        [SerializeField]
        private Transform laser;
        [SerializeField]
        private Transform startPos;
        [SerializeField]
        private Transform endPos;
        [SerializeField]
        private float speed;

        private Vector2 direction;
        private Transform destination;

        // Use this for initialization
        void Start()
        {
            SetDestination(startPos);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            laser.transform.Translate(laser.transform.InverseTransformDirection(direction * speed * Time.fixedDeltaTime));

            Vector2 dis = destination.position - laser.position;
            float dot = Vector2.Dot(direction.normalized, dis.normalized);

            if (Vector3.Distance(laser.transform.position, destination.position) < speed * Time.fixedDeltaTime ||
                dot < 1)
            {           
                SetDestination(destination == startPos ? endPos : startPos);
            }
        }

        void SetDestination(Transform dest)
        {
            destination = dest;
            direction = (destination.position - laser.transform.position).normalized;
        }
    }
}
