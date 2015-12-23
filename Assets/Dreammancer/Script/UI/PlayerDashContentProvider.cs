using UnityEngine;
using System.Collections;
using System;

namespace Dreammancer
{
    public class PlayerDashContentProvider : ProgressBarContentProvider
    {
        [SerializeField]
        private DreammancerCharacter m_Character;

        public override int OnProvideProgressBarContent()
        {
            return m_Character.DashEnergy;
        }
    }

}