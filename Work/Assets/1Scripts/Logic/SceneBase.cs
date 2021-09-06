using UnityEngine;


public class Scene_Base : Singleton<Scene_Base>
{
	//
	protected GameObject _gbj = null;


	//
	bool _isPause = false;


	/// <summary>
	/// 
	/// </summary>
	protected override void Awake()
	{
		//
		base.Awake();

		//
		useGUILayout = false;

		//
		_gbj = gameObject;

	}

	/// <summary>
	/// 
	/// </summary>
	protected override void OnDestroy()
	{
		//
		base.OnDestroy();

	}

	/// <summary>
	/// 
	/// </summary>
#if UNITY_EDITOR
	protected virtual void OnApplicationPause(bool pause)
	{
#elif UNITY_ANDROID
	protected virtual void OnApplicationPause(bool pause)
	{
#elif UNITY_IPHONE
	protected virtual void OnApplicationFocus(bool focus)
	{
		bool pause = !focus;
#endif
		//
		if (pause == true)
		{
			//
			_isPause = true;

		}
		else
		{
			if (_isPause == false)
				return;

			//
			_isPause = false;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	private void OnApplicationQuit()
	{

	}
}
