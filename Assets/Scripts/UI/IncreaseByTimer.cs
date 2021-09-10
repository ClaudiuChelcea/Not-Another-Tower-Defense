using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class IncreaseByTimer : MonoBehaviour
{
    // Variables
    public TextMeshProUGUI gold;
    public float start_regen_after_scene_delay = 1f;
    public float regen_rate_interval = 3f;
    private int regeneration_amount;
    private int default_regen = 2;

    // Update is called once per frame
    void Awake()
    {
        InvokeRepeating("IncreaseGold",start_regen_after_scene_delay, regen_rate_interval);
    }

    void IncreaseGold()
    {
        int get_amount = int.Parse(gold.text);
        get_amount += regeneration_amount;
        gold.text = get_amount.ToString();
    }

    private void Start()
    {
        regeneration_amount = GameBalance.default_gold_regen;

        // For testing purpose
        if (regeneration_amount == 0)
        {
            if (File.Exists("Assets/User/GoldRegen.txt"))
                regeneration_amount = int.Parse(File.ReadAllText("Assets/User/GoldRegen.txt"));
            else
            {
                regeneration_amount = default_regen;
            }
        }
    }
}
