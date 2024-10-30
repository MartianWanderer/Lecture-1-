using System.Collections;
using UnityEngine;

namespace GameDevWithReece.Enemy
{
    public class EnemySpawnerManager : MonoBehaviour
    {
        //Array of available spawnPoints
        [SerializeField] Transform[] spawnPoints;

        //Floats that are used as Delays
        [SerializeField] float delayBetweenSpawns;
        [SerializeField] float delaybetweenWaves;

        //Int to set how many waves we want and private int for the current wave
        [SerializeField] int wavesNumber;
        private int currentWaveCount = 0;

        // Stored GameObject of enemyPrefab to spawn
        [SerializeField] GameObject enemyPrefab;

        //Array of Scriptable Objects to call from 
        [SerializeField] EnemyData[] enemyData;

        //Int to keep track of how many enemies to spawn for that wave
        [SerializeField] int numberOfEnemiesToSpawn;




        public void StartWaves()
        {
            StartCoroutine(SpawnWaves());

        }
        IEnumerator SpawnWaves()
        {

            for (int i = 0; i < numberOfEnemiesToSpawn; i++)
            {
                // Local variable to use for "random" spawn points
                int randomInt = Random.Range(0, spawnPoints.Length - 1);

                // Creates the ship in game at one of the positions in spawnPoints
                GameObject spawnedShip = Instantiate(enemyPrefab, spawnPoints[randomInt]);
                print("in");
                // changes all the variables of the spawnedShip to be equal to the variables stored on the prefab
                spawnedShip.GetComponent<EnemyVisual>().enemyData = enemyData[currentWaveCount];
                spawnedShip.GetComponent<EnemyMovement>().enemyData = enemyData[currentWaveCount];
                spawnedShip.GetComponent<EnemyLife>().enemyData = enemyData[currentWaveCount];

                // Delays the time before next Loop/ spawnedShip
                yield return new WaitForSeconds(delayBetweenSpawns);
            }

            // Increases currentWaveCount by 1
            currentWaveCount++;

            // Checks if there's still more waves
            if (currentWaveCount > enemyData.Length - 1)
            {
                //if there isn't then wavecount is 0 and no more loops
                currentWaveCount = 0;
            }
            // More delay before next wave
            yield return new WaitForSeconds(delaybetweenWaves);

            //Begins next wave
            StartCoroutine(SpawnWaves());
        }


    }
}