using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    public float RotationSpeed;
    public bool RotationZ = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(RotationZ)
        {
            this.transform.Rotate(new Vector3(0, 0, RotationSpeed) * Time.deltaTime);
        }
        else this.transform.Rotate(new Vector3(0, RotationSpeed, 0) * Time.deltaTime);
    }
}
