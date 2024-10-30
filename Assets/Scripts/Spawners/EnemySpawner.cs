using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _startDelay = 5f;
    [SerializeField] private float _repeatRate = 10f;

    private WaitForSeconds _waitStartDelay;
    private WaitForSeconds _waitRepeatRate;

    protected override void Awake()
    {
        base.Awake();
        _waitStartDelay = new WaitForSeconds(_startDelay);
        _waitRepeatRate = new WaitForSeconds(_repeatRate);
    }

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        yield return _waitStartDelay;

        while (enabled)
        {
            GetRandomSpawnPosition();
            yield return _waitRepeatRate;
        }
    }

    private void GetRandomSpawnPosition()
    {
        int minRange = 0;
        int randomIndex = Random.Range(minRange, _spawnPoints.Length);
        Transform spawnPoint = _spawnPoints[randomIndex];

        Spawn(spawnPoint.position);
    }
}