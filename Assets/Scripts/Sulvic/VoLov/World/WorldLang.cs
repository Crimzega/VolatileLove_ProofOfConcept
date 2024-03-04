using UnityEngine;
using UnityEngine.Localization.Settings;

namespace Sulvic.VoLov.World{

	public class WorldLang: MonoBehaviour{

		private void Start(){ Invoke("Delay", 0.1f); }

		private void Delay(){
			int langId = PlayerPrefs.GetInt("Language");
			SetLang(langId);
		}

		public void SetLang(int langId){
			LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[langId];
			PlayerPrefs.SetInt("Language", langId);
		}

	}

}
