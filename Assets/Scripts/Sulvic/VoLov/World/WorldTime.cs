using UnityEngine;

namespace Sulvic.VoLov.World{

	public class WorldTime: MonoBehaviour{

		public event TimeDelegate TimeEvent;
		private int hour, minute;

		private void Start(){}

		private void Update(){
			if(TimeEvent != null) TimeEvent.Invoke(hour, minute);
		}

	}

}
