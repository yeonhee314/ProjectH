using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Scene_Game : Scene_Base
{
	//
	FSM _fsm = new FSM();

	//
	float _sleepModeTime = 0f;

	//
	double _realtimeSinceStartup = 0;


	/// <summary>
	/// 
	/// </summary>
	protected override void Awake()
	{
		//
		base.Awake();

		//
		InitStates();

		//
		_realtimeSinceStartup = Time.realtimeSinceStartup;
	}

	/// <summary>
	/// 
	/// </summary>
	public System.Type GetCurState()
	{
		return _fsm.GetCurrentStateID();
	}

	/// <summary>
	/// 상태들 초기화
	/// </summary>
	void InitStates()
	{
		//
		_fsm.RemoveAllState();

		//
		_fsm.SetGbjAndTrans(gameObject, transform);


		//
		_fsm.InitStates();
	}

	/// <summary>
	/// 
	/// </summary>
	void Start()
	{

	}

	protected override void OnApplicationPause(bool pause)
	{
		//
		base.OnApplicationPause(pause);

		//
		if (pause == true)
		{
			//
			_sleepModeTime = Time.realtimeSinceStartup;
		}
		else
		{

		}
	}
}
