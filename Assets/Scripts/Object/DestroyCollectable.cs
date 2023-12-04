using Assets.Scripts.Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollectable : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent<ICollectable>(out var clickable))
		{
			clickable.OnNotCollect();
		}
	}
}
