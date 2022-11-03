$resourceGroup = "GRP1-GTA-0001-APP-D-AZWE-RG-1"
$subscription = "57182d09-7f87-4d00-bdec-99ce6ef65e03"

az login --tenant $subscription

# Get secret key up for deployment
# Get subscription ID from the resource group URL
az ad sp create-for-rbac --name "http://githubactionazure" --role contributor --scopes /subscriptions/$subscription/resourceGroups/$resourceGroup --sdk-auth
