using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public int playerHealth = 100;
    public int enemyHealth = 100;
    private DiceRoller diceRoller;

    void Start()
    {
        diceRoller = GetComponent<DiceRoller>();
    }

    public void PlayerAttack()
    {
        int attackRoll = diceRoller.RollDice(6); // Heittää 6-sivuisen nopan
        enemyHealth -= attackRoll;
        Debug.Log("Pelaaja hyökkäsi ja aiheutti " + attackRoll + " vahinkoa.");
    }

    public void EnemyAttack()
    {
        int attackRoll = diceRoller.RollDice(6); // Vihollinen heittää myös
        playerHealth -= attackRoll;
        Debug.Log("Vihollinen hyökkäsi ja aiheutti " + attackRoll + " vahinkoa.");
    }
}
