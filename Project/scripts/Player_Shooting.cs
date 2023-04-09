using Godot;
using System;

public partial class Player_Shooting : Node3D
{
	public Node3D _world;
	public MeshInstance3D _weapon_model;
	public Marker3D _weapon_bulletExit;
	public Marker3D _weapon_shellExit;
	public override void _Ready()
	{
		_world = GetNode<Node3D>("/root/World");
		_weapon_model = GetNode<MeshInstance3D>("Camera/Weapon_Model");
		_weapon_shellExit = GetNode<Marker3D>("Camera/Weapon_Model/ShellExit");
		_weapon_bulletExit = GetNode<Marker3D>("Camera/Weapon_Model/BulletExit");
	}

	public override void _Input(InputEvent @event){



	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("weapon_shoot"))
		{
			if (Input.IsActionPressed("weapon_shoot")){
				PackedScene bullet = GD.Load<PackedScene>("res://objects/bullet.tscn");
				Node3D bulletInstance = bullet.Instantiate<Node3D>();
				bulletInstance.Position = _weapon_bulletExit.GlobalPosition;
				bulletInstance.Transform = _weapon_bulletExit.GlobalTransform;
				_world.AddChild(bulletInstance);
		}
		} else if (Input.IsActionPressed("weapon_shoot_alt")) {
			//Alt Soot
		} else if (Input.IsActionPressed("weapon_reload")){
			//Reload
		}
	}
}
