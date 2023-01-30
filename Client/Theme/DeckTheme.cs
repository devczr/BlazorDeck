using MudBlazor;

namespace BlazorDeck.Client.Theme;

public class DeckTheme : MudTheme
{
	public DeckTheme()
	{

        PaletteDark = new PaletteDark() 
        {
            Primary = M3Colors.Dark.primary,
            PrimaryContrastText = M3Colors.Dark.onPrimary,
            Secondary = M3Colors.Dark.secondary,
            SecondaryContrastText = M3Colors.Dark.onSecondary,
            Tertiary = M3Colors.Dark.tertiary,
            TertiaryContrastText = M3Colors.Dark.onTertiary,
            Background = M3Colors.Dark.background,
            AppbarBackground = M3Colors.Dark.background,
            DrawerBackground = M3Colors.Dark.surfaceVariant,
            DrawerText = M3Colors.Dark.onSurfaceVariant,
            Surface = M3Colors.Dark.surfaceVariant,
        };
    }
}