using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

enum MODES
{
    EXTRACT,
    SCAN
}

public class Game : MonoBehaviour
{
    [SerializeField]
    int sizeX;
    [SerializeField]
    int sizeY;
    GameObject[,] grid = new GameObject[32, 32];
    [SerializeField]
    GameObject resource;
    public int points = 0;
    public int numOfScans;
    public int numOfMining;
    int score;
    public TextMeshProUGUI scoreTxt;

    [SerializeField]
    MODES mode = MODES.EXTRACT;


    public void CubeClicked(int x, int y)
    {
        if (mode == MODES.EXTRACT)
        {
            ResourceBehavior resource = grid[x, y].GetComponent<ResourceBehavior>();
            if(resource.isMined || numOfMining <= 0)
            {
                return;
            }
            numOfMining--;
            resource.isMined = true;
            points += resource.gold;
            resource.GetComponent<Renderer>().material.color = Color.black;
        }
        else
        {
            if(numOfScans > 0)
            {
                numOfScans--;
                for (int i = -1; i < 2; i++)
                {
                    for (int t = -1; t < 2; t++)
                    {
                        if (grid[x + i, y + t].GetComponent<ResourceBehavior>().gold >= 60)
                        {
                            grid[x + i, y + t].GetComponent<Renderer>().material.color = Color.blue;
                        }
                        else if (grid[x + i, y + t].GetComponent<ResourceBehavior>().gold >= 30)
                        {
                            grid[x + i, y + t].GetComponent<Renderer>().material.color = Color.green;
                        }
                        else if (grid[x + i, y + t].GetComponent<ResourceBehavior>().gold >= 15)
                        {
                            grid[x + i, y + t].GetComponent<Renderer>().material.color = Color.yellow;
                        }
                        else
                        {
                            grid[x + i, y + t].GetComponent<Renderer>().material.color = Color.magenta;
                        }
                    }
                }
            }

        }
    }

    public void SwitchingModes()
    {
        if(mode == MODES.EXTRACT)
        {
            mode = MODES.SCAN;
        }
        else
        {
            mode = MODES.EXTRACT;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnGrid();
        for (int i = 0; i < 10; i++)
        {
            PlaceResource();
        }


    }



    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = "Score: " + points;
    }

    void PlaceResource()
    {
        int x = UnityEngine.Random.Range(2, 30);
        int y = UnityEngine.Random.Range(2, 30);

        for (int i = -2; i < 3; i++)
        {
            for (int t = -2; t < 3; t++)
            {
                grid[x + i, y + t].GetComponent<ResourceBehavior>().gold = 15;
            }
        }
        for (int i = -1; i < 2; i++)
        {
            for (int t = -1; t < 2; t++)
            {
                grid[x + i, y + t].GetComponent<ResourceBehavior>().gold = 30;
            }
        }
        grid[x, y].GetComponent<ResourceBehavior>().gold = 60;





        //if (grid[x, y] == null)
        //{
        //    GameObject empty = new GameObject();
        //    grid[x, y] = empty;

        //    Debug.Log("(" + x + ", " + y + ")");
        //}
        //else
        //{
        //    PlaceResource();
        //}
    }

    void SpawnGrid()
    {

        for (int i = 0; i < sizeX; i++)
        {
            for (int t = 0; t < sizeY; t++)
            {
                grid[i, t] = Instantiate(resource, transform.position + new Vector3(i, t, 0), Quaternion.identity);
                grid[i, t].GetComponent<ResourceBehavior>().coordX = i;
                grid[i, t].GetComponent<ResourceBehavior>().coordY = t;
                grid[i, t].GetComponent<ResourceBehavior>().gold = 10;

            }
        }
    }
}
