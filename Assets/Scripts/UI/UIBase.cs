using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UIBase : MonoBehaviour {

    private event UGUIDelegate OnEnterEvent;

    private event UGUIDelegate OnExitEvent;
    protected virtual void Awake()
    {

    }
	// Use this for initialization
	protected virtual void Start () {
		
	}

    protected virtual void OnEnable()
    {

    }
	// Update is called once per frame
	protected virtual void Update () {
		
	}

    protected virtual void OnDisable()
    {

    }

    protected virtual void OnDestroy()
    {

    }

    public virtual void OnEnter()
    {
        if (OnEnterEvent != null)
        {
            OnEnterEvent();
        }
        OnExitEvent = null;
        this.gameObject.SetActive(true);
    }

    public virtual void OnExit()
    {
        if(OnExitEvent != null)
        {
            OnExitEvent();
        }
        OnExitEvent = null;
        this.gameObject.SetActive(false);
    }

    public void AddEnterEvent(UGUIDelegate action)
    {
        OnEnterEvent += action;
    }

    public void AddExitEvent(UGUIDelegate action)
    {
        OnExitEvent += action;
    }
}
