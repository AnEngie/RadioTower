using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour, IInteractable
{
    private bool isUsing;
    public SceneAsset nextScene;

    public bool CanInteract()
    {
        return !isUsing;
    }

    public void Interact()
    {
        travelToScene();
    }

    private void travelToScene()
    {
        SceneManager.LoadScene(nextScene.name);
    }
}
