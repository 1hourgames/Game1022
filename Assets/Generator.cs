using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] platforms;
    public float yDistance;
    public float xDistance;

    public float minXDistance;
    public float maxXDistance;
    public GameObject player;
    public GameObject lastGenerated;

    public GameObject paper;
    public GameObject lastPaperObject; 

    private List<GameObject> oldPlatforms;

    // Start is called before the first frame update
    void Start()
    {
        oldPlatforms = new List<GameObject>();
        InvokeRepeating("Generation", 3, 3);
        InvokeRepeating("CleanUp", 15, 10);
        InvokeRepeating("PaperGeneration", 6, 15);

    }

    // Update is called once per frame

     
    void Generation()
    {

            int i = Random.Range(0, platforms.Length);
            float newXPos = lastGenerated.transform.position.x + Random.Range(-xDistance, xDistance);
            float clampedXPos = Mathf.Clamp(newXPos, minXDistance, maxXDistance);
            float newYPos = lastGenerated.transform.position.y + Random.Range(1.5f, yDistance);
            Vector2 newPosition = new Vector2(clampedXPos, newYPos);

            GameObject newPlatform = Instantiate(platforms[i], newPosition, Quaternion.identity);
            oldPlatforms.Add(lastGenerated);
            lastGenerated = newPlatform;

    }

    void CleanUp()
    {
        foreach(GameObject uselessPlatform in oldPlatforms)
        {
            Destroy(uselessPlatform);
        }
        oldPlatforms.Clear();
    }

    void PaperGeneration()
    {
        Vector2 newPaperObjectPosition = lastPaperObject.transform.position + new Vector3(0, 15.17f,0);
        GameObject newPaperObject = Instantiate(paper, newPaperObjectPosition, Quaternion.identity);
        lastPaperObject = newPaperObject;

    }

}
