using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour, IInteractable
{
    public NPCDialogue dialogueData;

    private GameObject dialoguePanel;
    private TMP_Text dialogueText, nameText;
    private Image portraitImage;

    private int dialogueIndex;
    private bool isTyping;
    private bool isDialogueActive;

    private Dialogue line;

    void Start()
    {
        dialoguePanel = GameManager.Instance.dialoguePanel;
        dialogueText = GameManager.Instance.dialogueText;
        nameText = GameManager.Instance.nameText;
        portraitImage = GameManager.Instance.portraitImage;
    }

    public bool CanInteract()
    {
        return !isDialogueActive;
    }

    public void Interact()
    {
        if (dialogueData == null && !isDialogueActive)
            return;

        if (isDialogueActive)
        {
            NextLine();
        }
        else
        {
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        isDialogueActive = true;
        dialogueIndex = 0;

        dialoguePanel.SetActive(true);
        
        line = dialogueData.dialogueLines[dialogueIndex];

        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.SetText(line.text);
            isTyping = false;
        }
        else if (++dialogueIndex < dialogueData.dialogueLines.Length)
        {
            line = dialogueData.dialogueLines[dialogueIndex];
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.SetText("");

        nameText.SetText(line.speaker.actorName);
        
        portraitImage.sprite = line.speaker.portrait;

        foreach (char letter in dialogueData.dialogueLines[dialogueIndex].text)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueData.typingspeed);
        }

        isTyping = false;

        if (dialogueData.autoProgressLines.Length > dialogueIndex && dialogueData.autoProgressLines[dialogueIndex])
        {
            yield return new WaitForSeconds(dialogueData.autoProgressDelay);
            NextLine();
        }
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
    }
}
