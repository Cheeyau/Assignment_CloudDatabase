$resourceGroup = "AM-CLOUD-APP-D-AZWE-RG-1"

Write-Host "Cleaning resourceGroup: AM-CLOUD-APP-D-AZWE-RG-1"

az deployment group create --mode Complete --resource-group $resourceGroup --template-file template-cleanup.json
