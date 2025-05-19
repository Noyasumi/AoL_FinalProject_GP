using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float offsetY;
    private void Start()
    {
        StartCoroutine(SpawnBullet());
    }

    private IEnumerator SpawnBullet()
    {
        while (true)
        {
            GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y + offsetY, transform.position.z), Quaternion.identity);
            bullet.transform.localRotation = transform.localRotation;
            yield return new WaitForSeconds(1f);
        }
    }
}
