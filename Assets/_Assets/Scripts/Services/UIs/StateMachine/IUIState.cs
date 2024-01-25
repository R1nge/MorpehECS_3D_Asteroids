namespace _Assets.Scripts.Services.UIs.StateMachine
{
    public interface IUIState : IUIExitState
    {
        void Enter();
    }

    public interface IUIExitState
    {
        void Exit();
    }
}