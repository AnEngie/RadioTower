using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRemover : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
