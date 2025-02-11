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

        public BulletController GetBullet()
        {
            if(_pooledBulletList.Count>0)
            {
                PooledBullet pooledBullet = _pooledBulletList.Find(item=>!item.isUsed);
                if(pooledBullet!=null)
                {
                    pooledBullet.isUsed = true;
                    return pooledBullet.Bullet;
                }
        
            }
            return CreateNewPooledBullet();

        }

        private BulletController CreateNewPooledBullet()
        {
            PooledBullet pooledBullet = new PooledBullet();
            pooledBullet.Bullet = new BulletController(_bulletView, _bulletScriptableObject);
            pooledBullet.isUsed = true;
            _pooledBulletList.Add(pooledBullet);

            return pooledBullet.Bullet;
        }

        public void ReturnBulletToPool(BulletController returnedBullet)
        {  
            PooledBullet pooledBullet = _pooledBulletList.Find(item=>item.Bullet.Equals(returnedBullet));
            pooledBullet.isUsed = false;
        }

        public class PooledBullet
        {
            public BulletController Bullet;
            public bool isUsed;
        }
    }
}

