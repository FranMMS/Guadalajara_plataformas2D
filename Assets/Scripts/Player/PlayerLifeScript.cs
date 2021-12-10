using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeScript : MonoBehaviour
{

    public Sprite[] lifeImages;
    public Image actualLifeImage;

    // Start is called before the first frame update
    void Start()
    {

        lifeImages = new Sprite[7];

        actualLifeImage = GetComponent<Image>();

        for (int i = 0; i < lifeImages.Length; i++)
        {
            lifeImages[i] = Resources.Load<Sprite>("HUD/life"+ (i+1) );
        }
        actualLifeImage.sprite = lifeImages[0];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
