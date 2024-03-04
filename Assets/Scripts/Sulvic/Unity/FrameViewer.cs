using UnityEngine;
using Sulvic.Util;

namespace Sulvic.Unity{

	public class FrameViewer: MonoBehaviour{

		private float framerate, maxFramerate, minFramerate, updateFrequency = 0.1f, updateTimer;

		private void Start(){
			updateTimer = updateFrequency;
			maxFramerate = 0f;
			minFramerate = float.MaxValue;
		}

		private void Update(){
			updateTimer -= Time.deltaTime;
			if(updateTimer <= 0f){
				framerate = 1f / Time.unscaledDeltaTime;
				updateTimer = updateFrequency;
				minFramerate = SulvicMath.Min(minFramerate, framerate);
				maxFramerate = SulvicMath.Max(maxFramerate, framerate);
			}
		}

	}

}
