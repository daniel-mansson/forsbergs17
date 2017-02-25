using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerLight : Interactable
{
	public List<Light> m_lights;
	bool m_state;
	public float m_time = 5f;

	float m_timer = 0;

	void Start ()
	{
		SetCableState(false);
		foreach (var light in m_lights)
		{
			light.enabled = false;
		}	
	}
	
	void Update ()
	{
		if (m_timer > 0f)
		{
			m_timer -= Time.deltaTime;

			if (m_timer < 0f)
			{
				SetCableState(false);
				foreach (var light in m_lights)
				{
					light.enabled = false;
				}
			}
		}	
	}

	void ResetTimer()
	{
		m_timer = m_time;

		SetCableState(true);
		foreach (var light in m_lights)
		{
			light.enabled = true;
		}
	}

	public override void OnEnter()
	{
	}

	public override void OnExit()
	{
	}

	public override void OnPressed()
	{
		ResetTimer();
	}
}
