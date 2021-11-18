using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{

    private void Update(){
        if(Input.anyKeyDown){
            ResetStats();
            SceneManager.LoadScene("Level 1");
        }
    }


    public void LoadLevelByIndex(int lvlIndex)
    {
        SceneManager.LoadScene(lvlIndex);
    }

    public void LoadLevelByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ResetStats(){
        Player.score = 0;
        Player.lives = 3;
        Player.missed = 0;
    }
    
}
