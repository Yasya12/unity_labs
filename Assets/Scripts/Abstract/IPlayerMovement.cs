using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
	public interface IPlayerMovement
	{
		void Move(Rigidbody2D rb, float horizontal, bool jumpDown, bool jumpUp);
	}
}
