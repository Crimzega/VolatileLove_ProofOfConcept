using UnityEngine;

namespace Sulvic.VoLov.Controls{

	public class AnimatorHandler{

		private Animator animator;
		private string currState;

		public AnimatorHandler(Component component){ animator = component.GetComponent<Animator>(); }

		public void ChangeState(string newState){
			if(currState == newState) return;
			animator.Play(currState = newState);
		}

	}

}
