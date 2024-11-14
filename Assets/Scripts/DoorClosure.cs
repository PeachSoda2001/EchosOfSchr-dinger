using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClosure : MonoBehaviour
{
    public float DestinationX;
    public float TargetLength;
    public float Multiplier;
    private float delta;
    private float minMoveDistance;
    // Start is called before the first frame update
    void Start()
    {
        delta = this.transform.position.x - DestinationX;
        minMoveDistance = delta / TargetLength;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = this.transform.position;
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(DestinationX, currentPos.y, currentPos.z), minMoveDistance * Time.deltaTime * Multiplier);
    }
}
