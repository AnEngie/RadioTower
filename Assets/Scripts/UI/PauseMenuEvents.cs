using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenuEvents : MonoBehaviour
{
    private UIDocument _document;

    private Button _button;

    private List<Button> _menuButtons = new List<Button>();

    private void OnEnable()
    {
        _document = GetComponent<UIDocument>();

        _button = _document.rootVisualElement.Q("ResumeGameButton") as Button;
        _button.RegisterCallback<ClickEvent>(OnResumeGameClick);

        _menuButtons = _document.rootVisualElement.Query<Button>().ToList();
        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OnDisable()
    {
        _button.UnregisterCallback<ClickEvent>(OnResumeGameClick);

        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].UnregisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OnResumeGameClick(ClickEvent evt)
    {
        _document.enabled = false;
    }

    private void OnAllButtonsClick(ClickEvent evt)
    {
        // Play Audio
    }
}
