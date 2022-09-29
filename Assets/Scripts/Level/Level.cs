using UnityEngine;

[System.Serializable]
public class Level : MonoBehaviour
{
    [SerializeField] public string id;
    [SerializeField] public Scence scence;
    [SerializeField] public LevelState state;
}