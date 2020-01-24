using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 単一の存在でありたいのでinstanceを作りここ経由でアクセスさせる
    public static GameManager instance;
    // ゲームが動いているか
    private bool isGaming;
    private Player player;
    private EnemiesController enemiesController;
    private Image clearImage;
    private GameObject retryButton;

    void Awake()
    {
        // 画面サイズをリビルド
        Screen.SetResolution(800, 600, false);
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = GetComponent<GameManager>();
        instance.player = GameObject.FindObjectOfType<Player>();
        instance.enemiesController = GameObject.FindObjectOfType<EnemiesController>();
        instance.clearImage = GameObject.Find("Canvas/Congratulation").GetComponent<Image>();
        instance.retryButton = GameObject.Find("Canvas/RetryButton");

        instance.clearImage.enabled = false;
        instance.retryButton.SetActive(false);
        instance.StopGame();
    }

    // Update is called once per frame
    void Update()
    {
        // Espキーで終了
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();

        if (enemiesController.gameObject.transform.childCount <= 0)
        {
            instance.ClearGame();
        }
    }

    public void StartGame()
    {
        instance.isGaming = true;
        instance.player.enabled = true;
    }

    public void StopGame()
    {
        instance.isGaming = false;
        instance.player.enabled = false;
    }

    public void ClearGame()
    {
        instance.isGaming = false;
        instance.player.enabled = false;
        instance.clearImage.enabled = true;
        instance.retryButton.SetActive(true);
    }

    public bool IsGaming()
    {
        return instance.isGaming;
    }

    public void OnRetryButton()
    {
        SceneManager.LoadScene(0);
    }
}
