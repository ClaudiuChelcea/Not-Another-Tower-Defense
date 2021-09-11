using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using System.Net.Configuration;
using UnityEngine.Rendering;

public class GameBalance : MonoBehaviour
{
    // Variables
    // Diamonds related variables
    public static int starter_balance = 0;
    private const int DEFAULT_BALANCE = 20;

    // File related variables
    private string fileName = "Assets/User/Balance.txt";
    private string fileNameGold = "Assets/User/GoldRegen.txt";
    private string fileNameHealth = "Assets/User/Health.txt";

    // UI related variables
    public TextMeshProUGUI currency_text;
    public TextMeshProUGUI gold_LEVEL;
    public TextMeshProUGUI LIVES;
    public GameObject cannot_upgrade_anymore, cannot_deupgrade_anymore, cant_afford;
    public TextMeshProUGUI gold_price, health_price;

    // Gold related variables
    public static int default_gold_regen = 0;
    private const int DEFAULT_GOLD = 2;
    private const int gold_upgrade_cost = 10;
    private const int gold_deupgrade_cost = -5;

    // Health related variables
    public static int lives = 20;
    private const int DEFAULT_LIVES = 20;
    private const int health_upgrade_cost = 15;
    private const int health_deupgrade_cost = -10;

    // Start is called before the first frame update
    void Start()
    {
        CreateStarterCurrencyFile();
        CreateStarterGoldFile();
        CreateStarterHealthFile();
        ColorHealthUpgradeAvailability();
        ColorGoldUpgradeAvailability();
    }

    // Create starter lives file
    private void CreateStarterHealthFile()
    {
        if (File.Exists(fileNameHealth))
        {
            lives = int.Parse(File.ReadAllText((fileNameHealth)));
            LIVES.text = lives.ToString();
        }
        else
        {
            File.WriteAllText(fileNameHealth, DEFAULT_LIVES.ToString());
            lives = DEFAULT_LIVES;
            LIVES.text = lives.ToString();
        }
    }

    // Create starter gold file
    private void CreateStarterGoldFile()
    {
        if (File.Exists(fileNameGold))
        {
            default_gold_regen = int.Parse(File.ReadAllText((fileNameGold)));
            gold_LEVEL.text = default_gold_regen.ToString();
        }
        else
        {
            File.WriteAllText(fileNameGold, DEFAULT_GOLD.ToString());
            default_gold_regen = DEFAULT_GOLD;
            gold_LEVEL.text = default_gold_regen.ToString();
        }
    }

    // Default currency
    private void CreateStarterCurrencyFile()
    {
        if (File.Exists(fileName))
        {
            starter_balance = int.Parse(File.ReadAllText((fileName)));
        }
        else
        {
            File.WriteAllText(fileName, DEFAULT_BALANCE.ToString());
            starter_balance = DEFAULT_BALANCE;
        }

        if(currency_text)
            currency_text.text = starter_balance.ToString();
    }

    // Increase default gold regen
    public void increaseGoldRegen()
    {
        if (default_gold_regen == 5)
        {
            cannot_upgrade_anymore.SetActive(true);
            return;
        }

        if (starter_balance >= gold_upgrade_cost)
            starter_balance -= gold_upgrade_cost;
        else
        {
            cant_afford.SetActive(true);
            return;
        }

        if (default_gold_regen == 2)
        {
            default_gold_regen = 3;
        }
        else if (default_gold_regen == 3)
        {
            default_gold_regen = 4;
        }
        else if (default_gold_regen == 4)
        {
            default_gold_regen = 5; ;
        }

        UpdateGOLDUI();
    }

    // Decrease default gold regen
    public void DecreaseGoldRegen()
    {
        if (default_gold_regen == 2)
        {
            cannot_deupgrade_anymore.SetActive(true);
            return;
        }

        starter_balance -= gold_deupgrade_cost;

        if (default_gold_regen == 3)
        {
            default_gold_regen = 2;
        }
        else if (default_gold_regen == 4)
        {
            default_gold_regen = 3;
        }
        else if (default_gold_regen == 5)
        {
            default_gold_regen = 4;
        }

        UpdateGOLDUI();
    }

    // Keep UI up to date with gold increase / decrease
    private void UpdateGOLDUI()
    {
        // Update diamonds
        File.Delete(fileName);
        File.WriteAllText(fileName, starter_balance.ToString());
        currency_text.text = starter_balance.ToString();

        // Update gold
        File.Delete(fileNameGold);
        File.WriteAllText(fileNameGold, default_gold_regen.ToString());
        gold_LEVEL.text = default_gold_regen.ToString();

        ColorGoldUpgradeAvailability();
        ColorHealthUpgradeAvailability();
    }

    // increase lives
    public void IncreaseLives()
    {
        if (lives == 50)
        {
            cannot_upgrade_anymore.SetActive(true);
            return;
        }

        if(starter_balance >= health_upgrade_cost)
            starter_balance -= health_upgrade_cost;
        else
        {
            cant_afford.SetActive(true);
            return;
        }

        if (lives == 20)
            lives = 30;

        else if (lives == 30)
            lives = 40;

        else if (lives == 40)
            lives = 50;

        UpdateLivesUI();
    }

    // Decrease lives
    public void DecreaseLives()
    {
        if (lives == 20)
        {
            cannot_deupgrade_anymore.SetActive(true);
            return;
        }

        starter_balance -= health_deupgrade_cost;

        if (lives == 30)
            lives = 20;

        else if (lives == 40)
            lives = 30;

        else if (lives == 50)
            lives = 40;

        UpdateLivesUI();
    }

    // Keep UI up to date with health count changes
    private void UpdateLivesUI()
    {
        File.Delete(fileName);
        File.WriteAllText(fileName, starter_balance.ToString());
        currency_text.text = starter_balance.ToString();

        File.Delete(fileNameHealth);
        File.WriteAllText(fileNameHealth, lives.ToString());
        LIVES.text = lives.ToString();

        ColorHealthUpgradeAvailability();
        ColorGoldUpgradeAvailability();
    }

    private void ColorHealthUpgradeAvailability()
    {
        if (starter_balance >= health_upgrade_cost)
        {
            health_price.color = Color.green;
        }
        else
        {
            health_price.color = Color.red;
        }
    }

    private void ColorGoldUpgradeAvailability()
    {
        if (starter_balance >= gold_upgrade_cost)
        {
            gold_price.color = Color.green;
        }
        else
        {
            gold_price.color = Color.red;
        }
    }

    private void Update()
    {
        currency_text.text = starter_balance.ToString();
    }
}
