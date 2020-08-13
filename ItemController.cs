using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed, 0);
        Destroy(gameObject, 3f);
    }
}
