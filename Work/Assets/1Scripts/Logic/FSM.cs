using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public class FSMState
{
	//
	public Type pID { private set; get; }

	//
	protected FSM pFSM { private set; get; }

	//
	protected FSMState(FSM fsm, Type ID)
	{
		pFSM = fsm;
		pID = ID;
	}

	//
	public virtual void Init()
	{
	}

	//
	public virtual void Enter(params object[] parameters)
	{
	}

	//
	public virtual void Exit()
	{
	}

	//
	public virtual void Tick()
	{
	}

	//
	public virtual void Tick_Late()
	{
	}

	//
	public virtual void Tick_Slow()
	{
	}

	//
	public virtual void Tick_Sec()
	{
	}

	//
	public virtual void Tick_Min()
	{
	}
};


/// <summary>
/// 
/// </summary>
public class FSM
{
	//
	protected Dictionary<Type, FSMState> pStates { private set; get; } = new Dictionary<Type, FSMState>();

	//
	public GameObject pGbj { private set; get; }
	public Transform pTrans { private set; get; }

	//
	FSMState _currentState = null;
	FSMState _previousState = null;


	/// <summary>
	/// 
	/// </summary>
	public void SetGbjAndTrans(GameObject gbj, Transform trans)
	{
		pGbj = gbj;
		pTrans = trans;
	}

	/// <summary>
	/// 
	/// </summary>
	public Type GetCurrentStateID()
	{
		//
		if (_currentState == null)
			return null;

		//
		return _currentState.pID;
	}

	/// <summary>
	/// 
	/// </summary>
	public FSMState GetState(Type id)
	{
		if (pStates.ContainsKey(id) == true)
			return pStates[id];

		return null;
	}

	/// <summary>
	/// 
	/// </summary>
	public FSMState GetCurrentState()
	{
		return _currentState;
	}

	/// <summary>
	/// 
	/// </summary>
	public Type GetPreviousStateID()
	{
		return _previousState.pID;
	}

	/// <summary>
	/// 
	/// </summary>
	public FSMState GetPreviousState()
	{
		return _previousState;
	}

	/// <summary>
	/// 
	/// </summary>
	public void AddState(FSMState newState)
	{
		//check for state null reference before deleting
		if (newState == null)
		{
			Debug.LogError("FSM ERROR: state null reference is not allowed");
			return;
		}

		//check for contains
		if (pStates.ContainsKey(newState.pID) == true)
		{
			Debug.LogError("FSM ERROR: Impossible to add state '" + newState.pID + "' because state has already been added");
			return;
		}

		//add
		pStates.Add(newState.pID, newState);
	}

	/// <summary>
	/// 
	/// </summary>
	public void RemoveState(Type Id)
	{
		// Search the List and delete the state if it's inside it
		if (pStates.ContainsKey(Id) == false)
		{
			Debug.LogError("FSM ERROR: Impossible to delete state '" + Id + "'. It was not on the list of stateList");
			return;
		}

		//
		if (pStates[Id] == _currentState)
			pStates[Id].Exit();

		//
		pStates.Remove(Id);
	}

	/// <summary>
	/// 
	/// </summary>
	public void RemoveAllState()
	{
		foreach (var kvp in pStates)
		{
			if (kvp.Value == _currentState)
				kvp.Value.Exit();
		}

		pStates.Clear();

		_currentState = null;
		_previousState = null;
	}

	/// <summary>
	/// 
	/// </summary>
	public void InitStates()
	{
		foreach (var kvp in pStates)
			kvp.Value.Init();
	}

	/// <summary>
	/// 
	/// </summary>
	public void ChangeState(Type id, bool isOverrab = true, params object[] parameters)
	{
		//
		if (pStates.ContainsKey(id) == false)
		{
			Debug.LogError("FSM ERROR: Impossible to add transition state '" + id + "'. It was not on the list of stateList");
			return;
		}

		//
		if (isOverrab == false && _currentState != null && _currentState.pID.Equals(id) == true)
			return;

		//
		if (_currentState != null)
			_currentState.Exit();

		//
		_previousState = _currentState;
		_currentState = pStates[id];

#if UNITY_EDITOR
		//if (_currentState.GetComponent<Monster>() != null)
		//	EditorDebug.Log("name = " + _currentState.name + ", fsm chanced, name = " + _currentState.name + ", id = " + id);
#endif
		//
		_currentState.Enter(parameters);
	}

}
