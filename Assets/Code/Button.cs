using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
	public List<Interactable> m_targets;

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

	private void OnTriggerStay(Collider other)
	{
		//print(other.tag);
		if (other.tag == "Player")
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
}
