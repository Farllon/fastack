$packPubProcessVersion = '1.0.0'
$libs = @('FaStack Bus (Abstractions)', 'FaStack Bus (Core)', 'FaStack Bus (Dependency Injection)', 'FaStack Data (Abstractions)', 'FaStack Data (Core)')

Write-Host " FaStack Library PackPub Proccess v$packPubProcessVersion `n" -BackgroundColor Red
Write-Host "Select which library you want to build and publish: (w: UP, s: DOWN)`n"

$selected = 0

For ( $i = 0; $i -lt $libs.Count; $i++ ) 
{
    If ( $i -eq $selected ) 
    {
        Write-Host "[$i]" $libs[$i] "<-" -BackgroundColor Red
    }
    Else
    {
        Write-Host "[$i]" $libs[$i]
    }
}

$key = $host.UI.RawUI.ReadKey();