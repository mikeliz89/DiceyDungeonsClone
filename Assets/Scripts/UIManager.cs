using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI enemyNameText;

    public Slider playerHealthSlider;
    public Slider enemyHealthSlider;

    public Image playerImage; // Jos haluat muuttaa sprite-kuvaa ohjelmallisesti
    public Image enemyImage;

    public TextMeshProUGUI playerHealthText; // kenttä pelaajan health-tekstille
    public TextMeshProUGUI enemyHealthText; // kenttä vihollisen health-tekstille

    public TextMeshProUGUI playerDiceCountText;  // UI-tekstikenttä noppamäärän näyttämiseksi
    public TextMeshProUGUI enemyDiceCountText;  // UI-tekstikenttä noppamäärän näyttämiseksi

    public void SetPlayerName(string name)
    {
        playerNameText.text = name;
    }

    public void SetEnemyName(string name)
    {
        enemyNameText.text = name;
    }

    public void SetEnemyImage(Sprite sprite)
    {
        enemyImage.sprite = sprite;
    }

    public void UpdatePlayerHealth(float currentHealth, float maxHealth)
    {
        playerHealthSlider.value = currentHealth / maxHealth;
        playerHealthText.text = $"{Mathf.FloorToInt(currentHealth)} / {Mathf.FloorToInt(maxHealth)}";
    }

    public void UpdateEnemyHealth(float currentHealth, float maxHealth)
    {
        enemyHealthSlider.value = currentHealth / maxHealth;
        enemyHealthText.text = $"{Mathf.FloorToInt(currentHealth)} / {Mathf.FloorToInt(maxHealth)}";
    }

    // Päivitetään pelaajan noppamäärä UI:ssa
    public void UpdatePlayerDiceCountText(int diceCount)
    {
        playerDiceCountText.text = "Noppia: " + diceCount.ToString();
    }

    // Päivitetään vihollisen noppamäärä UI:ssa
    public void UpdateEnemyDiceCountText(int diceCount)
    {
        enemyDiceCountText.text = "Noppia: " + diceCount.ToString();
    }

}
