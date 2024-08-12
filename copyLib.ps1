# this script uses [gsudo](https://github.com/gerardog/gsudo)

Push-Location
Set-Location $PSScriptRoot

sudo {
    $ptPath = "C:\Program Files\PowerToys"

    @(
        'PowerToys.Common.UI.dll',
        'PowerToys.ManagedCommon.dll',
        'PowerToys.Settings.UI.Lib.dll',
        'Wox.Infrastructure.dll',
        'Wox.Plugin.dll'
    ) | ForEach-Object {
        $linkPath = "./Lib/$_"
        if (-Not (Test-Path $linkPath)) {
            New-Item $linkPath -ItemType SymbolicLink -Value "$ptPath\$_"
        } else {
            Write-Host "Symbolic link $linkPath already exists. Skipping..."
        }
    }
}

Pop-Location
