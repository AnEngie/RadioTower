using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/Dialogue")]
public class NPCDialogue : ScriptableObject
{
    public Dialogue[] dialogueLines;
    public bool[] autoProgressLines;
    public float autoProgressDelay = 1.5f;
    public float typingspeed = 0.05f;
    public AudioClip voicesound;
    public float voicePitch = 1f;
}

[Serializable]
public class Dialogue
{
    public Actor speaker;
    [TextArea(3, 5)] public string text;
}
