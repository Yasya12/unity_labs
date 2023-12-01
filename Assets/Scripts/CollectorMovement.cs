using Assets.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class CollectorMovement : MonoBehaviour, IMovement2D
{
	/*[SerializeField] private float speed;
	private Rigidbody rb;
	private float horizontal;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
	void Update()
	{
		horizontal = Input.GetAxisRaw("Horizontal");

	}

	private void FixedUpdate()
	{
		rb.velocity = new Vector3(horizontal, 0f, 0f) * speed;
	}*/


	[SerializeField] private float speed;
	[SerializeField] private float jumpingPower;
	[SerializeField] private Transform groundCheck;
	[SerializeField] private LayerMask groundLayer;
	[SerializeField] private Animator animator;

	private Rigidbody2D rb;
	private bool isFacingRight = true;
	bool IsGrounded;

	private const float GROUND_CHECK_RADIUS = 2f;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	public void Move(float horizontal, bool jumpDownBtn, bool jumpUpBtn)
	{

		if (jumpDownBtn && IsGrounded)
			rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

		if (jumpUpBtn && rb.velocity.y > 0f)
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

		rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

		bool isRunning = rb.velocity.x != 0f && horizontal != 0f && IsGrounded;
		animator.SetBool("IsRunning", isRunning);

		Flip(horizontal);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Ground"))
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

}