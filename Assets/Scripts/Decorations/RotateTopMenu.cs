using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTopMenu : MonoBehaviour
{
	public float rotation_speed = 0f;

	private void OnMouseDrag()
	{
		float zAxis = Input.GetAxis("Mouse Y") * rotation_speed;

		 transform.RotateAround(transform.position, Vector3.up, rotation_speed * Time.deltaTime);
	}
}
