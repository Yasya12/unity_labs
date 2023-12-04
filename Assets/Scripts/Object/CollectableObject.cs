using Assets.Scripts.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour, ICollectable
{
	private Action onCollect;
	private Action onNotCollect;
	public void Initialize(Action onCollect, Action onNotCollect)
	{
		this.onCollect = onCollect;
		this.onNotCollect = onNotCollect;
	}

	public void Collect()
	{
		onCollect?.Invoke();
		Destroy(gameObject);
	}

	public void OnNotCollect()
	{
		onNotCollect?.Invoke();
		Destroy(gameObject);
	}
}
