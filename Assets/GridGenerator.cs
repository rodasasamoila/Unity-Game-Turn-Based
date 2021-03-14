using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject mapSquare;
    public int height;
    public int width;
    // Start is called before the first frame update
    void Start()
    {
        GenerateMap(width, height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateMap(int width,int height)
    {
        
        for(int i=0;i<width;i++)
        {
            for(int j=0;j<height;j++)
            {
                Instantiate(mapSquare, new Vector3(i, j,1), transform.rotation);
            }
        }
    }
}
