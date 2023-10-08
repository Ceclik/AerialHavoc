using UnityEngine;

public class StartGameCondtions : MonoBehaviour
{
    public bool IsStarted { get; private set; }
    [SerializeField] private int minAmountOfPlayersToStart;
    [SerializeField] private Transform players;

    private void Start()
    {
        IsStarted = false;
    }

    private void Update()
    {
        if (players.childCount >= minAmountOfPlayersToStart)
            IsStarted = true;
    }
}
