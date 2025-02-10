using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

public class networkManagerUI : MonoBehaviour
{
    private UIDocument _document;
    private Button _button;
    private List<Button> _serverUIButtons = new List<Button>();

    private void Awake()
    {
        _document = GetComponent<UIDocument>();
        
        _button = _document.rootVisualElement.Q("Server") as Button;
        _button.RegisterCallback<ClickEvent>(OnPlayGameClick);
        // _button = _document.rootVisualElement.Q("Host") as Button;
        // _button = _document.rootVisualElement.Q("Client") as Button;

        _serverUIButtons = _document.rootVisualElement.Query<Button>().ToList();
        for (int i = 0; i < _serverUIButtons.Count; i++)
        {
            _serverUIButtons[i].RegisterCallback<ClickEvent>(OnAllButtonsClick);
        }

        
    }

    private void OnDisable()
    {
        _button.UnregisterCallback<ClickEvent>(OnPlayGameClick);

        for (int i = 0; i < _serverUIButtons.Count; i++)
        {
            _serverUIButtons[i].UnregisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OnPlayGameClick(ClickEvent evt)
    {
        Debug.Log("Server BTN Pressed");
    }

    private void OnAllButtonsClick(ClickEvent evt)
    {

    }
    
}
