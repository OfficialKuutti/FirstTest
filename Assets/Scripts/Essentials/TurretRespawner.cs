using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRespawner : MonoBehaviour
{
    public GameObject turretPrefab;  // The prefab of the turret
    public Transform[] turretSpawnPoints;  // The spawn points for the turrets
    public float respawnDelay = 3f;  // Delay before respawning turrets in seconds

    private GameObject[] turrets;  // Array to hold references to the spawned turrets
    private int destroyedTurretCount;  // Counter for destroyed turrets

    private void Start()
    {
        SpawnTurrets();
    }

    private void SpawnTurrets()
    {
        int turretCount = turretSpawnPoints.Length;
        turrets = new GameObject[turretCount];
        destroyedTurretCount = 0;

        for (int i = 0; i < turretCount; i++)
        {
            Transform spawnPoint = turretSpawnPoints[i];
            GameObject turret = Instantiate(turretPrefab, spawnPoint.position, spawnPoint.rotation);
            turret.SetActive(true);  // Ensure the turret is active when spawned

            // Pass the TurretRespawner reference to the EnemyHP script of the spawned turret
            turret.GetComponent<EnemyHP>().Initialize(this);

            turrets[i] = turret;
        }
    }

    public void TurretDestroyed(GameObject destroyedTurret)
    {
        destroyedTurretCount++;

        if (destroyedTurretCount == turrets.Length)
        {
            StartCoroutine(RespawnAllTurrets());
        }
    }

    private System.Collections.IEnumerator RespawnAllTurrets()
    {
        yield return new WaitForSeconds(respawnDelay);

        for (int i = 0; i < turrets.Length; i++)
        {
            Transform spawnPoint = turretSpawnPoints[i];
            GameObject turret = Instantiate(turretPrefab, spawnPoint.position, spawnPoint.rotation);
            turret.SetActive(true);  // Ensure the respawned turret is active
            turret.GetComponent<EnemyHP>().Initialize(this);  // Pass the TurretRespawner reference to the EnemyHP script of the respawned turret
            turrets[i] = turret;
        }

        destroyedTurretCount = 0;
    }
}