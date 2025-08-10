using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private bool isPaused = false;
    private UIDocument uIDocument;
    private PlayerController playerMovement;
    private InteractionDetector interactionDetector;

    void Start()
    {
        uIDocument = GetComponent<UIDocument>();
        uIDocument.enabled = false;

        gameManager = GameManager.Instance;
        playerMovement = gameManager.PlayerMovement;
    }

    public void OnEscape(InputAction.CallbackContext context)
    {
        if (!isPaused)
        {
            uIDocument.enabled = true;
            Time.timeScale = 0;
            playerMovement.enabled = false;
            isPaused = true;
        }
        else if (isPaused)
        {
            uIDocument.enabled = false;
            Time.timeScale = 1;
            playerMovement.enabled = true;
            isPaused = false;
        }
    }
}
