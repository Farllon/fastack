$packPubProcessVersion = '1.0.0'
$libs = @('FaStack Bus (Abstractions)', 'FaStack Bus (Core)', 'FaStack Bus (Dependency Injection)', 'FaStack Data (Abstractions)', 'FaStack Data (Core)')

$selected = 0

While ($key -ne 13) 
{
    Clear-Host
    Write-Host " FaStack Library PackPub Proccess v$packPubProcessVersion `n" -BackgroundColor Red
    Write-Host "Select which library you want to build and publish:`n"

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

    $pres = $host.ui.rawui.readkey(“NoEcho,IncludeKeyDown”)
    $key = $pres.virtualkeycode

    If (($key -eq 38) -and ($selected -lt ($libs.count)) -and ($selected -gt 0)) 
    {
        $selected--
    }
    If (($key -eq 40) -and ($selected -ge 0) -and ($selected -lt ($libs.count - 1))) 
    {
        $selected++
    }
}

Write-Host `n

Switch ( $selected )
{
    0 { $dir = ".\libs\fastack-bus\abstractions\FaStack.Bus.Abstractions\FaStack.Bus.Abstractions.csproj" }
    1 { $dir = ".\libs\fastack-bus\core\FaStack.Bus\FaStack.Bus.csproj" }
    2 { $dir = ".\libs\fastack-bus\extensions\FaStack.Bus.Extensions.DependencyInjection\FaStack.Bus.Extensions.DependencyInjection.csproj" }
    3 { $dir = ".\libs\fastack-data\abstractions\FaStack.Data.Abstractions\FaStack.Data.Abstractions.csproj" }
    4 { $dir = ".\libs\fastack-data\core\FaStack.Data\FaStack.Data.csproj" }
}

Try
{
    Remove-Item -LiteralPath "./packout" -Force -Recurse
}
Catch [System.Management.Automation.ItemNotFoundException]
{

}

dotnet pack $dir -c Release -o ./packout
dotnet nuget push ".\packout\*.nupkg" --api-key $([System.Environment]::GetEnvironmentVariable('NUGET_API_KEY', 'user')) --source https://api.nuget.org/v3/index.json

Read-Host