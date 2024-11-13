using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DiceDropHandler : MonoBehaviour, IDropHandler
{
    public Image attackSlot;  // Viittaus Image-slot-komponenttiin attack-paneelissa
    [SerializeField] private Sprite emptySprite;  // Sprite, joka edustaa tyhj‰‰ kuvaa

    public void OnDrop(PointerEventData eventData)
    {
        // Tarkista, onko raahattava objekti DraggableDice
        DraggableDice draggableDice = eventData.pointerDrag?.GetComponent<DraggableDice>();
        if (draggableDice != null)
        {
            Debug.Log("DraggableDice pudotettu Attack-paneelin alueelle!");

            // Hanki Image-komponentti raahattavasta nopasta
            Image diceImage = draggableDice.GetComponent<Image>();
            if (diceImage != null && attackSlot != null)
            {
                Debug.Log("Kuva");
                // Aseta attackSlotin sprite samaksi kuin raahatun nopan sprite
                attackSlot.sprite = diceImage.sprite;

                // (Valinnainen) Tyhjenn‰ sprite raahatusta nopasta
                diceImage.sprite = emptySprite;  // Voit asettaa t‰m‰n tyhj‰ksi, jos haluat poistaa sen raahattavasta nopasta
            }
            else
            {
                Debug.Log("Kuva puuttuu");
            }
        }
    }
}