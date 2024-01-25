using UnityEngine;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class InitState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;

        public InitState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        public void Enter()
        {
            Debug.Log("Enter InitState");
        }

        public void Exit()
        {
        }
    }
}