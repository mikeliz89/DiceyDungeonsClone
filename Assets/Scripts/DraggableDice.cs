using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableDice : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas parentCanvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;  // Tallenna alkuper‰inen sijainti Vector2-tyyppisen‰

    private Image image;  // Viittaus Image-komponenttiin
    [SerializeField] private Sprite emptySprite;  // Sprite, joka edustaa tyhj‰‰ kuvaa

    private bool isDraggingAllowed;  // Tilamuuttuja raahaamisen sallimiseksi

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        parentCanvas = GetComponentInParent<Canvas>();  // Hakee Canvas-komponentin

        image = GetComponent<Image>();  // Hakee Image-komponentin
    }

    // K‰ynnistyy, kun raahauksen aloitus tapahtuu
    public void OnBeginDrag(PointerEventData eventData)
    {

        // Tarkista, onko Image-komponentin sprite tyhj‰
        if (image.sprite == emptySprite)
        {
            Debug.Log("Raahaus estetty, koska sprite on noppa-empty.");
            isDraggingAllowed = false;  // Est‰ raahaaminen
            return;  // Lopeta raahaus
        }

        isDraggingAllowed = true;  //salli raahaaminen

        // Tallenna alkuper‰inen sijainti
        originalPosition = rectTransform.anchoredPosition;

        canvasGroup.alpha = 0.6f;  // Asettaa kuvien l‰pin‰kyvyyden alhaisemmaksi raahauksen aikana
        canvasGroup.blocksRaycasts = false;  // Est‰‰ vuorovaikutuksen muiden UI-elementtien kanssa
    }

    /*
    // P‰ivitt‰‰ kuvan sijainnin raahauksen aikana
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / parentCanvas.scaleFactor;  // Liikuttaa kuvaa raahaamalla
    }

    // K‰ynnistyy, kun raahaus p‰‰ttyy
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;  // Palauttaa l‰pin‰kyvyyden normaaliksi
        canvasGroup.blocksRaycasts = true;  // Palauttaa normaalin tapahtumien k‰sittelyn
    }
    */

    public void OnDrag(PointerEventData eventData)
    {
        // Tarkista, onko raahaaminen sallittua
        if (!isDraggingAllowed) return;

        // P‰ivitt‰‰ raahattavan objektin sijainnin
        // rectTransform.position = eventData.position;

        // P‰ivitt‰‰ raahattavan objektin sijainnin
        rectTransform.anchoredPosition += eventData.delta / canvasGroup.GetComponentInParent<Canvas>().scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Tarkista, onko raahaaminen sallittua
        if (!isDraggingAllowed) return;

        Debug.Log("OnEndDrag called!");  // Tarkista, tapahtuuko OnEndDrag

        // Palauta alkuper‰iseen sijaintiin
        rectTransform.anchoredPosition = originalPosition;

        // Palauta alkuper‰iset asetukset
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}