using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
        public Color hoverColor;
        public Vector3 positionOffset;
        public TMPro.TextMeshProUGUI get_gold;
        private GameObject unit;

        private Renderer rend;
        private Color startColor;


        private void Start()
        {
                rend = GetComponent<Renderer>();
                startColor = rend.material.color;
        }

        private void OnMouseDown()
        {
                // Must click on UI first
                if (UnitPlacementManager.unit_is_selected == false)
                        return;

                if (unit != null)
                {
                        Debug.Log("Cant't place unit here!");
                        return;
                }

                if (int.Parse(get_gold.text) < 50)
                {
                        Debug.Log("Not enough gold for this unit!");
                        return;
                }

                GameObject unitToPlace = UnitPlacementManager.instance.GetUnitToPlace();
                unit = (GameObject)Instantiate(unitToPlace, transform.position + positionOffset, transform.rotation);
                get_gold.text = (int.Parse(get_gold.text) - 50).ToString() ;
                UnitPlacementManager.unit_is_selected = false;
        }

        private void OnMouseEnter()
        {
                if (unit == null)
                        rend.material.color = hoverColor;
                else
                        return;
        }

        private void OnMouseExit()
        {
                rend.material.color = startColor;
        }
}
