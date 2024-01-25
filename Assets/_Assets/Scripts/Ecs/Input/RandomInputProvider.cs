using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Input
{
    public class RandomInputProvider : MonoProvider<InputComponent>
    {
        protected override void Initialize()
        {
            Entity.GetComponent<InputComponent>().direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }
    }
}