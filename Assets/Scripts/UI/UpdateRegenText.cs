using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class UpdateRegenText : MonoBehaviour
{
    public TextMeshProUGUI get_text;
    private const int default_regen = 2;

    // Start is called before the first frame update
    void Start()
    {
        int value = GameBalance.default_gold_regen;

        // For testing purpose
        if (value == 0)
        {
            if (File.Exists("Assets/User/GoldRegen.txt"))
                value = int.Parse(File.ReadAllText("Assets/User/GoldRegen.txt"));
            else
            {
                value = default_regen;
            }
        }

        get_text.text = value.ToString();
    }
}
