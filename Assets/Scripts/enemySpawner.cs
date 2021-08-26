//Egemen Engin
//https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] List<waveConfig> waveConfs;
    [SerializeField] bool looping = false;
    [SerializeField] int startingWave = 0;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(spawnAllWaves());
        } while (looping);
    }
    private IEnumerator spawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfs.Count; waveIndex++)
        {
            var currentWave = waveConfs[waveIndex];
            StartCoroutine(spawnAllEnemiesInWave(currentWave));

            yield return new WaitForSeconds(5);
        }
    }
    private IEnumerator spawnAllEnemiesInWave(waveConfig curWave)
    {
        for(int enemyCount = 0; enemyCount < curWave.getNumberOfEnemies(); enemyCount++)
        {

            var newEnemy = Instantiate(curWave.getEnemyPrefab(),curWave.getWaypoints()[0].transform.position,Quaternion.identity) ;
            newEnemy.GetComponent<enemyPathing>().setWaveConf(curWave);
            yield return new WaitForSeconds(curWave.getTimeBetweenSpawns());
        }




        
    }
}
