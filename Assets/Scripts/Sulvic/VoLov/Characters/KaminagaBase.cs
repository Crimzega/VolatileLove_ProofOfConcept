using Sulvic.VoLov.Characters.Info;
using Sulvic.VoLov.Controls;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sulvic.VoLov.Characters{

	public class KaminagaBase: MonoBehaviour{

		private Vector3 velocity;
		private AnimatorHandler animHandler;
		private KaminagaControls controls;
		public Personality origPersonality, personality;

		private void OnDisable(){
			controls.KeyMouse.WalkForward.performed -= OnWalkForward;
			controls.KeyMouse.WalkBackward.performed -= OnWalkBackward;
			controls.KeyMouse.Sprint.performed -= OnSprint;
		}

		private void OnEnable(){
			controls = new KaminagaControls();
			controls.KeyMouse.WalkForward.performed += OnWalkForward;
			controls.KeyMouse.WalkBackward.performed += OnWalkBackward;
			controls.KeyMouse.Sprint.performed += OnSprint;
		}

		private void Start(){
			animHandler = new AnimatorHandler(this);
			origPersonality = personality = Personality.Calm;
//			animHandler.ChangeState();
		}

		private void Update(){
		}

		private void FixedUpdate(){
			base.transform.localPosition += velocity;
		}

		public void OnWalkForward(InputAction.CallbackContext ctx){
			Vector3 vec = Vector3.forward * (ctx.performed? 2.75f: 0f);
			velocity.z += vec.z;
		}

		public void OnWalkBackward(InputAction.CallbackContext ctx){
			Vector3 vec = Vector3.forward * (ctx.performed? 2.75f: 0f);
			velocity.z += vec.z;
		}

		public void OnSprint(InputAction.CallbackContext ctx){
			float speed = ctx.performed? 2f: 1f;
			velocity.z *= speed;
		}

	}

}
