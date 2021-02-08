using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBehavior : MonoBehaviour
{
    public int coordX;
    public int coordY;
    public int gold;
    public bool isMined = false;

    Game grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = GameObject.FindGameObjectWithTag("grid").GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            grid.CubeClicked(coordX, coordY);
            Debug.Log("S T O P poking me, pls");
        }
    }


}
