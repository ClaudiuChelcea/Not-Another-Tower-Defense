using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeUItext : MonoBehaviour
{
        Text my_text;

        // Start is called before the first frame update
        void Start()
        {
                my_text = GetComponent<Text>();
        }

        // Update is called once per frame
        public void textUpdate(float value)
        {
                my_text.text = "UI: " + Mathf.RoundToInt(value * 100) + "%";
        }
}
