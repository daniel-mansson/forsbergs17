using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Interactable {
    public Vector3 closedPos;
    public Vector3 openPos;

    public float lerpTime = 0.7f;
    public bool IsOpen;
	public bool IsLerping = false;
	public bool m_defaultState;

    float currentLerpTime;

    void Start ()
	{
		IsOpen = m_defaultState;

		if (IsOpen)
		{
			transform.localPosition = openPos;
		}
		else
		{
			transform.localPosition = closedPos;
		}

		SetCableState(IsOpen);
	}
	
	void Update ()
	{
		if (IsLerping == true)
		{
			//increment timer once per frame
			currentLerpTime += Time.deltaTime;
			if (currentLerpTime > lerpTime)
			{
				currentLerpTime = lerpTime;
				IsLerping = false;
			}

			//lerp!
			float perc = currentLerpTime / lerpTime;

			if (IsOpen)
			{
				transform.localPosition = Vector3.Lerp(closedPos, openPos, perc);
			}
			else
			{
				transform.localPosition = Vector3.Lerp(openPos, closedPos, perc);
			}
		}
    }
    
 
    public void ToggleOpen() {
		//transform.position = IsOpen ? closedPos : openPos;
		if (!IsLerping)
		{
			IsOpen = !IsOpen;
			IsLerping = true;

			if (IsOpen)
			{
				AudioManager.Play("open", transform.position, 1f);
			}
			else
			{
				AudioManager.Play("close", transform.position, 1f);
			}

			currentLerpTime = 0f;
			SetCableState(IsOpen);
		}
	}

	public override void OnPressed()
	{
		ToggleOpen();
	}

	public override void OnEnter()
	{
		//Maybe turn on some indication
	}

	public override void OnExit()
	{
		//Maybe turn off some indication
	}
}
