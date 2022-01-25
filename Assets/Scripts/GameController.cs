using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private HUD hud;
    [SerializeField] private Player player;
    [SerializeField] private Spawner spawner;
    [SerializeField] private float jumpForce;
    [SerializeField] private SpawnParameters spawnParameters;

    private PlayMode playMode = PlayMode.Pause;
    private float time = 0;
    private float spawnTime;

    void Awake()
    {
        StartGame();
    }
   
    public void Update()
    {
        if (time >= spawnTime && playMode == PlayMode.Play)
        {
            spawner.SetItem(spawnParameters);
            spawnTime = SetTime();
            time = 0;
        }
        time += Time.deltaTime;
    }
    private void StartGame()
    {
        spawner.Spawn(PlayerTouch, spawnParameters);
        hud.onJump += PlayersJump;
        hud.onNextPlay += Next;
        hud.ShowGoText();
        StartCoroutine(ChangeMode());
    }
    private float SetTime()
    {
        var spawnTime = Random.Range(0,5);
        return spawnTime;
    }
    private IEnumerator ChangeMode()
    {
        yield return new WaitForSeconds(2f);
        hud.HidePanel(hud.textPanel);
        playMode = PlayMode.Play;
    }
    public void PlayersJump()
    {
        if(playMode == PlayMode.Play)
        player.Jump(jumpForce);
    }
    public void PlayerTouch()
    {
        playMode = PlayMode.Pause;
        StartCoroutine(GameOverActions());
    }
    private IEnumerator GameOverActions()
    {
        hud.ShowGameOverText();
        yield return new WaitForSeconds(2f);
        hud.HidePanel(hud.textPanel);
        hud.ShowPanel(hud.tryAgainPanel);
    }
    public void Next()
    {
        Debug.Log("GameOver");
    }
    private void OnDestroy()
    {
        hud.onJump -= PlayersJump;
        hud.onNextPlay -= Next;
    }
}
public enum PlayMode
{
    Pause,
    Play
}