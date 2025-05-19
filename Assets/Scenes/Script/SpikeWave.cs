using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpikeWave : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    private TileBase[] spikes;

    [SerializeField] private int startX;
    [SerializeField] private int endX;
    [SerializeField] private int fixedY;
    [SerializeField] private int fixedZ;
    [SerializeField] private int length;

    [SerializeField] private float spikeLifeTime;
    [SerializeField] private float spikeInterval;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }
    private void Start()
    {
        RetrieveSpikeTiles();
        StartCoroutine(BeginSpikeWave());
    }

    private void RetrieveSpikeTiles()
    {
        length = endX - startX + 1;
        spikes = new TileBase[length];

        for (int x = 0; x < length; x++)
        {
            Vector3Int position = new Vector3Int(startX + x, fixedY, fixedZ);
            spikes[x] = tilemap.GetTile(position);
            tilemap.SetTile(position, null);
        }
    }

    private IEnumerator BeginSpikeWave()
    {
        int i = 0;
        while(true)
        {
            Vector3Int position = new Vector3Int(startX + i, fixedY, fixedZ);
            StartCoroutine(EnableDisableSpike(position, i));
            i++;
            if (i >= spikes.Length) i = 0;
            yield return new WaitForSeconds(spikeInterval);
        }
    }

    private IEnumerator EnableDisableSpike(Vector3Int position, int i)
    {
        tilemap.SetTile(position, spikes[i]);
        yield return new WaitForSeconds(spikeLifeTime);
        tilemap.SetTile(position, null);
    }
}
