using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using SocketEvent;

public class StreamIntro : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    [SerializeField] private bool changeScene;
    private float timer = 2f;
    
    void Start()
    {
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }

        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
    }
    
    private void LoadScene()
    {
        if (!videoPlayer.isPlaying) 
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
            
        } 
    }
    
    void Update()
    {
        if (changeScene)
        {
            timer -= Time.deltaTime;
            if (timer<=0)
            {
                timer = 1f;
                LoadScene();
            }
        }

    }
}
