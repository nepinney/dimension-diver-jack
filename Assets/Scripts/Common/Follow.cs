using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;

    void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
}
