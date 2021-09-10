using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SaveUserSettings : MonoBehaviour
{
    // Variables
    private string userSettingsName = "Assets/User/UserName.txt";
    private string userSettingsGender = "Assets/User/UserGender.txt";
    public TMPro.TextMeshProUGUI textHolder, placeHolder;
    public Button maleGender, femaleGender;
    public GameObject profileMenu;
    private bool gender_selected_is_male = true;
    private bool loadedProfile = false;
    private string currentName = "Username...";
    private string currentGender = "";

    // Start is called before the first frame update
    private void Start()
    {
        if (File.Exists(userSettingsName) && File.Exists(userSettingsGender))
        {
            LoadProfile();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // If the component is active, let the user update his profile
        if (profileMenu.activeSelf)
        {
            CheckSelectedGender();
            CreateProfile();
        }
    }

    // Check which is the last selected gender
    private void CheckSelectedGender()
    {
        // Check if the male or the female button is the last pressed
        if (EventSystem.current && EventSystem.current.currentSelectedGameObject && EventSystem.current.currentSelectedGameObject.name == "Male")
        {
            gender_selected_is_male = true;
            maleGender.GetComponent<Image>().color = Color.green;;
            femaleGender.GetComponent<Image>().color = Color.grey;

        }
        else if (EventSystem.current && EventSystem.current.currentSelectedGameObject && EventSystem.current.currentSelectedGameObject.name == "Female")
        {
            gender_selected_is_male = false;
            maleGender.GetComponent<Image>().color = Color.grey;
            femaleGender.GetComponent<Image>().color = Color.green;
        }
        else if (gender_selected_is_male)
        {
            maleGender.GetComponent<Image>().color = Color.green;;
            femaleGender.GetComponent<Image>().color = Color.grey;
        }
    }

    // Load the profile settings saved in a txt file
    private void LoadProfile()
    {
        // Load the name
        currentName = File.ReadAllText(userSettingsName);
        textHolder.text = currentName;
        placeHolder.text = currentName;

        // Select the gender
        string Gender = File.ReadAllText(userSettingsGender);
        if (Gender != "M" && Gender != "F")
        {
            return;
        }

        if (Gender.Equals("M"))
        {
            gender_selected_is_male = true;
            maleGender.GetComponent<Image>().color = Color.green;;
            femaleGender.GetComponent<Image>().color = Color.grey;
        }
        else if (Gender.Equals("F"))
        {
            gender_selected_is_male = false;
            maleGender.GetComponent<Image>().color = Color.grey;
            femaleGender.GetComponent<Image>().color = Color.green;
        }
    }

    // Check if string is not empty
    bool available(string text)
    {
        if (text.Length <= 1)
            return false;
        return true;
    }

    // Create new user profile
    private void CreateProfile()
    {
        // File will be created when we send the text

        // Username
        if (!(File.Exists(userSettingsName)))
        {
            ChangeText();
            File.WriteAllText(userSettingsName, currentName);
        }
        else
        {
            ChangeText();
            File.Delete(userSettingsName);
            File.WriteAllText(userSettingsName, currentName);
        }

        // Gender
        if (File.Exists(userSettingsGender))
        {
            currentGender = File.ReadAllText(userSettingsGender);

            if (currentGender.Equals("M") && gender_selected_is_male == false)
            {
                File.Delete((userSettingsGender));
                File.WriteAllText(userSettingsGender, "F");
            }
            else if (currentGender.Equals("F") && gender_selected_is_male == true)
            {
                File.Delete((userSettingsGender));
                File.WriteAllText(userSettingsGender, "M");
            }
        }
        else
        {
            if(gender_selected_is_male)
                File.WriteAllText(userSettingsGender,"M");
            else
                File.WriteAllText(userSettingsGender,"F");
        }
    }

    // Set certain item as selected
    public void setSelectedMale()
    {
        EventSystem.current.SetSelectedGameObject(maleGender.gameObject);
    }

    // Set certain item as selected
    public void setSelectedFemale()
    {
        EventSystem.current.SetSelectedGameObject(femaleGender.gameObject);
    }

    // Change text
    public void ChangeText()
    {
        if(textHolder.text != "" && textHolder.text.Length >= 1)
            currentName = textHolder.text;

        if (currentName.Length <= 1)
            currentName = "Username...";
    }
}
