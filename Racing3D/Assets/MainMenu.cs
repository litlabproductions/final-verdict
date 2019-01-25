using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highscoreText;

	void Start ()
    {
        highscoreText.text = ((int) PlayerPrefs.GetFloat("Highscore")).ToString() + " sec";
	}
	
    public void ToGame ()
    {
        SceneManager.LoadScene("InfiniteGameScene");
    }
}
