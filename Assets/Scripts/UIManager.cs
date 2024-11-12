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

    public TextMeshProUGUI playerHealthText; // kentt‰ pelaajan health-tekstille
    public TextMeshProUGUI enemyHealthText; // kentt‰ vihollisen health-tekstille

    public TextMeshProUGUI playerDiceCountText;  // UI-tekstikentt‰ noppam‰‰r‰n n‰ytt‰miseksi
    public TextMeshProUGUI enemyDiceCountText;  // UI-tekstikentt‰ noppam‰‰r‰n n‰ytt‰miseksi

    public void SetPlayerName(string name)
    {
        playerNameText.text = name;
    }

    public void SetEnemyName(string name)
    {
        enemyNameText.text = name;
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

    // P‰ivitet‰‰n pelaajan noppam‰‰r‰ UI:ssa
    public void UpdatePlayerDiceCountText(int diceCount)
    {
        playerDiceCountText.text = "Noppia: " + diceCount.ToString();
    }

    // P‰ivitet‰‰n vihollisen noppam‰‰r‰ UI:ssa
    public void UpdateEnemyDiceCountText(int diceCount)
    {
        enemyDiceCountText.text = "Noppia: " + diceCount.ToString();
    }

}
