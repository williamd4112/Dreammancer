using UnityEngine;
using System.Collections;
namespace Dreammancer{
	public class SecBossEffectable : Effectable {

		public override void MotionMod(){
			if (m_motionS == motionState.Angry) {
				motion = motionThreshold;
			} else if (m_motionS == motionState.Sad) {
				motion = -1 * motionThreshold;
			}
		}

	}
}
