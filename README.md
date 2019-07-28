# PoolManager
![Screenshot](https://gitlab.com/ilnprj/poolmanager/uploads/a762daa4e96fe4a21bb1c258a5b86ac7/poolScreen.png)
## Features:
- `Simple Pooling System`
  - Script to work with only one prefab. Wokrks with only GameObjects.
- `Pool Manager`
  - Script allows you to bring in a different prefabs and stores a pool for each of them. Works with only GameObjects.
  - Supports the function of moving between scenes. (Set TypeLoad in DontDestroy)
- `Abstract Pool Manager`
  - Script works with abstract types and allow you to use any type for the pool. However, the work on the abstract type spawn lies outside this script.

## Main methods:
- `PoolInstaller`
  - Preloads the required number of copies of the prefab to the pool
- `Spawn`
  - A spawn copy from the pool, if empty in the pool, generates a new copy automatically. 
- `BackToPool`
  - Returns the active item back to the pool.

## How to work:
### Simple Pooling:
- Drag Controller (SimplePooling.cs) in scene.
- Sets in public field Prefab.
- Then scene starts - preload pool with method `PoolInstaller(int numPreoladedObj)`.
- If you need copy from pool - call `Spawn` method.
- When you need return them back - call `BackToPool` .

### PoolManager:
- Drag Controller (PoolManager.cs) in scene.
- Sets type load controller (once or dontdestroyonload) in public field (enum).
- Then scene starts - preload pool with method `PoolInstaller(GameObject prefab, int size, string idGroup)`
- `idGroup` value is needed to find the necessary pool in the dictionary
- When you need to get an active copy from the pool through a call `SpawnObject(GameObject prefab,string idGroup)`
- `BackToPool(GameObject item,string idGroup)` allows you to return the active copy back to the pool
### Using pooling with abstract objects and components:

## UnityPackage
- [Version-1.0.0](https://gitlab.com/ilnprj/poolmanager/blob/release/PoolManager_v1.0.0.unitypackage)

## Notes:
- So far, the pool elements do not support the delete from outside. This feature can be added later.