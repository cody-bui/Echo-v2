using System;
using System.Collectins.Generic;

// base entity class
public class Entity
{
}

// derived player class
public class Player : Entity
{
}

// base component attribute (not exactly a class)
[AttributeUsage.Struct /*something like that */]
public class Component : Attribute
{
}

// 'derived' transform component
[Component]
public struct TransformComponent
{
}

// entity manager can add, remove and return an entity
public static class EntityManager
{
	private static List<Entity> Entities = new ();

	public static T Add<T>() where T : Entity {/* add to the back of the list */}
	
	public static void Remove(int id) {/* find and remove */}

	public static T Get<T>() where T : Enitity {/* find and return */}
}

public class ComponentData<T> where T : Component
{
	public List<(Type, List<T>)> Components = new();

	public IEnumerable<T> Iterate() { 
		for (component1 in components)
			for (component2 in component1)
				yield return component2;
	}
}

public static class ComponentManager
{
	
}