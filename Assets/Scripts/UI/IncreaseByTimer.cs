using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IncreaseByTimer : MonoBehaviour
{
    // Variables
    public TextMeshProUGUI gold;
    public float start_regen = 1f;
    public float regen_rate = 1f;

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("IncreaseGold",start_regen, regen_rate);
    }

    void IncreaseGold()
    {
        int get_amount = int.Parse(gold.text);
        get_amount += GameBalance.default_gold_regen;
        gold.text = get_amount.ToString();
    }
}
