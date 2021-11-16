using UnityEngine;
using System;

public class Follow : MonoBehaviour
{
    public bool followY;
    public Transform target;

    void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);        
    }
    //public bool followX;
    //public bool followY;
    //public bool keepOffset;

    //public Transform target;

    //private Vector2 distanceToTarget;

    //private void Start()
    //{
    //    distanceToTarget = calculateDistance();
    //}

    //private Vector2 calculateDistance()
    //{
    //    float distanceX = Math.Abs(target.position.x - transform.position.x);
    //    float distanceY = Math.Abs(target.position.y - transform.position.y);
    //    return new Vector2(distanceX, distanceY);
    //}

    //void FixedUpdate()
    //{
    //    Vector3 newPosition = new Vector3();

    //    // Represents the amount of offset not accounted for
    //    // When the target moves, the distanceOffsetX will increase as the gap tightens
    //    float distanceOffsetX = distanceToTarget.x - Math.Abs(target.position.x - transform.position.x);
    //    float distanceOffsetY = distanceToTarget.y - Math.Abs(target.position.y - transform.position.y);

    //    // Need to recalculate the distance since we will be moving this object
    //    distanceToTarget = calculateDistance();

    //    if (followX)
    //    {
    //        //newPosition.x = transform.position.x + target.position.x;
    //        if (keepOffset) newPosition.x = transform.position.x + distanceOffsetX;
    //    }
    //    if (followY)
    //    {
    //        //newPosition.y = target.position.y;
    //        if (keepOffset) newPosition.y = transform.position.y + distanceOffsetY;
    //    }

    //    newPosition.z = transform.position.z;
    //    transform.position = newPosition;
    //}
}
