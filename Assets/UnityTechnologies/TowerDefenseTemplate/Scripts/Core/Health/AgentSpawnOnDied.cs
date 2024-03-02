using Core.Utilities;
using TowerDefense.Agents;
using TowerDefense.Agents.Data;
using TowerDefense.Nodes;
using UnityEngine;

namespace Core.Health
{
	public class AgentSpawnOnDied : MonoBehaviour
	{
		/// <summary>
		/// Agent Configuration that will be spawned on old agent destroyed
		/// </summary>
		[SerializeField] private AgentConfiguration agentConfiguration;

		/// <summary>
		/// The DamageableBehaviour that will be used to assign the damageable
		/// </summary>
		[SerializeField] private DamageableBehaviour damageableBehaviour;

		/// <summary>
		/// The damageable
		/// </summary>
		private Damageable m_Damageable;

		/// <summary>
		/// Subscribes to the damageable's died event
		/// </summary>
		/// <param name="damageable"></param>
		public void AssignDamageable(Damageable damageable)
		{
			if (m_Damageable != null)
			{
				m_Damageable.died -= OnDied;
			}
			m_Damageable = damageable;
			m_Damageable.died += OnDied;
		}

		/// <summary>
		/// If damageableBehaviour is populated, assigns the damageable
		/// </summary>
		private void Awake()
		{
			if (damageableBehaviour != null)
			{
				AssignDamageable(damageableBehaviour.configuration);
			}
		}

		/// <summary>
		/// Instantiate a death particle system
		/// </summary>
		private void OnDied(HealthChangeInfo healthChangeInfo)
		{
			Node node = gameObject.GetComponent<AttackingAgent>().GetCurrentNode();
			SpawnAgent(agentConfiguration, node);
		}

		/// <summary>
		/// spawns new agent
		/// </summary>
		/// <param name="agentConfig"></param>
		/// <param name="node"></param>
		private void SpawnAgent(AgentConfiguration agentConfig, Node node)
		{
			//Vector3 spawnPosition = node.GetRandomPointInNodeArea();

			var poolable = Poolable.TryGetPoolable<Poolable>(agentConfig.agentPrefab.gameObject);
			if (poolable == null)
			{
				return;
			}
			var agentInstance = poolable.GetComponent<Agent>();
			//agentInstance.transform.position = spawnPosition;
			agentInstance.transform.position = gameObject.transform.position;
			agentInstance.Initialize();
			agentInstance.SetNode(node);
			agentInstance.GetNextNode(node);
			agentInstance.transform.rotation = gameObject.transform.rotation;
			
		}
	}
}