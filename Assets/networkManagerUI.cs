using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

public class networkManagerUI : MonoBehaviour
{
    private UIDocument _document;
    private Button _server;
    // public struct Buttons
    // {
    //     Button _server;
    //     Button _host;
    // }
    private List<Button> _serverUIButtons = new List<Button>();

    private void Awake()
    {
        _document = GetComponent<UIDocument>();
        
        // Buttons._server = _document.rootVisualElement.Q("Server") as Button;
        // _server.RegisterCallback<ClickEvent>(onServerClick);
        // _server = _document.rootVisualElement.Q("Host") as Button;
        // _server.RegisterCallback<ClickEvent>(onServerClick);
        _server = _document.rootVisualElement.Q("Client") as Button;
        _server.RegisterCallback<ClickEvent>(onServerClick);

        // _serverUIButtons = _document.rootVisualElement.Query<Button>().ToList();
        // for (int i = 0; i < _serverUIButtons.Count; i++)
        // {
        //     _serverUIButtons[i].RegisterCallback<ClickEvent>(OnAllButtonsClick);
        //     if(i == 0) { }
        // }

        
    }
    private void OnDisable()
    {
        _server.UnregisterCallback<ClickEvent>(onServerClick);

        for (int i = 0; i < _serverUIButtons.Count; i++)
        {
            _serverUIButtons[i].UnregisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void onServerClick(ClickEvent evt)
    {
        Debug.Log("server btn pressed");
    }

    private void OnAllButtonsClick(ClickEvent evt)
    {

    }
    
}
