using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour, IInteractable
{
    public NPCDialogue dialogueData;

    private Button[] choiceButtons;
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
        choiceButtons = GameManager.Instance.choiceButon;

        foreach (var button in choiceButtons)
            button.gameObject.SetActive(false);
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
            ShowChoices();
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

    private void ShowChoices()
    {
        ClearChoices();

        if (dialogueData.options.Length > 0)
        {
            isDialogueActive = true;

            for (int i = 0; i < dialogueData.options.Length; i++)
            {
                var option = dialogueData.options[i];

                choiceButtons[i].GetComponentInChildren<TMP_Text>().text = option.optionText;
                choiceButtons[i].gameObject.SetActive(true);

                choiceButtons[i].onClick.AddListener(() => ChooseOption(option.nextDialogue));
            }
        }
        else
        {
            EndDialogue();
        }
    }

    private void ChooseOption(NPCDialogue dialogue)
    {
        if (dialogue == null)
        {
            EndDialogue();
        }
        else
        {
            ClearChoices();
            dialogueData = dialogue;
            StartDialogue();
        }
    }

    private void ClearChoices()
    {
        foreach (var button in choiceButtons)
        {
            button.gameObject.SetActive(false);
            button.onClick.RemoveAllListeners();
        }
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        ClearChoices();
        isDialogueActive = false;
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
    }
}
