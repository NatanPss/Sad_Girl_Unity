using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnObject {
        public GameObject prefab;
        [Range(0f, 1f)]
        public float spawnChance;
    }
    public SpawnObject[] spawnObjects;

    public float minSpawnRate = 1f;
    public float maxSpawnRate = 1f;

    public void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }
    public void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        float random = Random.value;
        float cumulativeChance = 0f;

        foreach (var obj in spawnObjects)
        {
            cumulativeChance += obj.spawnChance;
            if (random < cumulativeChance)
            {
                GameObject obstacle = Instantiate(obj.prefab);
                obstacle.transform.position += transform.position;
                break;
            }
            random -=obj.spawnChance;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }
}
