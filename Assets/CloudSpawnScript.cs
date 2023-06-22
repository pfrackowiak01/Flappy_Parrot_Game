using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CloudSpawnScript : MonoBehaviour
{
    public GameObject cloud;
    public float spawnRate = 3;
    public float spawnRateBackground = 4;
    private float timerC = 3;
    private float timerCB = 3;
    public float heightOffset = 12;
    private float lowestPoint = 0;
    private float highestPoint = 0;
    private float size = 1;

    // Start is called before the first frame update
    void Start()
    {
        lowestPoint = transform.position.y - heightOffset;
        highestPoint = transform.position.y + heightOffset;

        spawnCloud(-30);
        spawnCloudBackground(-40);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerC > spawnRate)
        {
            spawnCloud(0);
            timerC = Random.Range(0, 2);
        }
        else timerC = timerC + Time.deltaTime;

        if (timerCB > spawnRateBackground)
        {
            spawnCloudBackground(0);
            timerCB = Random.Range(0,2);
        }
        else timerCB = timerCB + Time.deltaTime;
    }

    void spawnCloud(float deltaX)
    {
        Instantiate(cloud, new Vector3(transform.position.x - deltaX, Random.Range(lowestPoint, highestPoint), -5), transform.rotation);
        size = Random.Range(1, 3);
        cloud.transform.localScale = new Vector3(size, size, 1);

        // Pobranie komponentu SpriteRenderer z obiektu chmury
        SpriteRenderer cloudRenderer = cloud.GetComponent<SpriteRenderer>();

        // Ustawienie wartoœci "Order in Layer" na ni¿sz¹ wartoœæ (t³o)
        cloudRenderer.sortingOrder = 1;
    }

    void spawnCloudBackground(float deltaX)
    {
        Instantiate(cloud, new Vector3(transform.position.x - deltaX, Random.Range(lowestPoint, highestPoint), 5), transform.rotation);
        size = Random.Range(3, 7);
        cloud.transform.localScale = new Vector3(size, size, 1);

        // Pobranie komponentu SpriteRenderer z obiektu chmury
        SpriteRenderer cloudRenderer = cloud.GetComponent<SpriteRenderer>();

        // Ustawienie wartoœci "Order in Layer" na ni¿sz¹ wartoœæ (t³o)
        cloudRenderer.sortingOrder = -1;
    }
}
