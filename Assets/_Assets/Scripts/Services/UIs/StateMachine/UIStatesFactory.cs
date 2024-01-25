using _Assets.Scripts.Services.UIs.StateMachine.States;

namespace _Assets.Scripts.Services.UIs.StateMachine
{
    public class UIStatesFactory
    {
        private readonly UIFactory _uiFactory;

        private UIStatesFactory(UIFactory uiFactory) => _uiFactory = uiFactory;

        public IUIState CreateMainMenuState(UIStateMachine uiStateMachine) => new UIMainMenuState(_uiFactory);

        public IUIState CreateInGameState(UIStateMachine uiStateMachine) => new UIInGameState(_uiFactory);

        public IUIState CreateGameOverState(UIStateMachine uiStateMachine) => new UIGameOverState(_uiFactory);
    }
}