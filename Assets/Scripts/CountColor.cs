using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountColor : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;


    public void Counting()
    { // Get the SpriteRenderer component of the GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Get the texture of the sprite
        Texture2D texture = spriteRenderer.sprite.texture;

        // Create a dictionary to store the count of each color
        Dictionary<Color, int> colorCounts = new Dictionary<Color, int>();

        // Loop through every pixel in the texture
        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                // Get the color of the pixel
                Color color = texture.GetPixel(x, y);

                // If the color is not transparent
                if (color.a != 0)
                {
                    // If the color is not already in the dictionary, add it with a count of 1
                    if (!colorCounts.ContainsKey(color))
                    {
                        colorCounts.Add(color, 1);
                    }
                    // If the color is already in the dictionary, increment its count
                    else
                    {
                        colorCounts[color]++;
                    }
                }
            }
        }

        // Calculate the total number of pixels
        int totalPixels = texture.width * texture.height;

        // Loop through the dictionary and print the percentage of each color
        foreach (Color color in colorCounts.Keys)
        {
            float percentage = ((float)colorCounts[color] / totalPixels) * 100f;
            Debug.Log("Color " + color.ToString() + " makes up " + percentage.ToString() + "% of the sprite.");
        }
    }
}
