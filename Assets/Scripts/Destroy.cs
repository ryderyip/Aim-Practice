using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    private GameManager gameManager;
    private Coroutine selfDestroy;
    private Settings settings;

    // Start is called before the first frame update
    void Start()
    {
        settings = GameObject.Find("Settings").GetComponent<Settings>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        selfDestroy = StartCoroutine(SelfDestroy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        StopCoroutine(SelfDestroy());
        gameManager.UpdateScore(1);
    }

    private IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(settings.spawnRate);
        gameManager.GetComponent<GameManager>().GameOver();
        Destroy(gameObject);
    }
}
