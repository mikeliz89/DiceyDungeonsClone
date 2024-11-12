using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;  // Vihollisen nimi
    public float maxHealth;   // Vihollisen maksimi health
    public float currentHealth;  // Vihollisen t‰m‰nhetkinen health
    //Vihollisen noppien m‰‰r‰
    public int diceCount = 5;  // Pelaajalla on aluksi 5 noppaa

    void Start()
    {
        // Asetetaan t‰m‰nhetkinen health maksimi healthiksi pelin alussa
        currentHealth = maxHealth;
    }

    // Metodi vahingon ottamiseen
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;  // V‰hennet‰‰n vahinko t‰m‰nhetkisest‰ healthista
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Varmistetaan, ettei health mene miinukselle

        if (currentHealth <= 0)
        {
            Die();  // Kutsutaan Die-metodia, jos health menee nollaan
        }
    }

    // Metodi kuolemiselle
    private void Die()
    {
        Debug.Log(enemyName + " has been defeated!");
        // Lis‰‰ t‰nne koodi vihollisen tuhoamiselle, kuten animaatio tai objektin poistaminen
    }

    // Metodi healthin saamiseen
    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    // Metodi healthin p‰ivitt‰miseen (esimerkiksi parantamista varten)
    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Varmistetaan, ettei health ylit‰ maksimi healthia
    }

    // Metodi noppam‰‰r‰n asettamiseen
    public void SetDiceCount(int newDiceCount)
    {
        diceCount = Mathf.Max(0, newDiceCount);  // Varmistetaan, ettei noppam‰‰r‰ mene negatiiviseksi
    }

    // Metodi noppam‰‰r‰n hakemiseen (n‰ytett‰v‰ksi UI:ssa)
    public int GetDiceCount()
    {
        return diceCount;
    }
}
