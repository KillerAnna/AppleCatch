using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject apple, bomb;

    float delta;
    public float span = 1.3f;
    public float speed = -0.015f;
    public bool spawnStart = false;

    // Update is called once per frame
    void Update()
    {
        if(spawnStart)
        {
            delta += Time.deltaTime;
            if (delta > span)
            {
                delta = 0;
                GameObject prefab;
                if (Random.Range(0, 5) <= 1)
                {
                    prefab = bomb;
                }
                else
                {
                    prefab = apple;
                }
                GameObject go = Instantiate(prefab);
                float x = Random.Range(-1, 2);
                float z = Random.Range(-1, 2);

                go.transform.position = new Vector3(x, go.transform.position.y, z);
                //GameManager로부터 속도 값을 받는다.
                go.GetComponent<ItemController>().speed = this.speed;
            }
        }
    }
}
