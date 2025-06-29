using Unity.Burst;
using Unity.Transforms;
using Unity.Entities;

namespace Spawner
{
    public partial struct SpawnerSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
        
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (RefRW<Spawner> spawner in SystemAPI.Query<RefRW<Spawner>>())
            {
                ProcessSpawner(ref state, spawner);
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        
        }
        
        private void ProcessSpawner(ref SystemState state, RefRW<Spawner> spawner)
        {
            if (spawner.ValueRO.NextSpawnTime < SystemAPI.Time.ElapsedTime)
            {
                // Spawn a new entity and position it at the spawn position
                Entity newEntity = state.EntityManager.Instantiate(spawner.ValueRO.Prefab);
                state.EntityManager.SetComponentData(newEntity,
                    LocalTransform.FromPosition(spawner.ValueRO.SpawnPosition));
                spawner.ValueRW.NextSpawnTime = (float)SystemAPI.Time.ElapsedTime + spawner.ValueRO.SpawnRate;
            }
        }
    }
}
