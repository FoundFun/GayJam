using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private RunningConfig config;
    [SerializeField] private BoxCollider2D _spawnZone;
    [SerializeField] private GameObject[] _items;

    private int _amountOfItems = 10;
    private float _spawnHeight = 0f;
    private float _minDistanceBetweenSpawns = 1f;

    private float _lastSpawnX;

    private void Start()
    {
        _amountOfItems = config.AmountOfSpawnItems;
        _spawnHeight = config.SpawnHeight;
        _minDistanceBetweenSpawns = config.MinDistanceBetweenSpawns;
        _lastSpawnX = _spawnZone.bounds.min.x;

        for (int i = 0; i < _amountOfItems; i++)
            SpawnItems();
    }

    private void SpawnItems()
    {
        int index = Random.Range(0, _items.Length);

        Vector3 spawnPosition = GetNonOverlappingPositionInZone();
        Instantiate(_items[index], spawnPosition, Quaternion.identity);
    }

    Vector3 GetNonOverlappingPositionInZone()
    {
        Bounds bounds = _spawnZone.bounds;
        float spawnX;

        do
        {
            spawnX = Random.Range(bounds.min.x, bounds.max.x);
        } while (Mathf.Abs(spawnX - _lastSpawnX) < _minDistanceBetweenSpawns);

        
        _lastSpawnX = spawnX;

        return new Vector3(spawnX, _spawnHeight, 0);
    }
}
