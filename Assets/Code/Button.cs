using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
	public List<Interactable> m_targets;
	bool m_isPlayerInside = false;

	private void OnTriggerEnter(Collider other)
	{
		foreach (var target in m_targets)
		{
			target.OnEnter();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		foreach (var target in m_targets)
		{
			target.OnExit();
		}
	}

	private void Update()
	{
		if (m_isPlayerInside)
		{
			if (Input.GetButtonDown("Jump"))
			{
				foreach (var target in m_targets)
				{
					target.OnPressed();
				}
			}
		}
	}

	private void FixedUpdate()
	{
		m_isPlayerInside = false;

	}

	private void OnTriggerStay(Collider other)
	{
		//print(other.tag);
		if (other.tag == "Player")
		{
			m_isPlayerInside = true;
		}
	}
}
