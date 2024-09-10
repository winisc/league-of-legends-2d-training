using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int countAbates;
    public int danoFisico;
    public int danoMagico;
    // Start is called before the first frame update
    void Start()
    {
        countAbates = 0;
        danoFisico = 1;
        danoMagico = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
