using Assets.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerController : MonoBehaviour, IPlayerMovement
	{
		[SerializeField] private float speed;
		[SerializeField] private float jumpingPower;
		[SerializeField] private Transform groundCheck;
		[SerializeField] private LayerMask groundLayer;
		[SerializeField] private Animator animator;
		[SerializeField] private AudioSource jumpSoundEffect;

		private Rigidbody2D rb;
		private bool isFacingRight = true;
		bool IsGrounded;

		private IPlayerMovement movementStrategy;

		private void Awake()
		{
			rb = GetComponent<Rigidbody2D>();
			movementStrategy = new DefaultMovementStrategy(speed);
		}


		public void SetMovementStrategy(IPlayerMovement strategy)
		{
			movementStrategy = strategy;
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.gameObject.CompareTag("Ground"))
			{
				IsGrounded = true;
			}
		}

		private void OnCollisionExit2D(Collision2D collision)
		{
			if (collision.gameObject.CompareTag("Ground"))
			{
				IsGrounded = false;
			}
		}

		private void Flip(float horizontal)
		{
			if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
			{
				isFacingRight = !isFacingRight;

				var localScale = transform.localScale;
				localScale.x *= -1;
				transform.localScale = localScale;
			}
		}

		public void Move(Rigidbody2D rb, float horizontal, bool jumpDown, bool jumpUp)
		{
			if (jumpDown)
			{
                jumpSoundEffect.Play();
                movementStrategy = new JumpingMovementStrategy(jumpingPower, IsGrounded);
			}

			movementStrategy.Move(rb, horizontal, jumpDown, jumpUp);
			movementStrategy = new DefaultMovementStrategy(speed);

			if (!(movementStrategy is JumpingMovementStrategy))
			{
				movementStrategy.Move(rb, horizontal, jumpDown, jumpUp);
			}

			bool isRunning = rb.velocity.x != 0f && horizontal != 0f && IsGrounded;
			animator.SetBool("IsRunning", isRunning);

			Flip(horizontal);
		}
	}
}