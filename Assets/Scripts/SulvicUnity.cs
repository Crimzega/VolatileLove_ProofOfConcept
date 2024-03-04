namespace Sulvic.Unity{

	using UnityEngine;
	using Sulvic.Util;

	public class UnityHelper{

		private static void SetActive(bool active, params GameObject[] objects){
			foreach(GameObject @object in objects) if (@object != null) @object.SetActive(active);
		}

		public static T Instantiate<T>(T obj, GameObject gameObj)
			where T: Object => Object.Instantiate<T>(obj, PositionHelper.GetPosition(gameObj), Quaternion.identity);

		public static T Instantiate<T>(T obj, MonoBehaviour behaviour)
			where T: Object => Object.Instantiate<T>(obj, PositionHelper.GetPosition(behaviour), Quaternion.identity);

		public static T Instantiate<T>(T obj, Transform transform)
			where T: Object => Object.Instantiate(obj, PositionHelper.GetPosition(transform), Quaternion.identity);

		public static T Instantiate<T>(T obj, Vector3 vec)
			where T: Object => Object.Instantiate(obj, vec, Quaternion.identity);

		public static T InstantiateInto<T>(T obj, string name)
			where T: Object => Instantiate<T>(obj, GameObject.Find(name));

//		public static T InstantiateInto<T>(T obj, string name)
//			where T: Object => Instantiate<T>(obj, GameObject.Find(name));

		public static T GetComponent<T>(string name)
			where T: Object => GameObject.Find(name).GetComponent<T>();

		public static T FindInParent<T>(Component component)
			where T: Component => component != null? component.GetComponentInParent<T>(): (T)null;

		public static Color GetRandomColor() => new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

		public static void Activate(params GameObject[][] objectsArray){ foreach(GameObject[] objects in objectsArray) Activate(objects); }

		public static void Activate(params GameObject[] objects) => SetActive(true, objects);

		public static void ActivateRange(GameObject[] objects, int start, int end) => Activate(SulvicCollections.SubArray(objects, start, end));

		public static void Deactivate(params GameObject[][] objectsArray){ foreach(GameObject[] objects in objectsArray) Deactivate(objects); }

		public static void Deactivate(params GameObject[] objects) => SetActive(false, objects);

		public static void DeactivateRange(GameObject[] objects, int start, int end) => Deactivate(SulvicCollections.SubArray(objects, start, end));

		public static void Destroy(params GameObject[][] objectsArray){ foreach(GameObject[] objects in objectsArray) Destroy(objects); }

		public static void Destroy(params GameObject[] objects){ foreach(GameObject @object in objects) if(@object != null && !@object.activeInHierarchy) GameObject.Destroy(@object); }

	}

	public static class ColorExtender{

		public static void NormalizeAlpha(this Color self) => self.a = SulvicMath.Clamp(self.a, 0f, 1f);

		public static void NormalizeBlue(this Color self) => self.r = SulvicMath.Clamp(self.b, 0f, 1f);

		public static void NormalizeGreen(this Color self) => self.r = SulvicMath.Clamp(self.g, 0f, 1f);

		public static void NormalizeRed(this Color self) => self.r = SulvicMath.Clamp(self.r, 0f, 1f);

	}

	public static class PositionExtender{

		public static void LerpW(this Quaternion self, float value, float timeScale) => self.w = Mathf.Lerp(self.w, value, timeScale);

		public static void LerpX(this Quaternion self, float value, float timeScale) => self.x = Mathf.Lerp(self.x, value, timeScale);

		public static void LerpX(this Vector3 self, float value, float timeScale) => self.x = Mathf.Lerp(self.x, value, timeScale);

		public static void LerpY(this Quaternion self, float value, float timeScale) => self.y = Mathf.Lerp(self.y, value, timeScale);

		public static void LerpY(this Vector3 self, float value, float timeScale) => self.y = Mathf.Lerp(self.y, value, timeScale);

		public static void LerpZ(this Quaternion self, float value, float timeScale) => self.z = Mathf.Lerp(self.z, value, timeScale);

		public static void LerpZ(this Vector3 self, float value, float timeScale) => self.z = Mathf.Lerp(self.z, value, timeScale);
		
		public static void ClampMaxW(this Quaternion self, float value){ if(self.w > value) self.w = value; }

		public static void ClampMaxEqualW(this Quaternion self, float value){ if(self.w >= value) self.w = value; }

		public static void ClampMaxX(this Quaternion self, float value){ if(self.x > value) self.x = value; }

		public static void ClampMaxX(this Vector3 self, float value){ if(self.x > value) self.x = value; }

		public static void ClampMaxEqualX(this Quaternion self, float value){ if(self.x >= value) self.x = value; }

		public static void ClampMaxEqualX(this Vector3 self, float value){ if(self.x >= value) self.x = value; }

		public static void ClampMaxY(this Quaternion self, float value){ if(self.y > value) self.y = value; }

		public static void ClampMaxY(this Vector3 self, float value){ if(self.y > value) self.y = value; }

		public static void ClampMaxEqualY(this Quaternion self, float value){ if(self.y >= value) self.y = value; }

		public static void ClampMaxEqualY(this Vector3 self, float value){ if(self.y >= value) self.y = value; }

		public static void ClampMaxZ(this Quaternion self, float value){ if(self.z > value) self.z = value; }

		public static void ClampMaxZ(this Vector3 self, float value){ if(self.z > value) self.z = value; }

		public static void ClampMaxEqualZ(this Quaternion self, float value){ if(self.z >= value) self.z = value; }

		public static void ClampMaxEqualZ(this Vector3 self, float value){ if(self.z >= value) self.z = value; }

		public static void ClampMinW(this Quaternion self, float value){ if(self.w < value) self.w = value; }

		public static void ClampMinEqualW(this Quaternion self, float value){ if(self.w <= value) self.w = value; }

		public static void ClampMinX(this Quaternion self, float value){ if(self.x < value) self.x = value; }

		public static void ClampMinX(this Vector3 self, float value){ if(self.x < value) self.x = value; }

		public static void ClampMinEqualX(this Quaternion self, float value){ if(self.x <= value) self.x = value; }

		public static void ClampMinEqualX(this Vector3 self, float value){ if(self.x <= value) self.x = value; }

		public static void ClampMinY(this Quaternion self, float value){ if(self.y < value) self.y = value; }

		public static void ClampMinY(this Vector3 self, float value){ if(self.y < value) self.y = value; }

		public static void ClampMinEqualY(this Quaternion self, float value){ if(self.y <= value) self.y = value; }

		public static void ClampMinEqualY(this Vector3 self, float value){ if(self.y <= value) self.y = value; }

		public static void ClampMinZ(this Quaternion self, float value){ if(self.z < value) self.z = value; }

		public static void ClampMinZ(this Vector3 self, float value){ if(self.z < value) self.z = value; }

		public static void ClampMinEqualZ(this Quaternion self, float value){ if(self.z <= value) self.z = value; }

		public static void ClampMinEqualZ(this Vector3 self, float value){ if(self.z <= value) self.z = value; }

	}

	public class PositionHelper{

		public static Transform GetTransform(GameObject obj) => obj.transform;

		public static Transform GetTransform(Component component) => component.transform;

		public static Quaternion GetLocalRotation(GameObject obj) => GetLocalRotation(GetTransform(obj));

		public static Quaternion GetLocalRotation(Component component) => GetLocalRotation(GetTransform(component));

		public static Quaternion GetLocalRotation(Transform transform) => transform.localRotation;

		public static Quaternion GetRotation(GameObject obj) => GetRotation(GetTransform(obj));

		public static Quaternion GetRotation(Component component) => GetRotation(GetTransform(component));

		public static Quaternion GetRotation(Transform transform) => transform.rotation;

		public static Vector3 GetLocalPosition(GameObject obj) => GetLocalPosition(GetTransform(obj));

		public static Vector3 GetLocalPosition(Component component) => GetLocalPosition(GetTransform(component));

		public static Vector3 GetLocalPosition(Transform transform) => transform.localPosition;

		public static Vector2 GetLocalScale(GameObject obj) => GetLocalScale(GetTransform(obj));

		public static Vector3 GetLocalScale(Component component) => GetLocalScale(GetTransform(component));

		public static Vector3 GetLocalScale(Transform transform) => transform.localScale;

		public static Vector3 GetPosition(GameObject obj) => GetPosition(GetTransform(obj));

		public static Vector3 GetPosition(Component component) => GetPosition(GetTransform(component));

		public static Vector3 GetPosition(Transform transform) => transform.position;

		public static Vector3 MoveTowards(Transform from, Transform to, Vector3 offset, float timeScale) =>
			Vector3.MoveTowards(GetPosition(from), GetPosition(to) + offset, timeScale);

	}

}
