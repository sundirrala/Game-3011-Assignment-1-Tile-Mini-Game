using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPlayClicked()
    {
        SceneManager.LoadScene("Resource");
    }
    public void onBackClicked()
    {
        SceneManager.LoadScene("Main");
    }
}
