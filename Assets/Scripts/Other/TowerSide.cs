using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSide : MonoBehaviour
{
    public int side;

    // Start is called before the first frame update
    void Start()
    {
        this.side =  (int)char.GetNumericValue(transform.name[transform.name.Length - 1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
