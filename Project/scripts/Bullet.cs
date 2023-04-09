using Godot;
using System;

public partial class Bullet : RigidBody3D
{
	//int bulletSpeed = 20;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		this.MoveAndCollide(Vector3.Forward);
	}
}
