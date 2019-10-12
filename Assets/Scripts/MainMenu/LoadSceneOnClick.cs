using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{

    public AudioSource back;



    public void LoadByIndex(int SceneIndex)
    {
        back.Play();
        SceneManager.LoadScene(SceneIndex);
        

    }

}