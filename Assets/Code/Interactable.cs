using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
	public GameObject m_cableRoot;
	public Material m_onMat;
	public Material m_offMat;

	public abstract void OnPressed();
	public abstract void OnEnter();
	public abstract void OnExit();

	public void SetCableState(bool state)
	{
		var renderers =  m_cableRoot.GetComponentsInChildren<MeshRenderer>();
		foreach (var renderer in renderers)
		{
			renderer.material = state ? m_onMat : m_offMat;
		}
	}
}
