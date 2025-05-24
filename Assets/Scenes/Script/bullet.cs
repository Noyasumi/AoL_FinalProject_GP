using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D (Collider2D collision)
    {
        
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * 5f;
    }
}
