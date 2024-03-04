using System;
using Sulvic.VoLov.Controls;
using UnityEngine;

namespace Sulvic.VoLov.Characters{

	public class DummyCharacter: StudentBase{

		private AnimatorHandler animHandler;

		private void OnEnable(){
			animHandler = new AnimatorHandler(this);
		}

		private void Start(){
			animHandler.ChangeState("Idle");
		}

	}

}