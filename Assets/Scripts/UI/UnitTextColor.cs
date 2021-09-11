using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTextColor : MonoBehaviour
{
        TMPro.TextMeshProUGUI text;
        public TMPro.TextMeshProUGUI get_gold;
        int my_unit_cost = 50;

        // Start is called before the first frame update
        void Start()
        {
                text = this.GetComponent<TMPro.TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
                if (int.Parse(get_gold.text) < my_unit_cost)
                {
                        text.color = Color.red;
                }
                else
		{
                        text.color = Color.green;
		}
        }
}
