using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : Singleton<WaveSpawner>
{
    [SerializeField] private LevelManagerScriptableObject levelSO;
    private GameObject currentPathOnScene;
    WaveData currentWaveSO;
    List<Transform> wayPoints;
    List<GameObject> listBots;
    public bool isSpawning;

    void Start()
    {
        listBots = new List<GameObject>();
        wayPoints = new List<Transform>();
        isSpawning = true;
        StartCoroutine(SpawnDemoWaves());
    }
    public WaveData GetCurrentWave()
    {
        return currentWaveSO;
    }
    IEnumerator SpawnDemoWaves()
    {
        int waveIndex = 0;
        while (waveIndex <= 1)
        {
            currentWaveSO = levelSO.waves[waveIndex];
            if(currentPathOnScene != null)
            {
                Destroy(currentPathOnScene);
            }
            currentPathOnScene = Instantiate(currentWaveSO.pathPrefab, new Vector3(0, 10, 0), Quaternion.identity);
            wayPoints.Clear();
            wayPoints.AddRange(currentWaveSO.GetWayPoints(currentPathOnScene.transform));
            if (currentWaveSO.IsScene && listBots.Count == 0)
            {
               

                for (int i = 0; i < wayPoints.Count; i++)
                {

                    GameObject bot = Instantiate(currentWaveSO.GetEnemyPrefab(Random.Range(0, 3)),
                                       new Vector3(0, 15, 0),
                                       Quaternion.identity);
                    WayFinder wayFinder = bot.GetComponent<WayFinder>();
                    wayFinder.SetDestionation(wayPoints[i]);
                    listBots.Add(bot);
                    yield return new WaitForSeconds(0.5f);
                }
            }
            else
            {
                for (int i = 0; i < listBots.Count && i < wayPoints.Count; i++)
                {
                    WayFinder wayFinder = listBots[i].GetComponent<WayFinder>();
                    wayFinder.SetDestionation(wayPoints[i]);
                }
                waveIndex++;
            }
        }
        yield return new WaitForSeconds(2f);

        isSpawning = false;
    }
}
