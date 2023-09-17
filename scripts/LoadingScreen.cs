using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    // Start is called before the first frame update
    float time,second;
    [SerializeField]
    public Image FillImage;

    void Start()
    {
        second = 4;
        Invoke("LoadGame",4f);         
    }

    // Update is called once per frame
    void Update()
    {
        if(time<4)
        {
            time += Time.deltaTime;
            FillImage.fillAmount = time / second;
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(0);
    }
}
