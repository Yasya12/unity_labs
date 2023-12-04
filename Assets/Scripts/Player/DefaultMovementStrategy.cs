using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
	public class DefaultMovementStrategy : IPlayerMovement
	{
		private readonly float speed; 

		public DefaultMovementStrategy(float speed)
		{
			this.speed = speed;
		}
		public void Move(Rigidbody2D rb, float horizontal, bool jumpDown, bool jumpUp)
		{
			rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
		}
	}

}
