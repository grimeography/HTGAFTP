using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
	public float mouseSensitivity;
	public float movementSpeed;
	public LayerMask ground;

	Camera viewCam;
	CharacterController controller;
	Transform t;


	float verticalRotation = 0f;

	float gravity = -5f;

	Vector3 velocity;


	void Awake()
	{
		viewCam = GetComponentInChildren<Camera>();
		controller = GetComponent<CharacterController>();
		t = transform;

	}

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update()
	{
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

		t.Rotate(Vector3.up * mouseX);
		verticalRotation -= mouseY;
		verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
		viewCam.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector3 movement = t.right * horizontal + t.forward * vertical;
		controller.Move(movement * movementSpeed * Time.deltaTime);

		velocity.y += gravity * Time.deltaTime;

		controller.Move(velocity * Time.deltaTime);
	}


}
