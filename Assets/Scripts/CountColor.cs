using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountColor : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // the sprite renderer component of the GameObject
    public Color[] colorsToCount; // the colors to count
    public string[] colorNames; // the names of the colors to display
    public float[] colorPercentages; // the percentage of each color

    [SerializeField]
    public TextMeshProUGUI redDisplay, BlueDisplay, VillageDiaplay,winner;

    public void Counting()
    {
        // Initialize the color percentages to 0
        colorPercentages = new float[colorsToCount.Length];

        // Get the texture of the sprite
        Texture2D texture = spriteRenderer.sprite.texture;

        // Loop through all pixels in the texture
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                // Get the color of the pixel
                Color pixelColor = texture.GetPixel(x, y);

                // Loop through all the colors to count
                for (int i = 0; i < colorsToCount.Length; i++)
                {
                    // If the pixel color matches the color to count, add 1 to the color count
                    if (pixelColor == colorsToCount[i])
                    {
                        colorPercentages[i] += 1;
                    }
                }
            }
        }

        float totalPixels = texture.width * texture.height;


        // Calculate the percentage of each color
        for (int i = 0; i < colorsToCount.Length; i++)
        {
            colorPercentages[i] = (colorPercentages[i] / totalPixels) * 100;
        }

        redDisplay.text = "RED : "+ colorPercentages[0]+"%";
        BlueDisplay.text = "BLUE : " + colorPercentages[1] + "%";
        VillageDiaplay.text = "Village : " + colorPercentages[2] + "%";

        if(colorPercentages[2]>colorPercentages[1] && colorPercentages[2] > colorPercentages[0])
        {
            winner.text = "NO ONE is THE WINNER";
        }
        else if (colorPercentages[1] > colorPercentages[0])
        {
            winner.text = "BLUE is THE WINNER";
        }
        else
        {
            winner.text = "RED is THE WINNER";
        }

        
    }
}
