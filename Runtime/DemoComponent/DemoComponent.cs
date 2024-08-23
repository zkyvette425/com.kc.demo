using Cysharp.Threading.Tasks;
using UnityEngine;

namespace KC
{
    public class DemoComponent : Component,IAwake
    {
        public void Awake()
        {
            OnLoad().ToCoroutine();
        }

        private async UniTask OnLoad()
        {
            var unit = this.AddComponent<UnitComponent, UnitType>(UnitType.Triangle);
            await unit.Load();
            unit.Create(new Vector2(0,3));
            
            var unit2 = this.AddComponent<UnitComponent, UnitType>(UnitType.Square);
            await unit2.Load();
            unit2.Create(new Vector2(3,3));
        }
    }
}