using System;
using UnityEngine;

namespace UI
{
    public class Billboard : MonoBehaviour
    {
        [SerializeField] private new Camera camera;

        private void Reset()
        {
            if (camera == null)
            {
                camera = Camera.main;
            }
        }

        private void Start()
        {
            Reset();
        }

        private void Update()
        {
            transform.LookAt(camera.transform);
        }
    }
}