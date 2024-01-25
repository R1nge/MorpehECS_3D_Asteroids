using UnityEngine;

namespace _Assets.Scripts.Services.UIs.StateMachine.States
{
    public class UIInGameState : IUIState
    {
        private readonly UIFactory _uiFactory;
        private GameObject _ui;

        public UIInGameState(UIFactory uiFactory) => _uiFactory = uiFactory;

        public void Enter() => _ui = _uiFactory.CreateInGameUI().gameObject;

        public void Exit() => Object.Destroy(_ui);
    }
}