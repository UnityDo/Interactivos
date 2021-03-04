using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactivo : MonoBehaviour {

    public event Action OnOver;             
    public event Action OnOut;
    Interactivo interactivo_actual;
	public int tipo;
    protected bool m_IsOver;
    public bool IsOver
    {
        get { return m_IsOver; }              // Is the gaze currently over this object?
    }
    // Use this for initialization
    public void Over()
    {
        m_IsOver = true;

        if (OnOver != null)
            OnOver();
    }


    public void Out()
    {
        m_IsOver = false;

        if (OnOut != null)
            OnOut();
    }
    public Interactivo objeto
	{
		get { return interactivo_actual; }
	}
}
