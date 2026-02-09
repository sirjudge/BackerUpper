using Terminal.Gui;

namespace Cli.Views;

public class MainMenuView : View {
    public MainMenuView(){
        Width = Dim.Fill();
        Height = Dim.Fill();
        Label mainTextLabel = new ()
        {
            Text = """
                ░████████                         ░██
                ░██    ░██                        ░██
                ░██    ░██   ░██████    ░███████  ░██    ░██ ░███████  ░██░████
                ░████████         ░██  ░██    ░██ ░██   ░██ ░██    ░██ ░███
                ░██     ░██  ░███████  ░██        ░███████  ░█████████ ░██
                ░██     ░██ ░██   ░██  ░██    ░██ ░██   ░██ ░██        ░██
                ░█████████   ░█████░██  ░███████  ░██    ░██ ░███████  ░██

                ░██     ░██
                ░██     ░██
                ░██     ░██ ░████████  ░████████   ░███████  ░██░████
                ░██     ░██ ░██    ░██ ░██    ░██ ░██    ░██ ░███
                ░██     ░██ ░██    ░██ ░██    ░██ ░█████████ ░██
                 ░██   ░██  ░███   ░██ ░███   ░██ ░██        ░██
                  ░██████   ░██░█████  ░██░█████   ░███████  ░██
                            ░██        ░██
                            ░██        ░██
                [b]ackup
                [r]estore
                [c]onfigure files
                [q]uit
                """,
            X = Pos.Center (),
            Y = Pos.Center ()
        };
        Add(mainTextLabel);
    }
}
