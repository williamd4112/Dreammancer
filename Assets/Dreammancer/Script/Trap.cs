using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public interface Trappable
    {
        void OnTrapEnter(Trap trap);
        void OnTrapStay(Trap trap);
        void OnTrapExit(Trap trap);
    }

    abstract public class Trap : MonoBehaviour
    {
        private Damage m_Damage;
        public Damage damage
        {
            get { return m_Damage; }
            set { m_Damage = value; }
        }

        protected virtual void Start()
        {
            m_Damage = new Damage(0, Damage.DamageType.NODAMAGE);
        }

        abstract public void InvokeOnTrapEnter(Trappable trappable);
        abstract public void InvokeOnTrapStay(Trappable trappable);
        abstract public void InvokeOnTrapExit(Trappable trappable);

        virtual public void OnCollisionEnter2D(Collision2D collision)
        {
            Trappable trappable = collision.gameObject.GetComponent<Trappable>() as Trappable;

            if (trappable != null)
            {
                InvokeOnTrapEnter(trappable);
                trappable.OnTrapEnter(this);
            }
        }

        virtual public void OnCollisionStay2D(Collision2D collision)
        {
            Trappable trappable = collision.gameObject.GetComponent<Trappable>() as Trappable;
            if (trappable != null)
            {
                InvokeOnTrapStay(trappable);
                trappable.OnTrapStay(this);
            }
        }

        virtual public void OnCollisionExit2D(Collision2D collision)
        {
            Trappable trappable = collision.gameObject.GetComponent<Trappable>() as Trappable;
            if (trappable != null)
            {
                InvokeOnTrapExit(trappable);
                trappable.OnTrapExit(this);
            }
        }

        virtual public void OnTriggerEnter2D(Collider2D collision)
        {
            Trappable trappable = collision.gameObject.GetComponent<Trappable>() as Trappable;

            if (trappable != null)
            {
                InvokeOnTrapEnter(trappable);
                trappable.OnTrapEnter(this);
            }
        }

        virtual public void OnTriggerStay2D(Collider2D collision)
        {
            Trappable trappable = collision.gameObject.GetComponent<Trappable>() as Trappable;
            if (trappable != null)
            {
                InvokeOnTrapStay(trappable);
                trappable.OnTrapStay(this.GetComponent<Trap>());
            }
        }

        virtual public void OnTriggerExit2D(Collider2D collision)
        {
            Trappable trappable = collision.gameObject.GetComponent<Trappable>() as Trappable;
            if (trappable != null)
            {
                InvokeOnTrapExit(trappable);
                trappable.OnTrapExit(this.GetComponent<Trap>());
            }
        }
    }
}
