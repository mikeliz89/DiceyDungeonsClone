using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDiceButtonHandler : MonoBehaviour
{
    public DiceRoller diceRoller;

    // T‰m‰ metodi voidaan liitt‰‰ Unityn nappiin
    public void OnRollButtonClicked()
    {
        diceRoller.RollDiceAndFillSlots();  // Heitt‰‰ nopan ja t‰ytt‰‰ slotit
    }
}
