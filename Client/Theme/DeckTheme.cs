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
/*    <Color x:Key="light_primary">#924274</Color>
    <Color x:Key="light_onPrimary">#FFFFFF</Color>
    <Color x:Key="light_primaryContainer">#FFD8EB</Color>
    <Color x:Key="light_onPrimaryContainer">#3C002B</Color>
    <Color x:Key="light_secondary">#715764</Color>
    <Color x:Key="light_onSecondary">#FFFFFF</Color>
    <Color x:Key="light_secondaryContainer">#FCD9E9</Color>
    <Color x:Key="light_onSecondaryContainer">#291521</Color>
    <Color x:Key="light_tertiary">#80543C</Color>
    <Color x:Key="light_onTertiary">#FFFFFF</Color>
    <Color x:Key="light_tertiaryContainer">#FFDBCA</Color>
    <Color x:Key="light_onTertiaryContainer">#311303</Color>
    <Color x:Key="light_error">#BA1A1A</Color>
    <Color x:Key="light_errorContainer">#FFDAD6</Color>
    <Color x:Key="light_onError">#FFFFFF</Color>
    <Color x:Key="light_onErrorContainer">#410002</Color>
    <Color x:Key="light_background">#FFFBFF</Color>
    <Color x:Key="light_onBackground">#1F1A1C</Color>
    <Color x:Key="light_surface">#FFFBFF</Color>
    <Color x:Key="light_onSurface">#1F1A1C</Color>
    <Color x:Key="light_surfaceVariant">#F0DEE5</Color>
    <Color x:Key="light_onSurfaceVariant">#504349</Color>
    <Color x:Key="light_outline">#827379</Color>
    <Color x:Key="light_inverseOnSurface">#F9EEF1</Color>
    <Color x:Key="light_inverseSurface">#352F31</Color>
    <Color x:Key="light_inversePrimary">#FFAEDB</Color>
    <Color x:Key="light_shadow">#000000</Color>
    <Color x:Key="light_surfaceTint">#924274</Color>
    <Color x:Key="light_surfaceTintColor">#924274</Color>




    <Color x:Key="dark_primary">#FFAEDB</Color>
    <Color x:Key="dark_onPrimary">#5A1144</Color>
    <Color x:Key="dark_primaryContainer">#762A5C</Color>
    <Color x:Key="dark_onPrimaryContainer">#FFD8EB</Color>
    <Color x:Key="dark_secondary">#DEBECD</Color>
    <Color x:Key="dark_onSecondary">#402A36</Color>
    <Color x:Key="dark_secondaryContainer">#58404C</Color>
    <Color x:Key="dark_onSecondaryContainer">#FCD9E9</Color>
    <Color x:Key="dark_tertiary">#F3BA9D</Color>
    <Color x:Key="dark_onTertiary">#4A2713</Color>
    <Color x:Key="dark_tertiaryContainer">#653D27</Color>
    <Color x:Key="dark_onTertiaryContainer">#FFDBCA</Color>
    <Color x:Key="dark_error">#FFB4AB</Color>
    <Color x:Key="dark_errorContainer">#93000A</Color>
    <Color x:Key="dark_onError">#690005</Color>
    <Color x:Key="dark_onErrorContainer">#FFDAD6</Color>
    <Color x:Key="dark_background">#1F1A1C</Color>
    <Color x:Key="dark_onBackground">#EAE0E3</Color>
    <Color x:Key="dark_surface">#1F1A1C</Color>
    <Color x:Key="dark_onSurface">#EAE0E3</Color>
    <Color x:Key="dark_surfaceVariant">#504349</Color>
    <Color x:Key="dark_onSurfaceVariant">#D3C2C9</Color>
    <Color x:Key="dark_outline">#9C8D93</Color>
    <Color x:Key="dark_inverseOnSurface">#1F1A1C</Color>
    <Color x:Key="dark_inverseSurface">#EAE0E3</Color>
    <Color x:Key="dark_inversePrimary">#924274</Color>
    <Color x:Key="dark_shadow">#000000</Color>
    <Color x:Key="dark_surfaceTint">#FFAEDB</Color>
    <Color x:Key="dark_surfaceTintColor">#FFAEDB</Color>*/