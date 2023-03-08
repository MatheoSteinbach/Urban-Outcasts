using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SaveGame : MonoBehaviour
{
    private void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            DataPersistenceManager.instance.SaveGame();
        }
    }
}
