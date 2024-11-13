using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array vihollisprefabeille

    public UIManager uiManager; // Viittaus UIManageriin
    public GameManager gameManager; // Viittaus GameManageriin
    private GameObject currentEnemy; // Viittaus luotuun viholliseen

    void Start()
    {
        SpawnRandomEnemy();
    }

    void SpawnRandomEnemy()
    {
        // Arvo satunnainen indeksi
        int randomIndex = Random.Range(0, enemyPrefabs.Length);

        // Luo vihollinen ottamalla arvottu prefab talteen
        currentEnemy = enemyPrefabs[randomIndex];

        // Hae Enemy-komponentti vihollisesta
        Enemy enemy = currentEnemy.GetComponent<Enemy>();
        if (enemy != null)
        {
            SetEnemyToUI(enemy);

            // L‰het‰ viittaus luotuun viholliseen GameManagerille
            gameManager.SetCurrentEnemy(enemy);
        }
    }

    private void SetEnemyToUI(Enemy enemy)
    {
        //alustetaan vihollinen ja asetetaan UI:hin
        uiManager.SetEnemyName(enemy.enemyName);
        uiManager.SetEnemyImage(enemy.enemySprite);
        uiManager.UpdateEnemyHealth(enemy.currentHealth, enemy.maxHealth); //P‰ivit‰ vihollisen terveys UI:ssa
        uiManager.UpdateEnemyDiceCountText(enemy.diceCount); //Alustetaan vihollisen noppam‰‰r‰ ja p‰ivitet‰‰n UI
    }
}
