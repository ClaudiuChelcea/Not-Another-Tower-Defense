using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject tower;
    public float rotationSpeed = 40f;
    public float moveSpeed = 20f;
    new Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotDir = Input.GetAxisRaw("Horizontal");
        float moveDir = Input.GetAxisRaw("Vertical");
        float zoom = Input.GetAxis("Mouse ScrollWheel");

        transform.RotateAround(tower.transform.position, Vector3.up, -rotDir * rotationSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * moveDir * moveSpeed * Time.deltaTime, Space.World);
        camera.orthographicSize -= zoom * 2;
    }
}
