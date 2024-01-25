using UnityEngine;

namespace _Assets.Scripts.Services.UIs.StateMachine.States
{
    public class UIGameOverState : IUIState
    {
        private readonly UIFactory _uiFactory;
        private GameObject _ui;

        public UIGameOverState(UIFactory uiFactory) => _uiFactory = uiFactory;

        public void Enter() => _ui = _uiFactory.CreateGameOverUI().gameObject;

        public void Exit() => Object.Destroy(_ui);
    }
}