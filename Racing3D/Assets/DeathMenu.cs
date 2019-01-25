using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
    
public class DeathMenu : MonoBehaviour
{
    public Text scoreText;

    public Image backgroundImage;

    private bool isShown;
    private float transition;

 	void Start ()
    {
        gameObject.SetActive(false);
        isShown = false;
        transition = 0.0f;
    }
	
	void Update ()
    {
        if (!isShown)
            return;

        transition += Time.deltaTime;
     //   backgroundImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
    }

    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);

        scoreText.text = ((int)score).ToString() + " Seconds on the Run!";

        isShown = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
