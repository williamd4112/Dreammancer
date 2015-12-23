using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class PlayerHpContentProvider : ProgressBarContentProvider
    {
        [SerializeField]
        private DreammancerCharacter m_Character;

        public override int OnProvideProgressBarContent()
        {
            return m_Character.Health.HealthPoint;
        }
    }

}
