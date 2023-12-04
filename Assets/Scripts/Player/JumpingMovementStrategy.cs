using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
	public class JumpingMovementStrategy : IPlayerMovement
	{
		private float jumpingPower; 
		private bool IsGrounded;

		public JumpingMovementStrategy(float jumpingPower, bool isGrounded)
		{
			this.jumpingPower = jumpingPower;
			this.IsGrounded = isGrounded;
		}

		public void Move(Rigidbody2D rb, float horizontal, bool jumpDown, bool jumpUp)
		{
			if (jumpDown && IsGrounded)
			{
				rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
			}

			if (jumpUp && rb.velocity.y > 0f)
				rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

			rb.velocity = new Vector2(horizontal, rb.velocity.y);


		}
	}
}
