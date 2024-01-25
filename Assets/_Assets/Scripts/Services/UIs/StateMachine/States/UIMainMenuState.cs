using UnityEngine;

namespace _Assets.Scripts.Services.UIs.StateMachine.States
{
    public class UIMainMenuState : IUIState
    {
        private readonly UIFactory _uiFactory;
        private GameObject _ui;

        public UIMainMenuState(UIFactory uiFactory) => _uiFactory = uiFactory;

        public void Enter() => _ui = _uiFactory.CreateMainMenuUI().gameObject;

        public void Exit() => Object.Destroy(_ui);
    }
}