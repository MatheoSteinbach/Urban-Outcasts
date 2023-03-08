using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skript : MonoBehaviour
{
    public Color startColor = Color.green;
    public Color endColor = Color.black;
    [Range(0, 10)]
    public float speed = 1;

    Image imgComp;

    void Awake()
    {
        imgComp = GetComponent<Image>();
    }

    void Update()
    {
        imgComp.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1));
    }
}
