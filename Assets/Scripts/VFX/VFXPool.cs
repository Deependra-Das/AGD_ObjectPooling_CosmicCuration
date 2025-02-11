using CosmicCuration.Utilities;

namespace CosmicCuration.VFX
{
    public class VFXPool : GenericObjectPool<VFXController>
    {
        private VFXView _vfxPrefab;

        public VFXPool(VFXView vfxPrefab) => this._vfxPrefab = vfxPrefab;
        
        public VFXController GetVFX() =>  GetItem<VFXController>();        

        protected override VFXController CreateItem<T>() => new VFXController(_vfxPrefab);
        
    }
}
