using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite Desert;
    [SerializeField] private Sprite DesertNight;
    [SerializeField] private Sprite ScorchLand;
    [SerializeField] private Sprite AcidSwamp;
    
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        BackgroundChoice();
    }

    void BackgroundChoice()
    {
        switch (GameManager.instance.ArenaChoice)
        {
            case 1:
            {
                spriteRenderer.sprite = Desert;
                
                break;
            }
            case 2:
            {
                spriteRenderer.sprite = DesertNight;
                break;
            }
            case 3:
            {
                spriteRenderer.sprite = ScorchLand;
                
                break;
            }
            case 4:
            {
                spriteRenderer.sprite = AcidSwamp;
                
                break;
            }
        }
    }
}
