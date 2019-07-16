#pragma warning disable 0649
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int drawDistance = 32;
    [SerializeField] private LevelPiece[] pieces;
    [SerializeField] private float pieceLength = 3.6f;
    
    private Transform cam;
    private int currCamStep = 0;
    private int lastCamStep = 0;

    private Queue<GameObject> activePieces;
    private List<int> probabilities;

    private void Awake()
    {
        Camera c = Camera.main;
        if (c != null)
        {
            cam = c.transform;
        }

        activePieces = new Queue<GameObject>();
        probabilities = new List<int>();
    }

    private void Start()
    {
        BuildProbabilities();

        for (int i = 0; i < drawDistance; i++)
        {
            SpawnPiece();
        }

        currCamStep = lastCamStep = (int) (cam.position.z / pieceLength);
    }

    private void BuildProbabilities()
    {
        for (int index = 0; index < pieces.Length; index++)
        {
            int prob = pieces[index].probability;
            for (int i = 0; i < prob; i++)
            {
                probabilities.Add(index);
            }
        }
    }

    private void Update()
    {
        Vector3 pos = cam.position;
        // pos = Vector3.MoveTowards(pos, pos + Vector3.forward, speed * Time.deltaTime);
        // cam.position = pos;

        currCamStep = (int) (pos.z / pieceLength);

        if (currCamStep != lastCamStep)
        {
            DespawnPiece();
            SpawnPiece();

            lastCamStep = currCamStep;
        }
    }

    private void SpawnPiece()
    {
        int index = probabilities[Random.Range(0, probabilities.Count)];
        GameObject newPiece = Instantiate(
            pieces[index].prefab,
            new Vector3(0f, 0f, (currCamStep + activePieces.Count) * pieceLength),
            Quaternion.identity);

        activePieces.Enqueue(newPiece);
    }

    private void DespawnPiece()
    {
        GameObject oldPiece = activePieces.Dequeue();
        Destroy(oldPiece);
    }
}
