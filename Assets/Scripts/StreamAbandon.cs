using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using SocketEvent;

public class StreamAbandon : MonoBehaviour
{
    private ManetteJson _testJson;
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
            // Envoi aux manettes une information que la vidéo et fini et active la manette et/ou un obstacle
            // Debug.Log("Abandon Fini");
            _testJson = new ManetteJson();
            _testJson.eventName = "videoMobileFini";
            _testJson.finVideo = "videoFinish";

            SocketEvent.Client.sendMessage(SocketEvent.Client.ConvertDataObject(_testJson));

        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 1f;
            LoadScene();
        }

    }

}
