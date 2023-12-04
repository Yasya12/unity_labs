using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
	public class PlayerInputController : MonoBehaviour
	{
		[SerializeField] private GameObject player;
		private IPlayerMovement movement;

		private float horizontal;
		private bool jumpDown;
		private bool jumpUp;

		private void Start()
		{
			movement = player.GetComponent<IPlayerMovement>();
		}

		private void Update()
		{
			horizontal = Input.GetAxisRaw("Horizontal");
			if(jumpDown == false)
			{
				jumpDown = Input.GetButtonDown("Jump");
			}

			if (jumpUp == false)
			{
				jumpUp = Input.GetButtonUp("Jump");
			}
		}

		private void FixedUpdate()
		{
			Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
			movement.Move(playerRb, horizontal, jumpDown, jumpUp);
			jumpDown = false;
			jumpUp = false;
		}
	}
}
