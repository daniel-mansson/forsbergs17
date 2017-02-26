using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerLight : Interactable
{
	public List<Light> m_lights;
	bool m_state;
	public float m_time = 5f;

	float startIntensity;
	float m_timer = 0;

	void Start ()
	{
		SetCableState(false);
		foreach (var light in m_lights)
		{
            gameObject.SetActive(false);
        }	
	}
	
	void Update ()
	{
		if (m_timer > 0f)
		{
			m_timer -= Time.deltaTime;

			foreach (var light in m_lights)
			{
				light.intensity = startIntensity * UnityEngine.Random.Range(0.8f, 1.2f);
			}

				if (m_timer < 0f)
			{
				SetCableState(false);
				foreach (var light in m_lights)
				{
                    gameObject.SetActive(false);
                }
			}
		}	
	}

	void ResetTimer()
	{
		m_timer = m_time;

		AudioManager.Play("flicker", transform.position, 0.2f);

		SetCableState(true);
		foreach (var light in m_lights)
		{
            gameObject.SetActive(true);
            startIntensity = light.intensity;
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
