using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    abstract public class DamageHandler : MonoBehaviour
    {
        [SerializeField]
        private Damage.DamageType type;

        public Damage.DamageType Type
        {
            get{ return type; }
        }

        abstract public void OnDamageTrigger(Damage damage);
    }
}
