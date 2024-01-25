using _Assets.Scripts.Services.UIs.StateMachine.States;

namespace _Assets.Scripts.Services.UIs.StateMachine
{
    public class UIStatesFactory
    {
        public IUIState CreateMainMenuState(UIStateMachine uiStateMachine)
        {
            return new UIMainMenuState();
        }
        
        public IUIState CreateInGameState(UIStateMachine uiStateMachine)
        {
            return new UIInGameState();
        }
        
        public IUIState CreateGameOverState(UIStateMachine uiStateMachine)
        {
            return new UIGameOverState();
        }
    }
}