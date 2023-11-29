using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CollectorMovement : MonoBehaviour
{
	[SerializeField] private float speed;
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
	}
}