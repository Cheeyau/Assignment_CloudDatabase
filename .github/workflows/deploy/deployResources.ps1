$prefix              = 'AM-CLOUD'
$resourceGroup = "$prefix-APP-D-AZWE-RG-1"
$template            = "./template.bicep"
$subscription        = "329c27a4-4c18-4953-8963-951fd6571018"
$parameters = @{
    prefix      = $prefix
    serviceTag  = "APP"
    environment = "D"
    regionTag   = "AZWE"
}

$parameters = $parameters.Keys.ForEach({"$_=$($parameters[$_])"}) -join ' '

Write-Host "Deploying resources in $resourceGroup"

# Create a new resource-group
if (az group exists -n $resourceGroup) {
    Write-Host "Resource group does not exist, deploying resources group."
    az group create -l westeurope -n $resourceGroup
    
    az ad sp create-for-rbac --name "http://githubactionazure" --role contributor --scopes /subscriptions/$subscription/resourceGroups/$resourceGroup --sdk-auth
} else {
    Write-Host "Resource group already exist, deploying resources in the group from template."
    Write-Host "Cleaning resourceGroup: AM-CLOUD-APP-D-AZWE-RG-1"
    az deployment group create --mode Complete --resource-group $resourceGroup --template-file template-cleanup.json
}

# Deploy resources inside resource-group
$cmd = "az deployment group create --mode Incremental --resource-group $resourceGroup --template-file $template --parameters $parameters"
Write-Host $cmd
Invoke-Expression  $cmd