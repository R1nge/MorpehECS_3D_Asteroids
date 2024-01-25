using _Assets.Scripts.Services.UIs.StateMachine.States;

namespace _Assets.Scripts.Services.UIs.StateMachine
{
    public class UIStatesFactory
    {
        private readonly UIFactory _uiFactory;

        private UIStatesFactory(UIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }
        
        public IUIState CreateMainMenuState(UIStateMachine uiStateMachine)
        {
            return new UIMainMenuState(_uiFactory);
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