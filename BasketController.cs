using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE, bombSE;
    AudioSource aud;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);

                transform.position = new Vector3(x, 0, z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (other.CompareTag("Apple"))
        {
            aud.PlayOneShot(appleSE);
            gm.GetApple();
        }
        else
        {
            aud.PlayOneShot(bombSE);
            gm.GetBomb();
        }
        Destroy(other.gameObject);
    }

}
