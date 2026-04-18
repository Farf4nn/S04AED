using UnityEngine;
using Sirenix.OdinInspector;

public class GameManager : MonoBehaviour
{
    public Transform player;

    private DoubleLinkedList<GameState> timeline = new();

    void Start()
    {
        SaveTurn();
    }
    public void MoveForward()
    {
        Move(Vector3.forward);
    }

    public void MoveBack()
    {
        Move(Vector3.back);
    }

    public void MoveLeft()
    {
        Move(Vector3.left);
    }

    public void MoveRight()
    {
        Move(Vector3.right);
    }

    void Move(Vector3 dir)
    {
        player.position += dir;

        SaveTurn();
    }

    [Button]
    public void NextTurn()
    {
        timeline.MoveNext();
        ApplyState();
    }

    [Button]
    public void PrevTurn()
    {
        timeline.MovePrev();
        ApplyState();
    }

    [Button]
    public void ReturnToLast()
    {
        while (timeline.pivot != timeline.tail)
        {
            timeline.MoveNext();
        }

        ApplyState();
    }

    public void SaveTurn()
    {
        GameState state = new GameState
        {
            playerPosition = player.position,
            playerHP = 100,
            playerAttack = 10
        };

        timeline.AddTurn(state.Clone());

        Debug.Log("Turno guardado = Total: " + timeline.Count);
    }
    void ApplyState()
    {
        if (timeline.pivot == null) return;

        GameState state = timeline.pivot.Value;

        player.position = state.playerPosition;

        Debug.Log("Reproduciendo turno = " + state.playerPosition);
    }
}