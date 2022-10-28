using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class ViewerBasic : MonoBehaviour
{
	private InputMaster playerControls;
	public float mouseSensitivity;
	public float movementSpeed;
	

	Camera viewCam;
	CharacterController controller;
	Transform t;

	float verticalRotation = 0f;

	float gravity = -9.7f;
	bool grounded = false;
	Vector3 velocity;
	public LayerMask ground;

	void Awake()
	{
		playerControls = new InputMaster();
		viewCam = GetComponentInChildren<Camera>();
		controller = GetComponent<CharacterController>();
		t = transform;
	}

    private void OnEnable()
    {
		playerControls.Enable();
    }

    private void OnDisable()
    {
		playerControls.Disable();
    }
    void Start()
	{
		Cursor.visible = false;
		//Cursor.lockState = CursorLockMode.Locked;
	}

	void Update()
	{
		Vector2 mouse = playerControls.Player.look.ReadValue<Vector2>();
		

        t.Rotate(Vector3.up * mouse.x);
        verticalRotation -= mouse.y;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        viewCam.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

		Vector2 wasd = playerControls.Player.move.ReadValue<Vector2>();
		Vector3 movement = viewCam.transform.forward * wasd.y + viewCam.transform.right * wasd.x;
		controller.Move(movement * movementSpeed * Time.deltaTime);
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);

		grounded = groundCheck();
		if (grounded && velocity.y < 0f)
        {
			velocity.y = 0f;
        }
	}

	bool groundCheck()
	{
		Collider[] c = Physics.OverlapSphere(transform.position, .2f, ground);
		if (c.Length > 0)
		{
			return true;
		}
		return false;
	}




}
