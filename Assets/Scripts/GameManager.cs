using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player; // Viittaa Player-objektiin
    public Enemy enemy; //Viittaa enemy-objektiin
    public UIManager uiManager; // Ved‰ PlayerUI-komponentti inspectorissa

    void Start()
    {
        //alustetaan pelaaja
        uiManager.SetPlayerName("Warrior"); // Aseta pelaajan nimi UI:hin
        uiManager.UpdatePlayerHealth(player.currentHealth, player.maxHealth); // P‰ivit‰ terveys UI:ssa
        uiManager.UpdatePlayerDiceCountText(player.diceCount); // Alustetaan pelaajan noppam‰‰r‰ ja p‰ivitet‰‰n UI

        //alustetaan vihollinen
        uiManager.SetEnemyName("Gunner");
        uiManager.UpdateEnemyHealth(enemy.currentHealth, enemy.maxHealth); //P‰ivit‰ vihollisen terveys UI:ssa
        uiManager.UpdateEnemyDiceCountText(enemy.diceCount); //Alustetaan vihollisen noppam‰‰r‰ ja p‰ivitet‰‰n UI
    }

    // Voit myˆs lis‰t‰ metodeja, jotka p‰ivitt‰v‰t healthin, kun pelaaja ottaa vahinkoa

    void Update()
    {
        // Tarkista, onko Spacebaria painettu
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerTakesDamage(10); // Ota 10 vahinkoa testimieless‰
        }
        // Tarkistetaan, onko T-kirjainta painettu
        if (Input.GetKeyDown(KeyCode.T))
        {
            // V‰hennet‰‰n pelaajan noppien m‰‰r‰‰ yhdell‰
            IncreasePlayerDiceCount(1);
        }
        // Tarkistetaan, onko G-kirjainta painettu
        if (Input.GetKeyDown(KeyCode.G))
        {
            // V‰hennet‰‰n pelaajan noppien m‰‰r‰‰ yhdell‰
            DecreasePlayerDiceCount(1);
        }

    }

    // Metodi pelaajan noppam‰‰r‰n v‰hent‰miseksi
    public void DecreasePlayerDiceCount(int amount)
    {
        // V‰hennet‰‰n noppam‰‰r‰‰ ja varmistetaan, ettei se mene alle nollan
        player.SetDiceCount(player.diceCount - amount);

        // P‰ivitet‰‰n UI n‰ytt‰m‰‰n uusi noppam‰‰r‰
        uiManager.UpdatePlayerDiceCountText(player.diceCount);
    }

    // Metodi pelaajan noppam‰‰r‰n v‰hent‰miseksi
    public void IncreasePlayerDiceCount(int amount)
    {
        // V‰hennet‰‰n noppam‰‰r‰‰ ja varmistetaan, ettei se mene alle nollan
        player.SetDiceCount(player.diceCount + amount);

        // P‰ivitet‰‰n UI n‰ytt‰m‰‰n uusi noppam‰‰r‰
        uiManager.UpdatePlayerDiceCountText(player.diceCount);
    }

    public void PlayerTakesDamage(int damage)
    {
        player.TakeDamage(damage); // V‰henn‰ terveytt‰
        uiManager.UpdatePlayerHealth(player.currentHealth, player.maxHealth); // P‰ivit‰ terveys UI:ssa
    }

    public void EnemyTakesDamage(int damage)
    {
        enemy.TakeDamage(damage); //v‰henn‰ terveytt‰
        uiManager.UpdateEnemyHealth(enemy.currentHealth, player.maxHealth); //P‰ivit‰ terveys UI:ssa
    }

}