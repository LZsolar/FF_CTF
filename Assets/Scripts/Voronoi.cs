using UnityEngine;
using PixelsForGlory.VoronoiDiagram;
using System.Collections.Generic;

public class Voronoi : MonoBehaviour
{

    public GameObject upper,downer,lefter,righter;

    private int width;
    private int height;


    private VoronoiDiagram<Color> voronoiDiagram;
    private Texture2D voronoiTexture;

    public GameManager gm;

    private void Start()
    {
        height = (int)(Mathf.Abs(upper.transform.position.y - downer.transform.position.y))*100;
        width = (int)(Mathf.Abs(lefter.transform.position.x - righter.transform.position.x))*100;
    }

    public void ending()
    {
      //  print("VOSize   "+ height + "   " + width);
        Vector2 VoronoiPosition = this.transform.position;

        voronoiDiagram = new VoronoiDiagram<Color>(new Rect(0f, 0f, width, height));
        var points = new List<VoronoiDiagramSite<Color>>();

        for(int i = 0;i<gm.flagPosition.Count;i++)
        {
            Vector2 point  = gm.flagPosition[i];
            float randY = Mathf.Abs(upper.transform.position.y - point.y)*100;
            float randX = Mathf.Abs(lefter.transform.position.x - point.x)*100;
            //print("Now adding"+ randY+"   "+randX);
            var p = new Vector2(randX, randY);
            Color randColor; 

            switch (gm.flagcolor[i])
            {
               // case 1:randColor = Color.red; break;
                //case 0:randColor = Color.blue; break;
                default: randColor = new Color(Random.value, Random.value, Random.value); break;
            }

                points.Add(new VoronoiDiagramSite<Color>(p, randColor));
            
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
