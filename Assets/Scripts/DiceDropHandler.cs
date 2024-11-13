using UnityEngine;
using UnityEngine.EventSystems;

public class DiceDropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // T‰ss‰ voidaan m‰‰ritell‰, mit‰ tapahtuu, kun noppakuva pudotetaan t‰h‰n paneeliin
        Debug.Log("Dice dropped on panel!");
    }
}