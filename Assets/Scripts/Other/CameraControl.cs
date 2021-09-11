using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject tower;
    public float rotationSpeed = 40f;
    public float moveSpeed = 20f;
    new Camera camera;
    private float max_zoom;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        max_zoom = camera.orthographicSize;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float rotDir = Input.GetAxisRaw("Horizontal");
        float moveDir = Input.GetAxisRaw("Vertical");
        float zoom = Input.GetAxis("Mouse ScrollWheel");

        transform.RotateAround(tower.transform.position, Vector3.up, -rotDir * rotationSpeed * Time.deltaTime);
        // transform.Translate(Vector3.up * moveDir * moveSpeed * Time.deltaTime, Space.World);
       if(zoom > 0 || zoom < 0 && camera.orthographicSize < max_zoom)
           camera.orthographicSize -= zoom * 4;
    }
}
