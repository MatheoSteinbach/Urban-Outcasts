using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjektDrehen : MonoBehaviour
{

    public float X = 10;
    public float Y = 10;
    public float Z = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(X * Time.deltaTime, Y * Time.deltaTime, Z * Time.deltaTime);
    }
}
