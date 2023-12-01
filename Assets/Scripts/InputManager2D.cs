using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
	public class InputManager2D : MonoBehaviour
	{
		[SerializeField] private GameObject player;

		private IMovement2D movement;

		private float h;
		private bool jDown;
		private bool jUp;

		private void Start()
		{
			movement = player.GetComponent<IMovement2D>();
		}

		private void Update()
		{
			h = Input.GetAxisRaw("Horizontal");

			// Скидаємо значення jDown та jUp на початку кожного циклу оновлення
			/*jDown = false;
			jUp = false;*/

			if (Input.GetButtonDown("Jump"))
				jDown = true;
			if (Input.GetButtonUp("Jump"))
				jUp = true;
		}

		private void FixedUpdate()
		{
			movement.Move(h, jDown, jUp);
			jDown = false;
			jUp = false;
		}
	}

}
