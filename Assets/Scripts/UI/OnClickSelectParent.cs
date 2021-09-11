using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClickSelectParent : MonoBehaviour
{
    public GameObject get_parent;

    public void SelectParent()
    {
        EventSystem.current.SetSelectedGameObject(get_parent);
    }
}
