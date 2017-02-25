﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : Interactable
{
	public List<Light> m_lights;
	public bool m_state;

	public override void OnEnter()
	{
	}

	public override void OnExit()
	{
	}

	public override void OnPressed()
	{
		Toggle();
	}

	[ContextMenu("Toggle")]
	void Toggle()
	{
		m_state = !m_state;
		foreach (var light in m_lights)
		{
			light.enabled = m_state;
		}

		SetCableState(m_state);
	}

	void Start ()
	{
		foreach (var light in m_lights)
		{
			light.enabled = m_state;
		}

		SetCableState(m_state);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
