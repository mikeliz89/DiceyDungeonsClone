using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public Image backgroundImage;  // Viittaus Background-Image-komponenttiin
    public Sprite[] backgroundSprites;  // Taustavaihtoehdot

    void Start()
    {
        SetRandomBackground();
    }

    // Aseta satunnainen tausta
    public void SetRandomBackground()
    {
        if (backgroundSprites.Length > 0)
        {
            int randomIndex = Random.Range(0, backgroundSprites.Length);
            backgroundImage.sprite = backgroundSprites[randomIndex];
        }
        else
        {
            Debug.LogWarning("BackgroundSprites-taulukko on tyhjä!");
        }
    }
}