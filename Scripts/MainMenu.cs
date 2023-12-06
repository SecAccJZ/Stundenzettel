using Godot;

public partial class MainMenu : CanvasLayer
{
    private void SwitchToNewFile() => Manager.Singleton.SwitchScene("TimeSheetEditor");



    private void SwitchToFileSelection() => Manager.Singleton.SwitchScene("TimeSheetSelector");



    private void SwitchToSettings() => Manager.Singleton.SwitchScene("Settings");



    private void QuitApp() => GetTree().Quit();
}
