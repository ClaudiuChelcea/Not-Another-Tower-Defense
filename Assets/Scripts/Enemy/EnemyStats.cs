using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int towerSide;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TowerSide>() != null)
        {
            this.towerSide = other.GetComponent<TowerSide>().side;
        }
    }
}
