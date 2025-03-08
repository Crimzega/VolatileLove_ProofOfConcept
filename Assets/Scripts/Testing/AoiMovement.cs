using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Sulvic.VoLov.Constants;

namespace Testing
{

	public class AoiMovement : MonoBehaviour
	{

        private Animator animator;
        private AoiControls controls;
        private bool isCrouching, isSprinting;
        private float movePos;
        private GameObject mainCharacter;
		private Camera camera;
        private Vector2 moveCamera;

		private void Awake(){
			controls = new AoiControls();
			controls.Enable();
			controls.Movement.MovePlayer.performed += OnMovePlayer;
			controls.Movement.Crouch.performed += OnCrouch;
			controls.Movement.Sprint.performed += OnSprint;
			controls.Movement.MoveCamera.performed += OnMoveCamera;
		}

		private void FixedUpdate(){
			if(movePos > 0f){
				if(isCrouching) animator.Play(isSprinting? AnimatorNames.KAMINAGA_CROUCH_SPRINT: AnimatorNames.KAMINAGA_CROUCH_FORWARD);
				else animator.Play(isSprinting? AnimatorNames.KAMINAGA_SPRINT: AnimatorNames.KAMINAGA_FORWARD);
			}
			else{
				if(isCrouching) animator.Play(AnimatorNames.KAMINAGA_CROUCH);
				else animator.Play(AnimatorNames.KAMINAGA_IDLE);
			}
			camera.transform.Rotate(moveCamera.x * Time.deltaTime, moveCamera.y * Time.deltaTime, 0f);
        }

        private void OnCrouch(InputAction.CallbackContext ctx) => isCrouching = !isCrouching;

		private void OnMoveCamera(InputAction.CallbackContext ctx) => moveCamera = ctx.ReadValue<Vector2>();

        private void OnMovePlayer(InputAction.CallbackContext ctx) => movePos = ctx.ReadValue<float>();

		private void OnSprint(InputAction.CallbackContext ctx) => isSprinting = ctx.performed;

		private void Start(){
			animator = gameObject.GetComponent<Animator>();
		}

	}

}
