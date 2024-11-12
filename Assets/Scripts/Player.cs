using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;  // Aseta maksimiterveys
    public int currentHealth;    // Nykyinen terveys
    // Pelaajan noppien m‰‰r‰
    public int diceCount = 5;  // Pelaajalla on aluksi 5 noppaa

    [SerializeField] AudioClip audioClipTakingDamage;
    [SerializeField] AudioClip audioClipPlayerDying;

    void Start()
    {
        currentHealth = maxHealth;  // Alustetaan nykyinen terveys
    }

    // Metodi pelaajan vahingoittamiselle
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        AudioManager.instance.Play(audioClipTakingDamage);

        if (currentHealth <= 0)
        {
            Die();  // Kutsutaan Die-metodia, jos health menee nollaan
        }
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    // Metodi kuolemiselle
    private void Die()
    {
        AudioManager.instance.Play(audioClipPlayerDying);
        Debug.Log("Player has been defeated!");
        // Lis‰‰ t‰nne koodi vihollisen tuhoamiselle, kuten animaatio tai objektin poistaminen
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
