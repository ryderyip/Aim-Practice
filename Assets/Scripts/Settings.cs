using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject circlePrefab;
    public GameManager gameManager;

    public float spawnRate = 1;
    public float duration = 30;
    public float targetSize = 1;
    private Vector3 targetScale;


    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }

    public void SetCircleSize()
    {
        targetScale = new Vector3(targetSize, targetSize);
        circlePrefab.transform.localScale = targetScale;
    }
}
