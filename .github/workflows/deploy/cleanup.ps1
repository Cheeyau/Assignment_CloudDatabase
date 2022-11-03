$resourceGroup = "GRP1-GTA-0001-APP-D-AZWE-RG-1"

Write-Host "Cleaning resourceGroup: GRP1-GTA-0001-APP-D-AZWE-RG-1"

az deployment group create --mode Complete --resource-group $resourceGroup --template-file template-cleanup.json
