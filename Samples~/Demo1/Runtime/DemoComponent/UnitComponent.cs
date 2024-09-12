using Cysharp.Threading.Tasks;
using UnityEngine;
using YooAsset;

namespace KC
{
    public class UnitComponent : Component,IAwake<UnitType>,IUpdate
    {
        private SpriteRenderer _asset;
        private SpriteRenderer _obj;
        
        public UnitType UnitType { get; private set; }

        
        public async UniTask Load()
        {
            var name = UnitType.ToString();
            var handle = YooAssets.LoadAssetAsync(name);
            await handle.ToUniTask();
            
            _asset = handle.GetAssetObject<GameObject>().GetComponent<SpriteRenderer>();
           // handle.Release();
        }

        public void Create(Vector2 position)
        {
            if (_obj == null)
            {
                _obj = Object.Instantiate(_asset);
                _obj.transform.position = position;
            }
        }

        public void Awake(UnitType unitType)
        {
            UnitType = unitType;
        }

        public void Update()
        {
            if (_obj == null)
            {
                return;
            }
            _obj.transform.Rotate(Vector3.forward,30 * Time.deltaTime * 4);
        }
    }

    public enum UnitType
    {
        Triangle,
        
        Square
    }
}