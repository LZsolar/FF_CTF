using UnityEngine;
using PixelsForGlory.VoronoiDiagram;
using System.Collections.Generic;

public class Voronoi : MonoBehaviour
{
    public int width = 4096;
    public int height = 4096;


    private VoronoiDiagram<Color> voronoiDiagram;
    private Texture2D voronoiTexture;

    public GameManager gm;

    public void ending()
    {
        voronoiDiagram = new VoronoiDiagram<Color>(new Rect(0f, 0f, width, height));
        var points = new List<VoronoiDiagramSite<Color>>();
        foreach (var point in gm.flagPosition)
        {
            Color randColor = new Color(Random.value, Random.value, Random.value);

            
                points.Add(new VoronoiDiagramSite<Color>(point, randColor));
            
        }

        voronoiDiagram.AddSites(points);
        voronoiDiagram.GenerateSites(2);

        voronoiTexture = new Texture2D(width, height);
        voronoiTexture.SetPixels(voronoiDiagram.Get1DSampleArray());
        voronoiTexture.Apply();

        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Sprite.Create(voronoiTexture, new Rect(0f, 0f, width, height), new Vector2(0.5f, 0.5f));
    }
}
