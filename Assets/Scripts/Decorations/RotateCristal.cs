using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCristal : MonoBehaviour
{
        public float rotation_speed = 0f;


    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
                this.transform.RotateAroundLocal(Vector3.up, rotation_speed);
                //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
                //this.transform.rotation = new Quaternion(this.transform.rotation.x, this.transform.rotation.y,( get_current_rotation_z + 5) % 360, this.transform.rotation.w );
                //get_current_rotation_z = get_current_rotation_z + 5;
                //Debug.Log(get_current_rotation_z % 360);
    }
}
