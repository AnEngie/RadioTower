using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    private UIDocument _document;

    private Button _button;

    private List<Button> _menuButtons = new List<Button>();

    [SerializeField]
    private bool isPaused = false;

    void Awake()
    {
        _document = GetComponent<UIDocument>();
        AssignButtons();
        _document.enabled = false;
    }

    public void OnEscape(InputAction.CallbackContext context)
    {
        if (!isPaused)
        {
            PauseGame();
        }
        else if (isPaused)
        {
            UnPauseGame();
        }
    }

    private void OnResumeGameClick(ClickEvent evt)
    {
        UnPauseGame();
    }

    private void OnAllButtonsClick(ClickEvent evt)
    {
        // Play Audio
    }

    private void AssignButtons()
    {
        _button = _document.rootVisualElement.Q("ResumeGameButton") as Button;

        _button.RegisterCallback<ClickEvent>(OnResumeGameClick);

        _menuButtons = _document.rootVisualElement.Query<Button>().ToList();
        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void PauseGame()
    {
        _document.enabled = true;
        AssignButtons();
        Time.timeScale = 0;
        isPaused = true;
    }

    private void UnPauseGame()
    {
        _document.enabled = false;
        Time.timeScale = 1;
        isPaused = false;
    }
}
