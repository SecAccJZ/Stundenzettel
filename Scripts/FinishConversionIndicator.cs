using Godot;

public partial class FinishConversionIndicator : Label
{
	private bool vanish = false;


	
	public override void _Process(double delta)
	{
		if (vanish)
		{
			Modulate = Modulate with { A = Modulate.A - 0.01f };
			
			if (Modulate.A <= 0)
				vanish = false;
		}
	}



	private void SetVanishTrue() => vanish = true;
}
