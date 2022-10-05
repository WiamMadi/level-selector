using UnityEngine;
using TMPro;

public class Level : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] public string id;
    [SerializeField] public Scence scence;
    [SerializeField] public LevelState state;

    private void Start()
    {
        text.text = id;
    }
}