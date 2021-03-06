//Egemen Engin
//https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy Wave Configuration")]
public class waveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;
    // Start is called before the first frame update
    public GameObject getEnemyPrefab() { return enemyPrefab; }
    public float getTimeBetweenSpawns() { return timeBetweenSpawns; }
    public float getSpawnRandomFactor() { return spawnRandomFactor; }
    public int getNumberOfEnemies() { return numberOfEnemies; }
    public float getMoveSpeed() { return moveSpeed; }
    public List<Transform> getWaypoints()
    {
        var waveWayPoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }
        return waveWayPoints;
    }
}
