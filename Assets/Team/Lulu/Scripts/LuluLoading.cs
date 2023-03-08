using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuluLoading : MonoBehaviour
{

    [SerializeField] RectTransform handle; 
    void Update()
    {
        transform.position = handle.position;
    }
}
