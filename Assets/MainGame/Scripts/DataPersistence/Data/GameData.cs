using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;

    // Player
    public Vector3 playerPosition;

    // Ink Variables
    // Phone
    public int coins;
    public bool getPhone;
    // Player
    public bool monologueMoodString;
    public bool PlayerCheckpoint1;
    public bool RiftMonologue;
    // Edith
    public bool EdithCheckpoint1;
    public bool getPhoneQuest;
    public bool moveEdithToPosition2;
    // Hector
    public bool HectorCheckpoint1;
    public bool HectorCheckpoint2;
    // Ghost
    public bool GhostCheckpoint1;
    public bool GhostCheckpoint2;
    public bool moveGhostToPosition2;



    // Interactables
    public GameData()
    {
        playerPosition = Vector3.zero;

    }

}
