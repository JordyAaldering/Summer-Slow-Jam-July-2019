using System;
using UnityEngine;

namespace Level
{
    [Serializable]
    public class LevelPiece
    {
        public string name;
        public GameObject prefab;
        public float pieceLength;
        public int probability;
    }
}
