using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIhandler : MonoBehaviour
{
    public float CurrentHealth = 0.65f;

    // Start is called before the first frame update
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        VisualElement healthbar = uiDocument.rootVisualElement.Q<VisualElement>("healthbar");
        healthbar.style.width = Length.Percent(CurrentHealth * 150f);
    }

}
