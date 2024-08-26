using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x, target.position.y, target.position.z) + offset;
            transform.LookAt(target);
        }
    }
}
