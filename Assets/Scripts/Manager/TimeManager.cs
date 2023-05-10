using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public Slider timerSlider;
    public TextMeshProUGUI timerText;
    public float gameTime;
    private float timer = 0.00f;

    private bool stopTimer;

    private bool sceneLoaded = false;

    public LevelMusicManager lmm;
    public AmbientVolumeManager avm;
    public LevelLoader levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        stopTimer = true;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;

        StartCoroutine(CountDownTillStart());
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopTimer)
        timer += Time.deltaTime;

        float time = gameTime - timer;

        int minutes = Mathf.FloorToInt(time / 60    );
        int seconds = Mathf.FloorToInt(time - minutes * 60);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if(time <= 0)
        {
            avm.FadeAmbientVolume(0, 3f);
            lmm.FadeLevelMusicVolume(0, 3f);
            stopTimer = true;
            if (!sceneLoaded)
            {
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ThirdLevel"))
                {
                    SceneManager.LoadScene("GameCompleted", LoadSceneMode.Single);
                }
                else
                {
                    levelLoader.LoadShop();
                    sceneLoaded = true;
                }
            }
        }

        if(stopTimer == false)
        {
            timerText.text = textTime;
            timerSlider.value = time;
        }
    }

    private IEnumerator CountDownTillStart()
    {
        yield return new WaitForSeconds(3f);
        stopTimer = false;
    }
}
