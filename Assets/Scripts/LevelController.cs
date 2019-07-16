#pragma warning disable 0649
using UnityEngine;

namespace Level
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private int drawDistance;
        [SerializeField] private LevelPiece[] levelPieces;

        private Transform cam;

        private void Awake()
        {
            Camera c = Camera.main;
            if (c != null)
            {
                cam = c.transform;
            }
        }

        private void Start()
        {
            float zOffset = 0;
            for (int i = 0; i < drawDistance; i++)
            {
                GameObject levelPiece = Instantiate(
                    levelPieces[0].prefab,
                    new Vector3(0f, 0f, zOffset),
                    Quaternion.identity);
                zOffset += levelPieces[0].pieceLength;
            }
        }
    }
}
