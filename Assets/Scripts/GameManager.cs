using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Made with a tutorial by Night Run Studio: https://youtu.be/j_eQGp-IbCE?si=xDhd-vCsRpHMP39S
    
    [Header("Persitent Objects")]
    public GameObject[] persistentObjects;

    [Header("UI References")]
    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;
    public Image portraitImage;
    public Button[] choiceButon;
    public PlayerController PlayerMovement;
    public PauseMenu pauseMenu;

    public static GameManager Instance;
    
    private void Awake()
    {
        if (Instance != null)
        {
            CleanUpAndDestroy();
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            MarkPersistentObjects();
        }
    }

    private void MarkPersistentObjects()
    {
        foreach (GameObject obj in persistentObjects)
        {
            if (obj != null)
            {
                DontDestroyOnLoad(obj);
            }
        }
    }

    private void CleanUpAndDestroy()
    {
        foreach (GameObject obj in persistentObjects)
        {
            Destroy(obj);
        }

        Destroy(gameObject);
    }
}
