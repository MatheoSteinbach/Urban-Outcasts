using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZoomCam : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void Update()
    {
        gameObject.transform.position = player.transform.position + new Vector3(15.9f, 11.5f, -16.5f);
    }
}
