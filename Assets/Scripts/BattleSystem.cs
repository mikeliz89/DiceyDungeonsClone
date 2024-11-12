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
        int attackRoll = diceRoller.RollDice(6); // Heitt�� 6-sivuisen nopan
        enemyHealth -= attackRoll;
        Debug.Log("Pelaaja hy�kk�si ja aiheutti " + attackRoll + " vahinkoa.");
    }

    public void EnemyAttack()
    {
        int attackRoll = diceRoller.RollDice(6); // Vihollinen heitt�� my�s
        playerHealth -= attackRoll;
        Debug.Log("Vihollinen hy�kk�si ja aiheutti " + attackRoll + " vahinkoa.");
    }
}
