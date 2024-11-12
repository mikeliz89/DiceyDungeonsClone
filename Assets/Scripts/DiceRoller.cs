using UnityEngine;
using UnityEngine.UI;  // UI-elementtien k‰sittely

public class DiceRoller : MonoBehaviour
{
    public int numberOfSides = 6;  // Nopan sivujen m‰‰r‰
    public Image[] slots;  // Viittaukset slotteihin (UI Image -komponentteihin)
    public Sprite[] diceFaces;  // Viittaukset nopan kuvien spriteihin (1-6)
    public Sprite emptyImage;  // Tyhj‰ kuva slotteja varten

    public Player player;  // Viittaa Player-objektiin

    [SerializeField] AudioClip audioClipRollTheDice;

    // Heitt‰‰ nopan tietyn sivum‰‰r‰n mukaan
    public int RollDice(int numberOfSides)
    {
        return Random.Range(1, numberOfSides + 1);
    }

    // T‰m‰ metodi heitt‰‰ nopan ja t‰ytt‰‰ slotit nopan kuvilla
    public void RollDiceAndFillSlots()
    {
        AudioManager.instance.Play(audioClipRollTheDice);
        EmptyAllDiceSlots();
        FillAvailableSlots();
    }

    private void FillAvailableSlots()
    {
        // T‰ytet‰‰n vain niin monta slottia kuin pelaajalla on noppia
        for (int i = 0; i < player.diceCount; i++)
        {
            // Heitet‰‰n noppa
            int diceRoll = RollDice(numberOfSides) - 1;  // V‰henn‰ 1, jotta se sopii indeksiin (0-5)
            if (i < slots.Length)  // Varmistetaan, ettei menn‰ slotteja yli
            {
                slots[i].sprite = diceFaces[diceRoll];  // Aseta kuva slottiin
            }
        }
    }

    private void EmptyAllDiceSlots()
    {
        // Tyhjennet‰‰n kaikki slotit
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].sprite = emptyImage;  // Asetetaan tyhj‰ kuva kaikille sloteille aluksi
        }
    }
}