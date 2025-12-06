using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIhandler : MonoBehaviour
{
    private VisualElement m_healthbar;
    public static UIhandler instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        UIDocument uiDocument = GetComponent<UIDocument>();
        m_healthbar = uiDocument.rootVisualElement.Q<VisualElement>("healthbar");
        SetHealthValue(1.0f);
    }

    public void SetHealthValue(float percentage)
    {
        m_healthbar.style.width = Length.Percent(100 * percentage);
    }
}
