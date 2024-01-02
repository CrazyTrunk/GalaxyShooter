using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private GameState _gameState;

    public void ChangeState(GameState state)
    {
        _gameState = state;
    }

    public bool IsState(GameState gameState)
    {
        return _gameState == gameState;
    }
}
