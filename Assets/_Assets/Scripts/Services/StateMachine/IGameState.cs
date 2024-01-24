namespace _Assets.Scripts.Services.StateMachine
{
    public interface IGameState : IExitState
    {
        void Enter();
    }

    public interface IExitState
    {
        void Exit();
    }
}