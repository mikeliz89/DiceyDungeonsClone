using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;  // Vihollisen nimi
    public float maxHealth;   // Vihollisen maksimi health
    public float currentHealth;  // Vihollisen tämänhetkinen health
    //Vihollisen noppien määrä
    public int diceCount = 5;  // Pelaajalla on aluksi 5 noppaa
    public float damage;

    public Sprite enemySprite; // Vihollisen kuva/sprit
    [SerializeField] AudioClip audioClipTakingDamage;
    [SerializeField] AudioClip audioClipDying;

    void Start()
    {
        // Asetetaan tämänhetkinen health maksimi healthiksi pelin alussa
        currentHealth = maxHealth;
    }

    public virtual void Attack()
    {
        Debug.Log($"{enemyName} attacks and deals {damage} damage");
    }

    // Metodi vahingon ottamiseen
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;  // Vähennetään vahinko tämänhetkisestä healthista
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Varmistetaan, ettei health mene miinukselle

        AudioManager.instance.Play(audioClipTakingDamage);

        if (currentHealth <= 0)
        {
            Die();  // Kutsutaan Die-metodia, jos health menee nollaan
        }
    }

    // Metodi kuolemiselle
    protected virtual void Die()
    {
        AudioManager.instance.Play(audioClipDying);
        Debug.Log(enemyName + " has been defeated!");
        // Lisää tänne koodi vihollisen tuhoamiselle, kuten animaatio tai objektin poistaminen
    }

    // Metodi healthin saamiseen
    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    // Metodi healthin päivittämiseen (esimerkiksi parantamista varten)
    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Varmistetaan, ettei health ylitä maksimi healthia
    }

    // Metodi noppamäärän asettamiseen
    public void SetDiceCount(int newDiceCount)
    {
        diceCount = Mathf.Max(0, newDiceCount);  // Varmistetaan, ettei noppamäärä mene negatiiviseksi
    }

    // Metodi noppamäärän hakemiseen (näytettäväksi UI:ssa)
    public int GetDiceCount()
    {
        return diceCount;
    }
}
