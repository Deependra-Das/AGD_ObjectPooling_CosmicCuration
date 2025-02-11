using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXService
    {
        private VFXPool _vfxPoolObj;

        public VFXService(VFXView vfxPrefab) => _vfxPoolObj = new VFXPool(vfxPrefab);

        public void PlayVFXAtPosition(VFXType type, Vector2 spawnPosition)
        {
            VFXController vfxToPlay = _vfxPoolObj.GetVFX();
            vfxToPlay.Configure(type, spawnPosition);
        }

        public void ReturnVFXToPool(VFXController vfxToReturn) => _vfxPoolObj.ReturnItem(vfxToReturn);
    } 
}