using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Bullets
{
    public class BulletPool
    {
        private BulletView _bulletView;
        private BulletScriptableObject _bulletScriptableObject;
        private List<PooledBullet> _pooledBulletList;

        public BulletPool(BulletView bulletView, BulletScriptableObject bulletScriptableObject) 
        {
            this._bulletView = bulletView;
            this._bulletScriptableObject = bulletScriptableObject;
            _pooledBulletList = new List<PooledBullet>();
        }

        public class PooledBullet
        {
            public BulletController Bullet;
            public bool isUsed;
        }
    }
}

