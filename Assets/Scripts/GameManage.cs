using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    SpriteRenderer playerSpriteRenderer;
    private void Awake()
    {
        playerSpriteRenderer = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if (!GeometryUtility.TestPlanesAABB(planes, playerSpriteRenderer.bounds))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        SoundManage.instance.GameOverSound();      
        Invoke("ReloadGame",1f);
    }

    void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }

}
